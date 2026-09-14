using Microsoft.EntityFrameworkCore;
using Mes_production_quality_system.Models;
using Mes_production_quality_system.Repositories;
using Mes_production_quality_system.Repositories.Interfaces;
using Mes_production_quality_system.Services;
using Mes_production_quality_system.Services.Implements;

var builder = WebApplication.CreateBuilder(args);

// 1. Controllers
builder.Services.AddControllers();

// 2. Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Entity Framework Core + PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PostgresConnection")));

// 4. Repositories
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IRecetaProductoRepository, RecetaProductoRepository>();
builder.Services.AddScoped<IOrdenProduccionRepository, OrdenProduccionRepository>();
builder.Services.AddScoped<IInspeccionCalidadRepository, InspeccionCalidadRepository>();

// 5. UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// 6. Services
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IRecetaProductoService, RecetaProductoService>();
builder.Services.AddScoped<IOrdenProduccionService, OrdenProduccionService>();
builder.Services.AddScoped<IInspeccionCalidadService, InspeccionCalidadService>();

var app = builder.Build();

// 7. Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();