using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPortifolio.Data;
using ProjetoPortifolio.Models;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuariosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CriarUsuario(Usuario novoUsuario)
    {
        novoUsuario.CreatedAt = DateTime.UtcNow;

        _context.Usuarios.Add(novoUsuario);
        await _context.SaveChangesAsync();

        return Ok(novoUsuario);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsuarios()
    {
        var usuarios = await _context.Usuarios.ToListAsync();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsuarioPorId(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        if (usuario == null)
            return NotFound("Usuário não encontrado.");

        return Ok(usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarUsuario(int id, Usuario usuarioAtualizado)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        if (usuario == null)
            return NotFound("Usuário não encontrado.");

        usuario.Nome = usuarioAtualizado.Nome;
        usuario.Username = usuarioAtualizado.Username;
        usuario.password = usuarioAtualizado.password;

        await _context.SaveChangesAsync();

        return Ok(usuario);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirUsuario(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        if (usuario == null)
            return NotFound("Usuário não encontrado.");

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return Ok("Usuário excluído com sucesso!");
    }
}
    
   
