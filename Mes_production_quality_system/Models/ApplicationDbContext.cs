using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mes_production_quality_system.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InspeccionesCalidad> InspeccionesCalidads { get; set; }

    public virtual DbSet<Materiale> Materiales { get; set; }

    public virtual DbSet<OrdenesProduccion> OrdenesProduccions { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<RecetaProducto> RecetaProductos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=fabrica;Username=postgres;Password=admin;Port=5432");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InspeccionesCalidad>(entity =>
        {
            entity.HasKey(e => e.IdInspeccion).HasName("inspecciones_calidad_pkey");

            entity.ToTable("inspecciones_calidad");

            entity.Property(e => e.IdInspeccion).HasColumnName("id_inspeccion");
            entity.Property(e => e.Defectuosos).HasColumnName("defectuosos");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("fecha");
            entity.Property(e => e.IdOrden).HasColumnName("id_orden");
            entity.Property(e => e.Resultado).HasColumnName("resultado");

            entity.HasOne(d => d.IdOrdenNavigation).WithMany(p => p.InspeccionesCalidads)
                .HasForeignKey(d => d.IdOrden)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("inspecciones_calidad_id_orden_fkey");
        });

        modelBuilder.Entity<Materiale>(entity =>
        {
            entity.HasKey(e => e.IdMaterial).HasName("materiales_pkey");

            entity.ToTable("materiales");

            entity.Property(e => e.IdMaterial).HasColumnName("id_material");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Materiales)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("materiales_id_proveedor_fkey");
        });

        modelBuilder.Entity<OrdenesProduccion>(entity =>
        {
            entity.HasKey(e => e.IdOrden).HasName("ordenes_produccion_pkey");

            entity.ToTable("ordenes_produccion");

            entity.Property(e => e.IdOrden).HasColumnName("id_orden");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("fecha");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.OrdenesProduccions)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ordenes_produccion_id_producto_fkey");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("productos_pkey");

            entity.ToTable("productos");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("proveedores_pkey");

            entity.ToTable("proveedores");

            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Contacto).HasColumnName("contacto");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
        });

        modelBuilder.Entity<RecetaProducto>(entity =>
        {
            entity.HasKey(e => e.IdReceta).HasName("receta_producto_pkey");

            entity.ToTable("receta_producto");

            entity.Property(e => e.IdReceta).HasColumnName("id_receta");
            entity.Property(e => e.CantidadRequerida)
                .HasPrecision(10, 2)
                .HasColumnName("cantidad_requerida");
            entity.Property(e => e.IdMaterial).HasColumnName("id_material");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");

            entity.HasOne(d => d.IdMaterialNavigation).WithMany(p => p.RecetaProductos)
                .HasForeignKey(d => d.IdMaterial)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("receta_producto_id_material_fkey");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.RecetaProductos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("receta_producto_id_producto_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
