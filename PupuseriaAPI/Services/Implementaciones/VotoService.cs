using System;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using PupuseriaAPI.Context;
using PupuseriaAPI.Models;
using PupuseriaAPI.Services.Iterfaces;

namespace PupuseriaAPI.Services.Implementaciones;

public class VotoService : IVotoService
{
    private readonly PupuseriaContext _pupuseriaContext;

    public VotoService(PupuseriaContext pupuseriaContext)
    {
        _pupuseriaContext = pupuseriaContext;
    }
    public async Task<IEnumerable<Voto>> GetVotos()
    {
        return await _pupuseriaContext.Votos.ToListAsync();

    }

    public async Task<Voto> GetVotosById(int id)
    {
        return await _pupuseriaContext.Votos.FirstOrDefaultAsync( v => v.Id == id);
    }

    public async Task<IEnumerable<Voto>> GetVotosByIdPupuseria(int idPupuseria)
    {
        return await _pupuseriaContext.Votos.Where(v => v.IdPupuseria == idPupuseria).ToListAsync();
    }

    public async Task VotarAsync(int idPupuseria, int idUsuario)
    {
        var pupuseria = await _pupuseriaContext.Pupuserias.FirstOrDefaultAsync(v => v.Id == idUsuario);
        if(pupuseria == null){
            throw new KeyNotFoundException("Pupuseria no encontrada");
        }
        var votoExistente = await _pupuseriaContext.Votos.AnyAsync(v => v.IdPupuseria == idPupuseria && v.IdPupuseria == idPupuseria);
        if(votoExistente){
            throw new KeyNotFoundException("El susario y a ha realizado el voto");
        }
        var nuevoVoto = new Voto{
            IdPupuseria = idPupuseria,
            IdUsuario = idUsuario,
            Fecha_Votacion = DateTime.Now,
        };

        _pupuseriaContext.Add(nuevoVoto);

        await _pupuseriaContext.SaveChangesAsync();
    }
}
