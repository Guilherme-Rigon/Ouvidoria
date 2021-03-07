using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ouvidoria.Data;
using Ouvidoria.Models;
using Ouvidoria.Models.ViewModels;
using Ouvidoria.Servicos.EmailServico;
using Ouvidoria.Servicos.EmailServico.Interfaces;
using System;
using System.Collections.Generic;
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
        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Manifestacoes.Include(s => s.Setor).Include(r => r.Resposta).AsNoTracking()
                .OrderBy(x => x.Resposta == null).ToList());
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.PerfilId = CarregarPerfis();
            ViewBag.TipoSolicitacaoId = CarregarTipos();
            ViewBag.SetorId = CarregarSetores();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(Manifestacao model)
        {
            if (ModelState.IsValid)
            {
                _context.Manifestacoes.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.PerfilId = CarregarPerfis();
            ViewBag.TipoSolicitacaoId = CarregarTipos();
            ViewBag.SetorId = CarregarSetores();
            return View(model);
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
                    anexoEmail = SalvarArquivo(anexo);
                    model.Resposta.CaminhoAnexo = anexoEmail.NomeUnico;
                    model.Resposta.ContentType = anexo.ContentType;
                }

                var emails = model.EmailsIncluidos().ToArray();
                if (await _emailServico.EnviarEmailAsync(model.Assunto, model.Resposta.Conteudo,
                    temAnexo? anexoEmail : null, emails))
                {
                    model.Resposta.ManifestacaoId = model.ManifestacaoId;
                    _context.Respostas.Add(model.Resposta);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    if (emails.Length == 0)
                        ViewData["EmailDestinatarioErro"] = "Deve haver ao menos um destinatário incluido na resposta.";
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Encaminhar(long id)
        {
            var model = _context.Manifestacoes.Include(x => x.Perfil).Include(x => x.Resposta).Include(x => x.TipoSolicitacao)
                .Include(x => x.Setor).Where(x => x.ManifestacaoId == id).AsNoTracking().FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Encaminhar(Manifestacao model, IFormFile anexo)
        {
            if (ModelState.IsValid)
            {
                var temAnexo = anexo?.Length > 0;
                Anexo anexoEmail = null;
                if (temAnexo)
                {
                    anexoEmail = SalvarArquivo(anexo);
                    model.Resposta.CaminhoAnexo = anexoEmail.NomeUnico;
                    model.Resposta.ContentType = anexo.ContentType;
                }
                
                if (await _emailServico.EnviarEmailAsync(model.Assunto, model.Resposta.Conteudo,
                    temAnexo ? anexoEmail : null, model.Setor.Email))
                {
                    model.Resposta.Conteudo = model.Resposta.Conteudo;
                    _context.Manifestacoes.Update(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(VizualizarResposta), new { id = model.ManifestacaoId });
                }
                else
                {
                    return BadRequest();
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Deletar(long id)
        {
            var model = _context.Manifestacoes.Include(x => x.Resposta)
                .AsNoTracking().FirstOrDefault(x => x.ManifestacaoId == id);
            if(model.Resposta == null)
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Deletar(Manifestacao model)
        {
            if (_context.Respostas.AsNoTracking().Where(x => x.ManifestacaoId == model.ManifestacaoId).Count() == 0)
            {
                _context.Manifestacoes.Remove(_context.Manifestacoes.Find(model.ManifestacaoId));
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult VizualizarResposta(long id)
        {
            return View(_context.Respostas.Include(m => m.Manifestacao).ThenInclude(t => t.TipoSolicitacao)
                .Include(x => x.Manifestacao).ThenInclude(x => x.Setor)
                .Where(x => x.ManifestacaoId == id)
                .AsNoTracking().FirstOrDefault());
        }
        private IList<SelectListItem> CarregarPerfis()
        {
            return _context.Perfis.AsNoTracking().Select(p => new SelectListItem
            {
                Value = p.PerfilId.ToString(),
                Text = p.Nome
            }).ToList();
        }
        private IList<SelectListItem> CarregarTipos()
        {
            return _context.TiposSolicitacao.AsNoTracking().Select(t => new SelectListItem
            {
                Value = t.TipoSolicitacaoId.ToString(),
                Text = t.Nome
            }).ToList();
        }
        private IList<SelectListItem> CarregarSetores()
        {
            return _context.Setores.AsNoTracking().Select(s => new SelectListItem
            {
                Value = s.SetorId.ToString(),
                Text = s.Nome
            }).ToList();
        }
        private static Anexo SalvarArquivo(IFormFile arquivo)
        {
            string nomeUnico = Guid.NewGuid().ToString() + Path.GetExtension(arquivo.FileName);
            var caminho = Path.Combine("wwwroot", "Anexos", nomeUnico);
            Anexo anexo = new Anexo(nomeUnico, caminho, arquivo.ContentType);

            using (var stream = System.IO.File.Create(caminho))
            {
                arquivo.CopyTo(stream);
            }

            return anexo;
        }
    }
}
