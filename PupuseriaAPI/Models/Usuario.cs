using System;

namespace PupuseriaAPI.Models;

public class Usuario
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
