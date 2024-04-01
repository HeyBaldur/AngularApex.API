using AngularApex.Services.Interfaces;
using AngularApex.Services.JWT;
using AngularApex.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AngularApex.API.Extensions
{
    /// <summary>
    /// Dependencies
    /// </summary>
    public static partial class AddDependencies
    {
        /// <summary>
        /// Services dependencies
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection Dependencies(this IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IAccount, AccountService>();
            return services;
        }
    }
}
