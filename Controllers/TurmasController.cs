using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPortifolio.Data;

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
    }
}
