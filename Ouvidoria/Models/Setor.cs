using Ouvidoria.Models.Comun;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ouvidoria.Models
{
    public class Setor : Entidade
    {
        [Key]
        public long SetorId { get; set; }
        [Required]
        [Display(Name = "Setor")]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email do Setor")]
        public string Email { get; set; }
        public ICollection<Manifestacao> Manifestacoes { get; set; }
    }
}
