using Microsoft.Extensions.DependencyInjection;
using Pitangueira.Contract.AtendimentoContract;
using Pitangueira.Service.AtendimentoServices;

namespace Pitangueira.Infrastructure.AtendimentoLocator
{
    public static class AtendimentoServicelocator
    {
        public static void ConfigureAtendimentoService(this IServiceCollection services)
        {
            services.AddScoped<IAtendimentoService, AtendimentoService>();
            services.AddScoped<IClienteService, ClienteService>();
            //services.AddScoped<IModeloDeEquipamentoService, ModeloDeEquipamentoService>();
            //services.AddScoped<ISetorService, SetorService>();
            //services.AddScoped<IFabricanteService, FabricanteService>();
            //services.AddScoped<IEquipamentoService, EquipamentoService>();

        }
    }
}
