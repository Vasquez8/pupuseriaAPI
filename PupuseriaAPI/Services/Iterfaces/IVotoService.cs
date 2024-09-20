using System;
using PupuseriaAPI.Models;

namespace PupuseriaAPI.Services.Iterfaces;

public interface IVotoService
{
    Task<IEnumerable<Voto>> GetVotos();
    Task<Voto> GetVotosById(int id);
    Task<IEnumerable<Voto>> GetVotosByIdPupuseria(int idPupuseria);
    Task VotarAsync(int idPupuseria, int idUsuario);

}
