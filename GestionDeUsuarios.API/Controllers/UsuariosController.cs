using GestionDeUsuarios.Business.Services;
using GestionDeUsuarios.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeUsuarios.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/usuarios
        [HttpGet]
        [Route("ListaUsuarios")]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();
            return Ok(usuarios);
        }

        // GET: api/usuarios/{username}
        [HttpGet]
        [Route("ObtenerUsuario")]
        public async Task<IActionResult> GetUsuario(string username)
        {
            var usuario = await _usuarioService.GetUsuarioByUsernameAsync(username);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // POST: api/usuarios
        [HttpPost]
        [Route("CrearUsuario")]
        public async Task<IActionResult> CreateUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("El objeto usuario no puede ser nulo.");
            }

            // Se pueden asignar valores por defecto o validar aquí si es necesario
            usuario.CreatedAt = DateTime.UtcNow;
            usuario.UpdatedAt = DateTime.UtcNow;

            var createdUsuario = await _usuarioService.CreateUsuarioAsync(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { username = createdUsuario.Username }, createdUsuario);
        }

        // PUT: api/usuarios
        [HttpPut]
        [Route("ActualizarUsuario")]
        public async Task<IActionResult> UpdateUsuario(string username, [FromBody] Usuario usuario)
        {
            if (usuario == null || username != usuario.Username)
            {
                return BadRequest("La información del usuario no coincide.");
            }

            var usuarioExistente = await _usuarioService.GetUsuarioByUsernameAsync(username);
            if (usuarioExistente == null)
            {
                return NotFound();
            }

            // Actualizar los campos necesarios
            usuarioExistente.TotalAsignados = usuario.TotalAsignados;
            usuarioExistente.Pendientes = usuario.Pendientes;
            usuarioExistente.AltamenteRelevantes = usuario.AltamenteRelevantes;
            usuarioExistente.UpdatedAt = DateTime.UtcNow;

            await _usuarioService.UpdateUsuarioAsync(usuarioExistente);
            return Ok(usuarioExistente);
        }
    }
}
