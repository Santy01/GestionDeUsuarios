using GestionDeUsuarios.Models;

namespace GestionDeUsuarios.Business.Services
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetAllUsuariosAsync();
        Task<Usuario?> GetUsuarioByUsernameAsync(string username);
        Task<Usuario> CreateUsuarioAsync(Usuario usuario);
        Task<Usuario> UpdateUsuarioAsync(Usuario usuario);
    }
}
