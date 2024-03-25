using Microsoft.Extensions.DependencyInjection;

namespace AngularApex.API.Extensions
{
    public static partial class AddDependencies
    {
        public static IServiceCollection Dependencies(this IServiceCollection services)
        {
            return services;
        }
    }
}
