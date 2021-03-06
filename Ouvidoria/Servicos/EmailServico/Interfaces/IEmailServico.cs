using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Ouvidoria.Servicos.EmailServico.Interfaces
{
    public interface IEmailServico
    {
        Task<bool> EnviarEmailAsync(string email, string assunto, string mensagem, string emailCc = null, Anexo anexo = null);
    }
}
