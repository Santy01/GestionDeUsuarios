using GestionDeUsuarios.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeUsuarios.Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly GestionUsuariosContext _context;

        public UsuarioService(GestionUsuariosContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetAllUsuariosAsync()
        {
            // Se utiliza AsNoTracking para lecturas de solo consulta
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<Usuario?> GetUsuarioByUsernameAsync(string username)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
