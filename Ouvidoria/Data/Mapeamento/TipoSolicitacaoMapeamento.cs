using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ouvidoria.Data.Mapeamento.Comun;
using Ouvidoria.Models;

namespace Ouvidoria.Data.Mapeamento
{
    public class TipoSolicitacaoMapeamento : MapeamentoBase<TipoSolicitacao>
    {
        public override void Configure(EntityTypeBuilder<TipoSolicitacao> builder)
        {
            base.Configure(builder);
            builder.HasKey(t => t.TipoSolicitacaoId);
            builder.Property(t => t.Nome).HasColumnType("varchar").HasMaxLength(200);

            //Seeds

            builder.HasData(
                new TipoSolicitacao { TipoSolicitacaoId = 1, Nome = "Elogio" },
                new TipoSolicitacao { TipoSolicitacaoId = 2, Nome = "Reclamação" },
                new TipoSolicitacao { TipoSolicitacaoId = 3, Nome = "Sugestão" },
                new TipoSolicitacao { TipoSolicitacaoId = 4, Nome = "Outro" }
                );
        }
    }
}
