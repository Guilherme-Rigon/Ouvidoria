using Ouvidoria.Models.Comun;
using System.ComponentModel.DataAnnotations;

namespace Ouvidoria.Models
{
    public class Resposta : Entidade
    {
        [Key]
        public long RespostaId { get; set; }
        public long ManifestacaoId { get; set; }
        public virtual Manifestacao Manifestacao { get; set; }
        public string CaminhoAnexo { get; set; }
        public string ContentType { get; set; }
        [MaxLength(600, ErrorMessage = "O conteudo da resposta deve ter no máximo 600 caracteres.")]
        public string Conteudo { get; set; }
    }
}
