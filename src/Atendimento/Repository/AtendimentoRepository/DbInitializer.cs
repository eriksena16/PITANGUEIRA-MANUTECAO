using Pitangueira.Model.Entities;
using Pitangueira.Repository.AtendimentoRepository;
using System.Linq;

namespace Repository.AtendimentoRepository
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Cliente.Any())
            {
                return;
            }

            var clientes = new Cliente[]
            {
                new Cliente{Name ="Erik Sena"},
                new Cliente{Name ="WTF"}
            };
            foreach (var obj in clientes)
            {
                context.Cliente.Add(obj);
            }
            context.SaveChanges();

            var users = new ApplicationUser[]
            {
                new ApplicationUser{Name = "Gestor", UserName ="gestor", Email="gestor@pitanga.com", EmailConfirmed = true, PasswordHash = "Tacanha12@"},
                new ApplicationUser{Name = "Tecnico", UserName ="tecnico", Email="tecnico@pitanga.com", EmailConfirmed = true, PasswordHash = "Tacanha12@"}
            };

            foreach (var obj in users)
            {
                context.Usuario.Add(obj);
            }
            context.SaveChanges();


        }


    }
}
