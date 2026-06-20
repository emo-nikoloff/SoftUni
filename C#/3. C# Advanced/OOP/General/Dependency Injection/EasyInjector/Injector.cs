namespace EasyInjector;

public static class Injector
{
    public static DependencyProvider Register<TAbstractType, TImplementationType>()
        where TImplementationType : class, TAbstractType
    {
        DependencyProvider dependencyProvider = new();

        dependencyProvider.Register<TAbstractType, TImplementationType>();

        return dependencyProvider;
    }

    public static DependencyProvider Register<TAbstractType>(object implementationInstance)
        where TAbstractType : class
    {
        DependencyProvider dependencyProvider = new();

        dependencyProvider.Register<TAbstractType>(implementationInstance);

        return dependencyProvider;
    }

    public static DependencyProvider Register<TAbstractType, TImplementationType>(Func<DependencyProvider, TImplementationType> factoryFunc)
        where TImplementationType : class, TAbstractType
    {
        DependencyProvider dependencyProvider = new();

        dependencyProvider.Register<TAbstractType, TImplementationType>(factoryFunc);

        return dependencyProvider;
    }
}
