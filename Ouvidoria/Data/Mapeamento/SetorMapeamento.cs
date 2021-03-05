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

            //Seeds

            builder.HasData(
                new Setor { SetorId = 1, Nome = "Biblioteca", Email = "biblioteca@gmail.com" },
                new Setor { SetorId = 2, Nome = "Centro de Atendimento", Email = "centroatendimento@gmail.com" },
                new Setor { SetorId = 3, Nome = "Financeiro", Email = "financeiro@gmail.com"}
                );
        }
    }
}
