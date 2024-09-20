using System;

namespace PupuseriaAPI.Models;

public class Voto
{
    public int Id { get; set; }
    public int IdPupuseria { get; set; }
    public int IdUsuario { get; set; }
    public DateTime Fecha_Votacion { get; set; }
}
