using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ouvidoria.Data.Mapeamento.Comun;
using Ouvidoria.Models;

namespace Ouvidoria.Data.Mapeamento
{
    public class PerfilMapeamento : MapeamentoBase<Perfil>
    {
        public override void Configure(EntityTypeBuilder<Perfil> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => p.PerfilId);
            builder.Property(p => p.Nome).HasColumnType("varchar").HasMaxLength(200);
        }
    }
}
