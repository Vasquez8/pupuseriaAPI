using System;
using PupuseriaAPI.Models;

namespace PupuseriaAPI.Services.Iterfaces;

public interface IPupuseriaService
{
    Task<IEnumerable<Pupuseria>> GetPupuserias();

    Task<Pupuseria> GetPupuseriaById(int id);

    Task<Pupuseria> CreatePupuseria(Pupuseria Pupuseria);

    Task UpdatePupuseria (Pupuseria Pupuseria, int id);

        Task DeletePupuseria (int id);

}
