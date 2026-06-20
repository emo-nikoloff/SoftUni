namespace EasyInjector;

internal class Dependency
{
    public Dependency(Type type)
    {
        if (type == null)
        {
            throw new ArgumentException("Type cannot be null.");
        }

        Type = type;
    }

    public Dependency(object instance)
    {
        if (instance == null)
        {
            throw new ArgumentException("Instance cannot be null.");
        }

        Instance = instance;
    }

    public Dependency(Func<DependencyProvider, object> factoryFunc)
    {
        if (factoryFunc == null)
        {
            throw new ArgumentException("Factory function cannot be null.");
        }

        FactoryFunc = factoryFunc;
    }

    public Type Type { get; private set; }

    public object Instance { get; private set; }

    public Func<DependencyProvider, object> FactoryFunc { get; private set; }
}
