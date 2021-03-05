using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ouvidoria.Models.Comun;

namespace Ouvidoria.Data.Mapeamento.Comun
{
    public class MapeamentoBase<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entidade
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.AtualizadoEm).ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.CadastradoEm).ValueGeneratedOnAdd();
        }
    }
}
