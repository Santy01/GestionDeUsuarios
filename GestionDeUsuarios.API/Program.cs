using GestionDeUsuarios.Business.Services;
using GestionDeUsuarios.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DbConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("La cadena de conexión 'DbConnection' no se encontró en la configuración.");
}
builder.Services.AddDbContext<GestionUsuariosContext>(options =>
    options.UseNpgsql(connectionString));
// Registrar el servicio de negocio para usuarios
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
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
