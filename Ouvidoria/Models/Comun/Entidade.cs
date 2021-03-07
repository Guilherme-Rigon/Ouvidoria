using System;
using System.ComponentModel.DataAnnotations;

namespace Ouvidoria.Models.Comun
{
    public class Entidade
    {
        public Entidade()
        {
            CadastradoEm = DateTime.Now;
            AtualizadoEm = DateTime.Now;
        }
        [Display(Name = "Cadastrado Em")]
        public DateTime CadastradoEm { get; set; }
        [Display(Name = "Atualizado Em")]
        public DateTime AtualizadoEm { get; set; }
    }
}
