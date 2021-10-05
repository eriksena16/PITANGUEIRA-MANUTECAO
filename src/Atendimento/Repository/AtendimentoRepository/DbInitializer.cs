using Pitangueira.Model.Entities;
using Pitangueira.Model.Entities.Enums;
using Pitangueira.Model.Entities.Utils;
using Pitangueira.Repository.AtendimentoRepository;
using System.Linq;

namespace Repository.AtendimentoRepository
{
    public class DbInitializer
    {
        public static void Initialize(PitangaDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Cliente.Any())
            {
                return;
            }

            var clientes = new Cliente[]
            {
                new Cliente{Name ="Tel"},
                new Cliente{Name ="WTF"},
                new Cliente{Name ="Siclos"},
                new Cliente{Name ="Catedra"},
                new Cliente{Name ="Drummond"}

            };
            foreach (var obj in clientes)
            {
                context.Cliente.Add(obj);
            }
            context.SaveChanges();

            var tipoAtendimentos = new TipoAtendimento[]
            {
                new TipoAtendimento{Name ="Manutenção de Computadores"},
                new TipoAtendimento{Name ="Suporte Pacote Office"},
                new TipoAtendimento{Name ="Cabeamento de Rede"},
                new TipoAtendimento{Name ="Implantação de sistema CFTV"},
                

            };
            foreach (var obj in tipoAtendimentos)
            {
                context.TipoAtendimento.Add(obj);
            }

            context.SaveChanges();


            var users = new Usuario[]
            {
                new Usuario{Nome = "Gestor", UserName ="gestor", TipoUsuario = TipoUsuario.Gestor, Senha = Hash.GerarHash("Pitanga12@")},
                new Usuario{Nome = "Tecnico", UserName ="tecnico", TipoUsuario = TipoUsuario.Tecnico, Senha = Hash.GerarHash("Pitanga16@") }
            };

            foreach (var obj in users)
            {
                context.Usuario.Add(obj);
            }
            context.SaveChanges();


        }


    }
}
