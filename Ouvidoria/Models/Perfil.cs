using Ouvidoria.Models.Comun;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ouvidoria.Models
{
    public class Perfil : Entidade
    {
        [Key]
        public long PerfilId { get; set; }
        [Required]
        [Display(Name = "Perfil")]
        public string Nome { get; set; }
        public ICollection<Manifestacao> Manifestacoes { get; set; }
    }
}
