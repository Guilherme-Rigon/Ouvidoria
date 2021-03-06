using System.ComponentModel.DataAnnotations;

namespace Ouvidoria.Models.ViewModels
{
    public class EnviarRespostaViewModel
    {
        [Required]
        [Display(Name = "Protocolo")]
        public long ManifestacaoId { get; set; }
        public string Nome { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Campus { get; set; }
        [Display(Name = "Curso (Opcional)")]
        public string Curso { get; set; }
        public string Assunto { get; set; }
        public string Detalhe { get; set; }
        public Resposta Resposta { get; set; }
        public Setor Setor { get; set; }
        public TipoSolicitacao TipoSolicitacao { get; set; }
        public Perfil Perfil { get; set; }
        [Display(Name = "Enviar Cc ao Setor mencionado?")]
        public bool EnviarCcAoSetor { get; set; }
    }
}
