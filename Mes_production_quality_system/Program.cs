using Microsoft.EntityFrameworkCore;
using Mes_production_quality_system.Data;
using Mes_production_quality_system.Repositories;
using Mes_production_quality_system.Repositories.Implements;
using Mes_production_quality_system.Services;
using Mes_production_quality_system.Services.Implements;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar Controladores
builder.Services.AddControllers();

// 2. Configurar Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Configurar Entity Framework Core con PostgreSQL
builder.Services.AddDbContext<MesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

// 4. Inyección de Dependencias (Unit of Work y Servicios)
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProduccionService, ProduccionService>();

var app = builder.Build();

// Configuración del pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapear las rutas de los controladores (API Endpoints)
app.MapControllers();

app.Run();