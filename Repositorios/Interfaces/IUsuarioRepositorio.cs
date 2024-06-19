using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> GetAll();

        Task<UsuarioModel> GetById(int id);

        Task<UsuarioModel> Login(string username, string password);
        Task<UsuarioModel> InsertUsuario(UsuarioModel user);

        Task<UsuarioModel> UpdateUsuario(UsuarioModel user, int id);

        Task<bool> DeleteUsuario(int id);
    }
}
