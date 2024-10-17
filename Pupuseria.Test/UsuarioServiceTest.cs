using PupuseriaAPI.Context;
using PupuseriaAPI.Models;
using PupuseriaAPI.Services.Implementaciones;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
namespace PupuseriaAPI.Context;

public class UsuarioServiceTest {
    private readonly UsuarioService _usuarioService;
    private readonly PupuseriaContext _pupuseriaContext;

    public UsuarioServiceTest() {
        _pupuseriaContext = PupuseriaContextMemory<PupuseriaContext>.CreateDbContext(Guid.NewGuid().ToString());
        _usuarioService = new UsuarioService(_pupuseriaContext);
    }
        [Fact]
    public async Task CreateUsuario() {
        var usuario = new Usuario {
            UserName = "testUser",
            Email = "test@gmail.com",
            Password = "TestPassword123"
        };

        var result = await _usuarioService.CreateUsuario(usuario);
        var usuarioFromDb = await _pupuseriaContext.Usuarios.FirstOrDefaultAsync(u => u.UserName == "testUser");

        Assert.NotNull(usuarioFromDb);
        Assert.Equal("testUser", usuarioFromDb.UserName);
        Assert.Equal("TestPassword123", usuarioFromDb.Password);
    }
    [Fact]
    public async Task UpdateUsuario() {
        var usuario = new Usuario {
            UserName = "oldUser",
            Email = "oldtest@gmail.com",
            Password = "oldTestPassword123"
        };
    
        _pupuseriaContext.Usuarios.Add(usuario);
        await _pupuseriaContext.SaveChangesAsync();
    
        var updateUsuario = new Usuario {
            UserName = "newUser",
            Email = "newtest@gmail.com",
            Password = "newTestPassword123"
        };
    
        await _usuarioService.UpdateUsuario(updateUsuario, usuario.Id);
    
        var usuarioFromDb = await _pupuseriaContext.Usuarios.FindAsync(usuario.Id);
        Assert.NotNull(usuarioFromDb);
        Assert.Equal("newUser", usuarioFromDb.UserName);
        Assert.Equal("oldTestPassword123", usuarioFromDb.Password);
    }

    [Fact]
    public async Task DeleteUsuario() {
        var usuario = new Usuario {
            UserName = "testUser",
            Email = "test@gmail.com",
            Password = "TestPassword123"
        };
    
        _pupuseriaContext.Usuarios.Add(usuario);
        await _pupuseriaContext.SaveChangesAsync();

        await _usuarioService.DeleteUsuario(usuario.Id);
    
        var usuarioFromDb = await _pupuseriaContext.Usuarios.FindAsync(usuario.Id);
        Assert.Null(usuarioFromDb);
    }

    [Fact]
    public async Task GetUsuarioById() {
        var usuario = new Usuario {
            UserName = "testUser",
            Email = "test@gmail.com",
            Password = "TestPassword123"
        };
    
        _pupuseriaContext.Usuarios.Add(usuario);
        await _pupuseriaContext.SaveChangesAsync();
    
        var result = await _usuarioService.GetUsuarioById(usuario.Id);
    
        Assert.NotNull(result);
        Assert.Equal("testUser", result.UserName);
        Assert.Equal("test@gmail.com", result.Email);
        Assert.Equal("TestPassword123", result.Password);
    }

    [Fact]
    public async Task GetUsuarios() {
        var usuarios = new List<Usuario> {
            new Usuario { UserName = "User1", Email = "user1@gmail.com", Password = "userPassword1" },
            new Usuario { UserName = "User2", Email = "user2@gmail.com", Password = "userPassword2" }
        };
    
        _pupuseriaContext.Usuarios.AddRange(usuarios);
        await _pupuseriaContext.SaveChangesAsync();
    
        var result = await _usuarioService.GetUsuarios();
    
        Assert.Equal(2, result.Count());
        Assert.Contains(result, u => u.UserName == "User1");
        Assert.Contains(result, u => u.UserName == "User2");
    }
}