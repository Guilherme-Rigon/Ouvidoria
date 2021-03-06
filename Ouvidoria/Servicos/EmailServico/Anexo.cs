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
        public Anexo(string caminho, string contentType)
        {
            Caminho = caminho;
            ContentType = new ContentType(contentType);
        }
        public string Caminho { get; set; }
        public ContentType ContentType { get; set; }
    }
}
