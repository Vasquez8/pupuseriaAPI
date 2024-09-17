using System;
using Microsoft.EntityFrameworkCore;
using PupuseriaAPI.Context;
using PupuseriaAPI.Models;
using PupuseriaAPI.Services.Iterfaces;

namespace PupuseriaAPI.Services.Implementaciones;

public class UsuarioService : IUsuarioService
{
    private readonly PupuseriaContext _pupuseriaContext;
    // Constructor
    public UsuarioService(PupuseriaContext context)
    {
        _pupuseriaContext = context;
    }

    public async Task<Usuario> CreateUsuario(Usuario usuario)
    {
        _pupuseriaContext.Usuarios.Add(usuario);
        await _pupuseriaContext.SaveChangesAsync();
        return usuario;
    }

    public async Task DeleteUsuario(int id)
    {
        var user = await _pupuseriaContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        if(user == null) throw new KeyNotFoundException("Usuario no encontrado");
        _pupuseriaContext.Usuarios.Remove(user);
        await _pupuseriaContext.SaveChangesAsync();
    }

    public async Task<Usuario> GetUsuarioById(int id)
    {
        return await _pupuseriaContext.Usuarios.FindAsync(id);
    }

    public async Task<IEnumerable<Usuario>> GetUsuarios()
    {
        return await _pupuseriaContext.Usuarios.ToListAsync();
    }

    public async Task UpdateUsuario(Usuario usuario, int id)
    {
        var usuarioExis = await _pupuseriaContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

        if(usuarioExis ==null) throw new KeyNotFoundException("Usuatio no encontrado");
        usuarioExis.UserName = usuario.UserName;
        usuarioExis.Email = usuario.Email;
        
        await _pupuseriaContext.SaveChangesAsync();
    }
}
