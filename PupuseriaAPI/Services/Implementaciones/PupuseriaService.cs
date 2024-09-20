using System;
using Microsoft.EntityFrameworkCore;
using PupuseriaAPI.Context;
using PupuseriaAPI.Models;
using PupuseriaAPI.Services.Iterfaces;

namespace PupuseriaAPI.Services.Implementaciones;

public class PupuseriaService : IPupuseriaService
{
private readonly PupuseriaContext _pupuseriaContext;
    // Constructor
    public PupuseriaService(PupuseriaContext context)
    {
        _pupuseriaContext = context;
    }

    public async Task<Pupuseria> CreatePupuseria(Pupuseria Pupuseria)
    {
        _pupuseriaContext.Pupuserias.Add(Pupuseria);
        await _pupuseriaContext.SaveChangesAsync();
        return Pupuseria;
    }

    public async Task DeletePupuseria(int id)
    {
        var user = await _pupuseriaContext.Pupuserias.FirstOrDefaultAsync(u => u.Id == id);
        if(user == null) throw new KeyNotFoundException("Pupuseria no encontrado");
        _pupuseriaContext.Pupuserias.Remove(user);
        await _pupuseriaContext.SaveChangesAsync();
    }

    public async Task<Pupuseria> GetPupuseriaById(int id)
    {
        return await _pupuseriaContext.Pupuserias.FindAsync(id);
    }

    public async Task<IEnumerable<Pupuseria>> GetPupuserias()
    {
        return await _pupuseriaContext.Pupuserias.ToListAsync();
    }

    public async Task UpdatePupuseria(Pupuseria Pupuseria, int id)
    {
        var PupuseriaExis = await _pupuseriaContext.Pupuserias.FirstOrDefaultAsync(u => u.Id == id);

        if(PupuseriaExis ==null) throw new KeyNotFoundException("Pupuseria no encontrado");
        PupuseriaExis.Nombre = Pupuseria.Nombre;
        PupuseriaExis.Ubicacion = Pupuseria.Ubicacion;
        
        await _pupuseriaContext.SaveChangesAsync();
    }
}