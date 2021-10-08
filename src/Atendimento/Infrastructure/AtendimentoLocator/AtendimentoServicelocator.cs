using Microsoft.Extensions.DependencyInjection;
using Pitangueira.Contract.AtendimentoContract;
using Pitangueira.Service.AtendimentoServices;

namespace Pitangueira.Infrastructure.AtendimentoLocator
{
    public static class AtendimentoServiceLocator
    {
        public static void ConfigureAtendimentoService(this IServiceCollection services)
        {
            services.AddScoped<IAtendimentoService, AtendimentoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

        }
    }
}
