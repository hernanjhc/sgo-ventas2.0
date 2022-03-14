using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Models
{
    public partial class SGOVentasContext : DbContext
    {
        public SGOVentasContext()
        {
        }

        public SGOVentasContext(DbContextOptions<SGOVentasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<ComprasDetalle> ComprasDetalles { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }
        public virtual DbSet<MovimientosCaja> MovimientosCajas { get; set; }
        public virtual DbSet<Operacione> Operaciones { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedore> Proveedores { get; set; }
        public virtual DbSet<Rubro> Rubros { get; set; }
        public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; }
        public virtual DbSet<TiposPago> TiposPagos { get; set; }
        public virtual DbSet<Unidade> Unidades { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<VentasX> VentasXes { get; set; }
        public virtual DbSet<VentasXdetalle> VentasXdetalles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=SGO-Ventas;user=sa,password=123456;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMail");

                entity.Property(e => e.NroDocumento).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes_TiposDocumento");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_Proveedores");

                entity.HasOne(d => d.IdTipoPagoNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdTipoPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_TiposPago");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_Usuarios");
            });

            modelBuilder.Entity<ComprasDetalle>(entity =>
            {
                entity.ToTable("ComprasDetalle");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Descuento).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Importe).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Precio).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("Empresa");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Documento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            modelBuilder.Entity<MovimientosCaja>(entity =>
            {
                entity.ToTable("MovimientosCaja");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Egreso).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.Ingreso).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<Operacione>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CodBarra)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Costo).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ivaventa)
                    .HasColumnType("numeric(5, 2)")
                    .HasColumnName("IVAVenta");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioL1).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.PrecioL2).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.PrecioL3).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.Stock).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.StockMinimo).HasColumnType("numeric(17, 2)");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK_Productos_Marcas");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK_Productos_Proveedores");

                entity.HasOne(d => d.IdRubroNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdRubro)
                    .HasConstraintName("FK_Productos_Rubros");

                entity.HasOne(d => d.IdUnidadNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdUnidad)
                    .HasConstraintName("FK_Productos_Unidades");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMail");

                entity.Property(e => e.NroDocumento).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proveedores_TiposDocumento");
            });

            modelBuilder.Entity<Rubro>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposDocumento>(entity =>
            {
                entity.ToTable("TiposDocumento");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposPago>(entity =>
            {
                entity.ToTable("TiposPago");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Unidade>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMail");

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaBaja).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VentasX>(entity =>
            {
                entity.ToTable("VentasX");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("numeric(17, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.VentasXes)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_VentasX_Clientes");

                entity.HasOne(d => d.IdTipoPagoNavigation)
                    .WithMany(p => p.VentasXes)
                    .HasForeignKey(d => d.IdTipoPago)
                    .HasConstraintName("FK_VentasX_TiposPago");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.VentasXes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_VentasX_Usuarios");
            });

            modelBuilder.Entity<VentasXdetalle>(entity =>
            {
                entity.ToTable("VentasXDetalles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Descuento).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Importe).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.Precio).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.VentasXdetalles)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentasXDetalles_Productos");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.VentasXdetalles)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentasXDetalles_VentasX");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
