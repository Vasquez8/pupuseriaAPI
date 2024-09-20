using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PupuseriaAPI.Context;
using PupuseriaAPI.Services.Implementaciones;
using PupuseriaAPI.Services.Iterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var ConString = builder.Configuration.GetConnectionString("Conn");
builder.Services.AddDbContext<PupuseriaContext>(
    Options => Options.UseMySql(ConString,ServerVersion.AutoDetect(ConString))
);
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPupuseriaService, PupuseriaService>();
builder.Services.AddScoped<IVotoService, VotoService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
