using Ouvidoria.Models.Comun;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ouvidoria.Models
{
    public class Manifestacao : Entidade
    {
        [Key]
        [Display(Name = "Protocolo")]
        public long ManifestacaoId { get; set; }
        public long PerfilId { get; set; }
        public virtual Perfil Perfil { get; set; }
        public long TipoSolicitacaoId { get; set; }
        public virtual TipoSolicitacao TipoSolicitacao { get; set; }
        public long SetorId { get; set; }
        public virtual Setor Setor { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Digite um endereço de E-mail válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [MinLength(10, ErrorMessage = "Deve ser informado o DDD + Número Fixo. Ex: (99)9999-9999")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "O campo Celular é obrigatório.")]
        [MinLength(11, ErrorMessage = "Deve ser informado o DDD + Número Móvel. Ex (99)99999-9999")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "É necessário informar o campus do manifestante.")]
        [MinLength(6, ErrorMessage = "O campus deve conter no minímo 6 caracteres. EX: UGB-VR")]
        public string Campus { get; set; }
        [Display(Name = "Curso (Opcional)")]
        public string Curso { get; set; }
        [Required(ErrorMessage = "É de EXTREMA importância que o assunto da manifestação seja informado.")]
        [MaxLength(100, ErrorMessage = "O assunto deve conter no máximo 100 caracteres.")]
        public string Assunto { get; set; }
        [Required(ErrorMessage = "É de EXTREMA importãncia que seja fornecido o maior número possível de detalhes sobre o motivo da manifestação.")]
        public string Detalhe { get; set; }
        public ICollection<Resposta> Respostas { get; set; }
    }
}
