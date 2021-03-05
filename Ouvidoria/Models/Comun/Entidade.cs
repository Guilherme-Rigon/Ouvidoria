using System;

namespace Ouvidoria.Models.Comun
{
    public class Entidade
    {
        public Entidade()
        {
            CadastradoEm = DateTime.Now;
            AtualizadoEm = DateTime.Now;
        }
        public DateTime CadastradoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
