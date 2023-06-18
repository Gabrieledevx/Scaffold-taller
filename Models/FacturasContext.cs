using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Scaffold_taller.Models
{
    public partial class FacturasContext : DbContext
    {
        public FacturasContext()
        {
        }

        public FacturasContext(DbContextOptions<FacturasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<ConfiguracionImpuesto> ConfiguracionImpuestos { get; set; } = null!;
        public virtual DbSet<DetallesFactura> DetallesFacturas { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Impuesto> Impuestos { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(" Server=localhost\\SQLEXPRESS;Database=Facturas;Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__677F38F54FF2BA8D");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("correo_electronico");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<ConfiguracionImpuesto>(entity =>
            {
                entity.HasKey(e => e.IdConfiguracion)
                    .HasName("PK__Configur__16A13EBD9CD826DC");

                entity.ToTable("Configuracion_Impuestos");

                entity.Property(e => e.IdConfiguracion).HasColumnName("id_configuracion");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.Property(e => e.IdImpuesto).HasColumnName("id_impuesto");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.ConfiguracionImpuestos)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("FK__Configura__id_fa__4AB81AF0");

                entity.HasOne(d => d.IdImpuestoNavigation)
                    .WithMany(p => p.ConfiguracionImpuestos)
                    .HasForeignKey(d => d.IdImpuesto)
                    .HasConstraintName("FK__Configura__id_im__49C3F6B7");
            });

            modelBuilder.Entity<DetallesFactura>(entity =>
            {
                entity.HasKey(e => e.IdDetalle)
                    .HasName("PK__Detalles__4F1332DEFA55049A");

                entity.ToTable("Detalles_Factura");

                entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio_unitario");

                entity.Property(e => e.Subtotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("subtotal");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.DetallesFacturas)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("FK__Detalles___id_fa__412EB0B6");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetallesFacturas)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__Detalles___id_pr__4222D4EF");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__Facturas__6C08ED536C99842D");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Facturas__id_cli__3D5E1FD2");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Facturas__id_usu__3E52440B");
            });

            modelBuilder.Entity<Impuesto>(entity =>
            {
                entity.HasKey(e => e.IdImpuesto)
                    .HasName("PK__Impuesto__8546BDFC7298CD32");

                entity.Property(e => e.IdImpuesto).HasColumnName("id_impuesto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Tasa)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("tasa");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK__Pagos__0941B074C60EC8CE");

                entity.Property(e => e.IdPago).HasColumnName("id_pago");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("cantidad");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("FK__Pagos__id_factur__44FF419A");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__FF341C0D57B6DB9B");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio_unitario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__4E3E04ADF966AB21");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("contrasena");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre_usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
