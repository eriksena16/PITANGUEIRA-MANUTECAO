using Microsoft.Extensions.DependencyInjection;
using Pitangueira.Contract.GatewayContract;
using Pitangueira.Gateway.Service.GatewayService;

namespace Pitangueira.Gateway.Infrastructure.GatewayLocator
{
    public static class GatewayServiceLocator
    {
        public static void ConfigureGatewayService(this IServiceCollection services)
        {
            services.AddScoped<IGatewayServiceProvider, GatewayServiceProvider>();
        }
    }
}
