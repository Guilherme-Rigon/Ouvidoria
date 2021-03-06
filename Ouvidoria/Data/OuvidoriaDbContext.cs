using Microsoft.EntityFrameworkCore;
using Ouvidoria.Data.Mapeamento;
using Ouvidoria.Data.Semeador;
using Ouvidoria.Models;

namespace Ouvidoria.Data
{
    public class OuvidoriaDbContext : DbContext
    {
        public OuvidoriaDbContext(DbContextOptions<OuvidoriaDbContext> options) : base(options)
        {
        }
        public DbSet<Manifestacao> Manifestacoes { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<TipoSolicitacao> TiposSolicitacao { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PerfilMapeamento).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TipoSolicitacaoMapeamento).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SetorMapeamento).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ManifestacaoMapeamento).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RespostaMapeamento).Assembly);
            modelBuilder.InicializarTabelas();
        }
    }
}
