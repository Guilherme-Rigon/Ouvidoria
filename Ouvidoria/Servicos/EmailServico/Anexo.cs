using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Ouvidoria.Servicos.EmailServico
{
    public class Anexo
    {
        public Anexo(string nomeUnico ,string caminho, string contentType)
        {
            NomeUnico = nomeUnico;
            Caminho = caminho;
            ContentType = new ContentType(contentType);
        }
        public string NomeUnico { get; set; }
        public string Caminho { get; set; }
        public ContentType ContentType { get; set; }
    }
}
