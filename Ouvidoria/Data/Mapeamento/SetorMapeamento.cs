using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ouvidoria.Data.Mapeamento.Comun;
using Ouvidoria.Models;

namespace Ouvidoria.Data.Mapeamento
{
    public class SetorMapeamento : MapeamentoBase<Setor>
    {
        public override void Configure(EntityTypeBuilder<Setor> builder)
        {
            base.Configure(builder);
            builder.HasKey(s => s.SetorId);
            builder.Property(s => s.Nome).HasColumnType("varchar").HasMaxLength(200);
            builder.Property(s => s.Email).HasColumnType("varchar").HasMaxLength(200);
        }
    }
}
