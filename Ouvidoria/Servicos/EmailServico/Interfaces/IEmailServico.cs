using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Ouvidoria.Servicos.EmailServico.Interfaces
{
    public interface IEmailServico
    {
        Task<bool> EnviarEmailAsync(IList<string> emails, string assunto, string mensagem, Anexo anexo = null);
    }
}
