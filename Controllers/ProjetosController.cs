using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPortifolio.Data;
using ProjetoPortifolio.Models;


namespace ProjetoPortifolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjetosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CriarProjeto(Projeto projeto)
        {
            var novoProjeto = new Projeto
            {
                NomeAluno = projeto.NomeAluno,
                Titulo = projeto.Titulo,
                Descricao = projeto.Descricao,
                TecnologiaUtilizada = projeto.TecnologiaUtilizada,
                LinkAcesso = projeto.LinkAcesso,
                Imagem = projeto.Imagem,
                Video = projeto.Video,
                AlunoId = projeto.AlunoId
            };

            _context.Projetos.Add(novoProjeto);
            await _context.SaveChangesAsync();

            return Ok("Projeto criado com sucesso!");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> GetProjetos()
        {
            var listaProjetos = await _context.Projetos.Select(p => new Projeto
            {
                Id = p.Id,
                NomeAluno = p.NomeAluno,
                Titulo = p.Titulo,
                Descricao = p.Descricao,
                TecnologiaUtilizada = p.TecnologiaUtilizada,
                LinkAcesso = p.LinkAcesso,
                Imagem = p.Imagem,
                Video = p.Video,
                AlunoId = p.AlunoId
            }).ToListAsync();

            return Ok(listaProjetos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProjeto(int id, Projeto projeto)
        {
            var projetoExistente = await _context.Projetos.FindAsync(id);
            if (projetoExistente == null)
            {
                return NotFound();
            }

            projetoExistente.NomeAluno = projeto.NomeAluno;
            projetoExistente.Titulo = projeto.Titulo;
            projetoExistente.Descricao = projeto.Descricao;
            projetoExistente.TecnologiaUtilizada = projeto.TecnologiaUtilizada;
            projetoExistente.LinkAcesso = projeto.LinkAcesso;
            projetoExistente.Imagem = projeto.Imagem;
            projetoExistente.Video = projeto.Video;
            projetoExistente.AlunoId = projeto.AlunoId;

            await _context.SaveChangesAsync();

            return Ok("Projeto atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirProjeto(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }

            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();

            return Ok("Projeto excluído com sucesso!");
        }
    }
}