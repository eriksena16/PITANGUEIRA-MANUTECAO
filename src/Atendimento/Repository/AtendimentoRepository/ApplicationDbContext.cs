using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pitangueira.Model.Entities;

namespace Pitangueira.Repository.AtendimentoRepository
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Atendimento> Atendimento { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ApplicationUser> Tecnico { get; set; }
    }
}
