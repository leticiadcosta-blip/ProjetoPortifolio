using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPortifolio.Data; 
using ProjetoPortifolio.Models; 

namespace ProjetoPortifolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TurmasController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]


        public async Task<IActionResult> CriarTurmas(Turma Turma)
        {
            var novaTurma = new Turma
            {
                Alunos = Turma.Alunos,
                Professor = Turma.Professor,
                Projetos = Turma.Projetos,
                AlunoId = Turma.AlunoId
            };


            _context.Turmas.Add(novaTurma);
            await _context.SaveChangesAsync();


            return Ok("Turma criada com sucesso!");
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurmas(Turma Turma)
        {
            var ListaTurmas = await _context.Turmas.Select(a => new Turma
            {
                Alunos = Turma.Alunos,
                Professor = Turma.Professor,
                Projetos = Turma.Projetos,
            }).ToListAsync();
            return Ok(ListaTurmas);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarTurma(int id, Turma Turma)
        {
            var turma = await _context.Turmas.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }


            turma.Alunos = Turma.Alunos;
            turma.Professor = Turma.Professor;
            turma.Projetos = Turma.Projetos;


            await _context.SaveChangesAsync();


            return Ok("Turma atualizada com sucesso!");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirTurma(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }


            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();


            return Ok("Turma excluída com sucesso!");
        }
    }


    }