using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ouvidoria.Data.Mapeamento.Comun;
using Ouvidoria.Models;

namespace Ouvidoria.Data.Mapeamento
{
    public class ManifestacaoMapeamento : MapeamentoBase<Manifestacao>
    {
        public override void Configure(EntityTypeBuilder<Manifestacao> builder)
        {
            base.Configure(builder);
            builder.HasKey(m => m.ManifestacaoId);

            builder.HasOne(m => m.Perfil).WithMany(p => p.Manifestacoes).HasForeignKey(m => m.PerfilId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(m => m.TipoSolicitacao).WithMany(t => t.Manifestacoes).HasForeignKey(m => m.TipoSolicitacaoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(m => m.Setor).WithMany(s => s.Manifestacoes).HasForeignKey(m => m.SetorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Nome).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(m => m.Email).HasColumnType("varchar").HasMaxLength(200);
            builder.Property(m => m.Telefone).HasColumnType("varchar").HasMaxLength(20);
            builder.Property(m => m.Celular).HasColumnType("varchar").HasMaxLength(20);
            builder.Property(m => m.Campus).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(m => m.Curso).HasColumnType("varchar").HasMaxLength(100).IsRequired(false);
            builder.Property(m => m.Assunto).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(m => m.Detalhe).HasColumnType("varchar").HasMaxLength(200);
        }
    }
}
