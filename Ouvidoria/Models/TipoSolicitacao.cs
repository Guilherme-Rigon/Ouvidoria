using Ouvidoria.Models.Comun;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ouvidoria.Models
{
    public class TipoSolicitacao : Entidade
    {
        [Key]
        public long TipoSolicitacaoId { get; set; }
        [Required]
        public string Nome { get; set; }
        public ICollection<Manifestacao> Manifestacoes { get; set; }
    }
}
