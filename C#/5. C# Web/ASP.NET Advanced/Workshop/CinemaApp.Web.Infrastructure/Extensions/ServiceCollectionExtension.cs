using System.Reflection;
using CinemaApp.Data.Repository.Common;
using CinemaApp.Data.Repository.Contracts.Common;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaApp.Web.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterRepositoriesFromAssembly(this IServiceCollection serviceCollection, Assembly repositoryAssembly)
    {
        IEnumerable<Type> repositoryTypes = repositoryAssembly.GetTypes()
            .Where(t => t.BaseType != null &&
                t.BaseType.IsGenericType &&
                t.IsAbstract == false &&
                (t.BaseType.GetGenericTypeDefinition() == typeof(BaseRepository<>) ||
                t.BaseType.GetGenericTypeDefinition() == typeof(BaseSoftDeletableRepository<>)))
            .ToArray();

        foreach (Type repositoryType in repositoryTypes)
        {
            Type? interfaceType = repositoryType.GetInterfaces()
                .SingleOrDefault(it => !it.IsGenericType &&
                    it.GetInterfaces().Any(bit => bit.IsGenericType &&
                        (bit.GetGenericTypeDefinition() == typeof(IRepository<>) ||
                        bit.GetGenericTypeDefinition() == typeof(ISoftDeletableRepository<>))));

            if (interfaceType != null)
            {
                serviceCollection.AddScoped(interfaceType, repositoryType);
            }
        }

        return serviceCollection;
    }
}
