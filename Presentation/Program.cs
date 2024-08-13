using Domain.Repositories;
using Domain.Services;
using Infraestructore.Repositories;
using Infrastructore.Repositories;
using Infrastructure.ConexaoDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<PostgresDbConnection>();

// Registra repositorios
builder.Services.AddScoped<IArtistaRepository, ArtistaRepository>();
builder.Services.AddScoped<IArtistaEventoRepository, ArtistaEventoRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Registra services
builder.Services.AddScoped<ArtistaService>();
builder.Services.AddScoped<ArtistaEventoService>();
builder.Services.AddScoped<EventoService>();
builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<UsuarioService>();

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