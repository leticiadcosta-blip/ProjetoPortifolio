using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPortifolio.Data;

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
    }
}
