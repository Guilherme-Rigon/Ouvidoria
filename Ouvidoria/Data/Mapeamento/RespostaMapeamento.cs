using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ouvidoria.Data.Mapeamento.Comun;
using Ouvidoria.Models;

namespace Ouvidoria.Data.Mapeamento
{
    public class RespostaMapeamento : MapeamentoBase<Resposta>
    {
        public override void Configure(EntityTypeBuilder<Resposta> builder)
        {
            base.Configure(builder);
            builder.HasKey(r => r.RespostaId);

            builder.HasOne(r => r.Manifestacao).WithOne(m => m.Resposta).HasForeignKey<Resposta>(r => r.ManifestacaoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(r => r.Conteudo).HasColumnType("varchar").HasMaxLength(200);
            builder.Property(r => r.CaminhoAnexo).IsRequired(false);
            builder.Property(r => r.ContentType).HasColumnType("varchar").HasMaxLength(100).IsRequired(false);
        }
    }
}
