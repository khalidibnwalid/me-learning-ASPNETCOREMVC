using Microsoft.Extensions.Configuration;
using WebApplication1.Models;
using WebApplication1.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddModelsServices(this IServiceCollection services)
    {
        services.AddScoped<PostsService>();
        //services.AddScoped<IMyDependency2, MyDependency2>();

        return services;
    }
}