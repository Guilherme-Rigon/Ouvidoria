using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ouvidoria.Data;
using Ouvidoria.Models;
using Ouvidoria.Models.ViewModels;
using Ouvidoria.Servicos.EmailServico;
using Ouvidoria.Servicos.EmailServico.Interfaces;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Ouvidoria.Controllers
{
    public class ManifestacaoController : Controller
    {
        private readonly OuvidoriaDbContext _context;
        private readonly IEmailServico _emailServico;
        public ManifestacaoController(OuvidoriaDbContext context, IEmailServico emailServico)
        {
            _context = context;
            _emailServico = emailServico;
        }
        public IActionResult Index()
        {
            return View(_context.Manifestacoes.Include(s => s.Setor).AsNoTracking().ToList());
        }

        [HttpGet]
        public IActionResult EnviarResposta(long id)
        {
            if(id != 0)
            {
                return View(_context.Manifestacoes.Include(s => s.Setor).Include(t => t.TipoSolicitacao)
                    .Include(p => p.Perfil).AsNoTracking().Where(x => x.ManifestacaoId == id)
                    .Select(m => new EnviarRespostaViewModel 
                    { 
                        ManifestacaoId = m.ManifestacaoId,
                        Nome = m.Nome,
                        Email = m.Email,
                        Telefone = m.Telefone,
                        Celular = m.Celular,
                        Assunto = m.Assunto,
                        Campus = m.Campus,
                        Curso = m.Curso,
                        Detalhe = m.Detalhe,
                        Setor = m.Setor,
                        Perfil = m.Perfil,
                        TipoSolicitacao = m.TipoSolicitacao
                    }).FirstOrDefault());
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> EnviarResposta(EnviarRespostaViewModel model, IFormFile anexo)
        {
            if (ModelState.IsValid)
            {
                bool temAnexo = anexo?.Length > 0;
                Anexo anexoEmail = null;
                if (temAnexo)
                {
                    var caminho = Path.Combine("Data", "Anexos", anexo.FileName);
                    using (var stream = System.IO.File.Create(caminho))
                    {
                        await anexo.CopyToAsync(stream);
                    }

                    anexoEmail = new Anexo(caminho, anexo.ContentType);
                    model.Resposta.CaminhoAnexo = caminho;
                    model.Resposta.ContentType = anexo.ContentType;
                }
                if (await _emailServico.EnviarEmailAsync(model.Email, model.Assunto, model.Resposta.Conteudo,
                    model.EnviarCcAoSetor? model.Setor.Email : null,
                    temAnexo? anexoEmail : null))
                {
                    model.Resposta.ManifestacaoId = model.ManifestacaoId;
                    _context.Respostas.Add(model.Resposta);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Encaminhar(long id)
        {
            return View(_context.Manifestacoes.AsNoTracking().FirstOrDefault(x => x.ManifestacaoId == id));
        }
        [HttpPost]
        public async Task<IActionResult> Encaminhar(Manifestacao model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Deletar(long id)
        {
            return View(_context.Manifestacoes.AsNoTracking().FirstOrDefault(x => x.ManifestacaoId == id));
        }
        [HttpPost]
        public async Task<IActionResult> Deletar(Manifestacao model)
        {
            if (ModelState.IsValid)
            {
                _context.Manifestacoes.Remove(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
