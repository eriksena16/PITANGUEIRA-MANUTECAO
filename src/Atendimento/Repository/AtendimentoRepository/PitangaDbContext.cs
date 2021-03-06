using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pitangueira.Model.Entities;

namespace Pitangueira.Repository.AtendimentoRepository
{
    public class PitangaDbContext : DbContext
    {
        public PitangaDbContext(DbContextOptions<PitangaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Atendimento_> Atendimento { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoAtendimento> TipoAtendimento { get; set; }
    }
}
