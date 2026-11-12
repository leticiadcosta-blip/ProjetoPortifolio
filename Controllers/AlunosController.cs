using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPortifolio.Data;
using ProjetoPortifolio.Models;

namespace ProjetoPortifolio.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class AlunosController : ControllerBase
        {
            private readonly AppDbContext _context;

            public AlunosController(AppDbContext context)
            {
                _context = context;
            }

            [HttpPost]
            public async Task<IActionResult> CriarAluno(Aluno aluno)
            {
                var novoAluno = new Aluno
                {
                    Nome = aluno.Nome,
                    Email = aluno.Email,
                    turma = aluno.turma,
                    Professor = aluno.Professor
                };

                _context.Alunos.Add(novoAluno);
                await _context.SaveChangesAsync();

                return Ok("Aluno criado com sucesso!");
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
            {
                var listaAlunos = await _context.Alunos.Select(a => new Aluno
                {
                    Id = a.Id,
                    Nome = a.Nome,
                    Email = a.Email,
                    turma = a.turma,
                    Professor = a.Professor
                }).ToListAsync();

                return Ok(listaAlunos);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> AtualizarAluno(int id, Aluno aluno)
            {
                var alunoExistente = await _context.Alunos.FindAsync(id);
                if (alunoExistente == null)
                {
                    return NotFound();
                }

                alunoExistente.Nome = aluno.Nome;
                alunoExistente.Email = aluno.Email;
                alunoExistente.turma = aluno.turma;
                alunoExistente.Professor = aluno.Professor;

                await _context.SaveChangesAsync();

                return Ok("Aluno atualizado com sucesso!");
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> ExcluirAluno(int id)
            {
                var aluno = await _context.Alunos.FindAsync(id);
                if (aluno == null)
                {
                    return NotFound();
                }

                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();

                return Ok("Aluno excluído com sucesso!");
            }
        }
    }
