using AccesoADatos;
using LogicaAplicacion.ImplementacionCU.Usuarios;
using LogicaAplicacion.InterfacesCU.Usuarios;
using LogicaDeNegocios.InterfacesRepositorios;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContext, Contexto>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("StringConnection"))
    );

builder.Services.AddScoped(typeof(IRepositorioUsuario), typeof(RepositorioUsuario));

builder.Services.AddScoped(typeof(IAltaUsuario), typeof(AltaUsuario));
builder.Services.AddScoped(typeof(IGetUsuario), typeof(GetUsuario));
builder.Services.AddScoped(typeof(IEliminarUsuario), typeof(EliminarUsuario));
builder.Services.AddScoped(typeof(IModificarUsuario), typeof(ModificarUsuario));
builder.Services.AddScoped(typeof(IGetAllUsuarios), typeof(GetAllUsuarios));

// Add services to the container.

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
