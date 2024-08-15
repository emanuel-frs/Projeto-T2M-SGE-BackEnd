using Application.Services;
using Domain.Repositories;
using Domain.Services;
using Infraestructore.Repositories;
using Infrastructore.Repositories;
using Infrastructure.ConexaoDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<PostgresDbConnection>();

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Registra repositorios e services
builder.Services.AddScoped<IArtistaRepository, ArtistaRepository>();
builder.Services.AddScoped<IArtistaEventoRepository, ArtistaEventoRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<ArtistaService>();
builder.Services.AddScoped<ArtistaEventoService>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<UsuarioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Adiciona o middleware CORS
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
