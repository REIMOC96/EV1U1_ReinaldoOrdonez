using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Mercydevs.Models;

public partial class MercydevsContext : DbContext
{
    public MercydevsContext()
    {
    }

    public MercydevsContext(DbContextOptions<MercydevsContext> options)
        : base(options)
    { }
    

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Clienteservicio> Clienteservicios { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

        if (!optionsBuilder.IsConfigured) { }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idclientes).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.Property(e => e.Idclientes)
                .HasColumnType("int(11)")
                .HasColumnName("idclientes");
            entity.Property(e => e.Apellido)
                .HasMaxLength(45)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(45)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(45)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(45)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Clienteservicio>(entity =>
        {
            entity.HasKey(e => new { e.IdClienteServicio, e.ClientesIdclientes, e.ServicioIdservicio })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("clienteservicio");

            entity.HasIndex(e => e.ClientesIdclientes, "fk_clientes_has_servicio_clientes_idx");

            entity.HasIndex(e => e.ServicioIdservicio, "fk_clientes_has_servicio_servicio1_idx");

            entity.Property(e => e.IdClienteServicio)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)")
                .HasColumnName("id_cliente_servicio");
            entity.Property(e => e.ClientesIdclientes)
                .HasColumnType("int(11)")
                .HasColumnName("clientes_idclientes");
            entity.Property(e => e.ServicioIdservicio)
                .HasColumnType("int(11)")
                .HasColumnName("servicio_idservicio");

            entity.HasOne(d => d.ClientesIdclientesNavigation).WithMany(p => p.Clienteservicios)
                .HasForeignKey(d => d.ClientesIdclientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_clientes_has_servicio_clientes");

            entity.HasOne(d => d.ServicioIdservicioNavigation).WithMany(p => p.Clienteservicios)
                .HasForeignKey(d => d.ServicioIdservicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_clientes_has_servicio_servicio1");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Idservicio).HasName("PRIMARY");

            entity.ToTable("servicio");

            entity.Property(e => e.Idservicio)
                .HasColumnType("int(11)")
                .HasColumnName("idservicio");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
            entity.Property(e => e.Horario)
                .HasMaxLength(45)
                .HasColumnName("horario");
            entity.Property(e => e.Precio)
                .HasColumnType("int(11)")
                .HasColumnName("precio");
            entity.Property(e => e.ServicioFinalizado).HasColumnName("servicioFinalizado");
            entity.Property(e => e.ServicioIniciado).HasColumnName("servicioIniciado");
            entity.Property(e => e.Tecnico)
                .HasMaxLength(45)
                .HasColumnName("tecnico");
            entity.Property(e => e.TipoServicio)
                .HasMaxLength(45)
                .HasColumnName("tipoServicio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
