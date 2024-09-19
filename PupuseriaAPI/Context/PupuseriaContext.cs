using System;
using Microsoft.EntityFrameworkCore;
using PupuseriaAPI.Models;

namespace PupuseriaAPI.Context;

public class PupuseriaContext : DbContext
{
    public PupuseriaContext(DbContextOptions<PupuseriaContext> options) : base (options)
    {
        
    }
    public DbSet<Pupuseria> Pupuserias { get; set;}
    
    public DbSet<Usuario> Usuarios { get; set;}
    public DbSet<Voto> Votos { get; set;}
}
