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
        public string Conteudo { get; set; }
    }
}
