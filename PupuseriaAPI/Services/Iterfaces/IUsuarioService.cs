using System;
using PupuseriaAPI.Models;

namespace PupuseriaAPI.Services.Iterfaces;

public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> GetUsuarios();

    Task<Usuario> GetUsuarioById(int id);

    Task<Usuario> CreateUsuario(Usuario usuario);

    Task UpdateUsuario (Usuario usuario, int id);

        Task DeleteUsuario (int id);
}
