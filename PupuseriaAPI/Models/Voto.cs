using System;

namespace PupuseriaAPI.Models;

public class Voto
{
    public int Id { get; set; }
    public string IdPupuseria { get; set; }
    public string IdUsuario { get; set; }
    public DateTime Fecaha_Votacion { get; set; }
}
