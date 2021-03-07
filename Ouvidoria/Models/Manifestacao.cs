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
        [MaxLength(100, ErrorMessage = "O nome deve conter menos de 100 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Digite um endereço de E-mail válido.")]
        [MaxLength(200, ErrorMessage = "O e-mail deve conter menos de 200 caracteres.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [MinLength(10, ErrorMessage = "Deve ser informado o DDD + Número Fixo. Ex: (99)9999-9999")]
        [MaxLength(20, ErrorMessage = "Informe um número de telefone válido.")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "O campo Celular é obrigatório.")]
        [MinLength(11, ErrorMessage = "Deve ser informado o DDD + Número Móvel. Ex (99)99999-9999")]
        [MaxLength(20, ErrorMessage = "Informe um número de telefone válido.")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "É necessário informar o campus do manifestante.")]
        [MinLength(6, ErrorMessage = "O campus deve conter no minímo 6 caracteres. EX: UGB-VR")]
        [MaxLength(20, ErrorMessage = "O nome do campus deve conter menos de 20 caracteres.")]
        public string Campus { get; set; }
        [Display(Name = "Curso (Opcional)")]
        [MaxLength(100, ErrorMessage = "O nome do curso deve conter menos de 100 caracteres.")]
        public string Curso { get; set; }
        [Required(ErrorMessage = "É de EXTREMA importância que o assunto da manifestação seja informado.")]
        [MaxLength(100, ErrorMessage = "O assunto deve conter no máximo 100 caracteres.")]
        public string Assunto { get; set; }
        [Required(ErrorMessage = "É de EXTREMA importãncia que seja fornecido o maior número possível de detalhes sobre o motivo da manifestação (Limite de 400 caracteres).")]
        [MaxLength(200, ErrorMessage = "Tente explicar em menos de 200 caracteres.")]
        public string Detalhe { get; set; }
        public Resposta Resposta { get; set; }
    }
}
