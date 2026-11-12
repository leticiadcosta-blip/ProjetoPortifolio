using Microsoft.EntityFrameworkCore;
using ProjetoPortifolio.Models;

namespace ProjetoPortifolio.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
    }
}

