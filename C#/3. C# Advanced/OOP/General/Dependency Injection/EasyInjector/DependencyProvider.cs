using System.Reflection;

namespace EasyInjector;

public class DependencyProvider
{
    private readonly Dictionary<Type, Dependency> mappedDependencies;

    internal DependencyProvider() // за да защитим външни програми да създават празни DependencyProvider, а да се създава директно от Injector
    {
        mappedDependencies = new();
    }

    public DependencyProvider Register<TAbstractType, TImplementationType>()
        where TImplementationType : class, TAbstractType
    {
        Type abstractType = typeof(TAbstractType);
        Type implementationType = typeof(TImplementationType);

        ValidateTypeDoesNotHaveMapping(abstractType);

        mappedDependencies[abstractType] = new Dependency(implementationType);

        return this;
    }

    public DependencyProvider Register<TAbstractType>(object implementationInstance)
        where TAbstractType : class
    {
        Type abstractType = typeof(TAbstractType);

        ValidateTypeDoesNotHaveMapping(abstractType);

        mappedDependencies[abstractType] = new Dependency(implementationInstance);

        return this;
    }

    public DependencyProvider Register<TAbstractType, TImplementationType>(Func<DependencyProvider, TImplementationType> factoryFunc)
        where TImplementationType : class, TAbstractType
    {
        Type abstractType = typeof(TAbstractType);

        ValidateTypeDoesNotHaveMapping(abstractType);

        mappedDependencies[abstractType] = new Dependency(factoryFunc);

        return this;
    }

    public TType Create<TType>()
        where TType : class
    {
        Type type = typeof(TType);

        return (TType)Create(type);
    }

    public object Create(Type type)
    {
        if (type.IsInterface)
        {
            if (!mappedDependencies.ContainsKey(type))
            {
                throw new InvalidOperationException($"'{type.FullName}' is not registered.");
            }

            return ResolveDependency(type);
        }

        ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public);

        if (constructors.Length == 0)
        {
            throw new InvalidOperationException($"'{type.FullName}' type does not have public instance constructors.");
        }
        else if (constructors.Length > 1)
        {
            throw new InvalidOperationException($"'{type.FullName}' type has more than 1 public instance constructor.");
        }

        ConstructorInfo constructor = constructors.First();
        ParameterInfo[] parameters = constructor.GetParameters();

        List<object> parameterInstances = new();

        foreach (ParameterInfo parameter in parameters)
        {
            Type parameterType = parameter.ParameterType;

            if (!mappedDependencies.ContainsKey(parameterType))
            {
                throw new InvalidOperationException($"'{type.FullName}' depends on '{parameterType.FullName}', which is not registered.");
            }

            object parameterInstance = ResolveDependency(parameterType);

            parameterInstances.Add(parameterInstance);
        }

        object result = constructor.Invoke(parameterInstances.ToArray());

        PopulateInjectableFields(type, result);

        return result;
    }

    private void ValidateTypeDoesNotHaveMapping(Type abstractType)
    {
        if (mappedDependencies.ContainsKey(abstractType))
        {
            throw new InvalidOperationException($"'{abstractType.FullName}' type is already registered");
        }
    }

    private object ResolveDependency(Type type)
    {
        Dependency dependency = mappedDependencies[type];

        if (dependency.Instance != null)
        {
            return dependency.Instance;
        }
        else if (dependency.Type != null)
        {
            object parameterInstance = Create(dependency.Type);

            return parameterInstance;
        }
        else if (dependency.FactoryFunc != null)
        {
            object parameterInstance = dependency.FactoryFunc(this);

            return parameterInstance;
        }
        else
        {
            throw new InvalidOperationException("Dependency is not in a valid state.");
        }
    }

    private void PopulateInjectableFields(Type type, object instance)
    {
        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

        if (fields.Length == 0)
        {
            return;
        }

        List<FieldInfo> injectableFields = fields
            .Where(f => f.GetCustomAttribute<InjectAttribute>() != null)
            .ToList();

        foreach (FieldInfo field in injectableFields)
        {
            Type fieldType = field.FieldType;

            object fieldValue = Create(fieldType);

            field.SetValue(instance, fieldValue);
        }
    }
}
