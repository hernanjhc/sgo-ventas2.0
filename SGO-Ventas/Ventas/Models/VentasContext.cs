using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ventas.Models
{
    public partial class VentasContext : DbContext
    {
        public VentasContext()
        {
        }

        public VentasContext(DbContextOptions<VentasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banco> Bancos { get; set; }
        public virtual DbSet<BancoSucursal> BancoSucursals { get; set; }
        public virtual DbSet<Barrio> Barrios { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Domicilio> Domicilios { get; set; }
        public virtual DbSet<Earticulo> Earticulos { get; set; }
        public virtual DbSet<Ecompra> Ecompras { get; set; }
        public virtual DbSet<EcomprasDetalle> EcomprasDetalles { get; set; }
        public virtual DbSet<Ecuenta> Ecuentas { get; set; }
        public virtual DbSet<Edeposito> Edepositos { get; set; }
        public virtual DbSet<Emarca> Emarcas { get; set; }
        public virtual DbSet<EmovimStock> EmovimStocks { get; set; }
        public virtual DbSet<Emovimiento> Emovimientos { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Epresupuesto> Epresupuestos { get; set; }
        public virtual DbSet<EpresupuestosDetalle> EpresupuestosDetalles { get; set; }
        public virtual DbSet<Eremito> Eremitos { get; set; }
        public virtual DbSet<EremitosDetalle> EremitosDetalles { get; set; }
        public virtual DbSet<Erubro> Erubros { get; set; }
        public virtual DbSet<Eventa> Eventas { get; set; }
        public virtual DbSet<EventasDetalle> EventasDetalles { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<GruposItemsMenu> GruposItemsMenus { get; set; }
        public virtual DbSet<GruposUsuario> GruposUsuarios { get; set; }
        public virtual DbSet<ItemsMenu> ItemsMenus { get; set; }
        public virtual DbSet<Localidade> Localidades { get; set; }
        public virtual DbSet<Proveedore> Proveedores { get; set; }
        public virtual DbSet<Provincia> Provincias { get; set; }
        public virtual DbSet<Sucursale> Sucursales { get; set; }
        public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; }
        public virtual DbSet<Unidade> Unidades { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuariosItemsMenu> UsuariosItemsMenus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=JHC\\SQLEXPRESS;initial catalog=Ventas;user id=sa;password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Banco>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BancoSucursal>(entity =>
            {
                entity.ToTable("BancoSucursal");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sucursal)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Web)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Barrio>(entity =>
            {
                entity.HasIndex(e => e.IdLocalidad, "IX_FK_Barrios_Localidades");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLocalidadNavigation)
                    .WithMany(p => p.Barrios)
                    .HasForeignKey(d => d.IdLocalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Barrios_Localidades");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasIndex(e => e.IdDomicilio, "IX_FK_Clientes_Domicilios");

                entity.HasIndex(e => e.IdTipoDocumento, "IX_FK_Clientes_TiposDocumento");

                entity.HasIndex(e => e.IdTipoDocumento, "IX_FK_Proveedores_TiposDocumento");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMail");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.NroDocumento).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDomicilioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdDomicilio)
                    .HasConstraintName("FK_Clientes_Domicilios");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes_TiposDocumento");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasIndex(e => e.IdProvincia, "IX_FK_Departamentos_Provincias");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departamentos_Provincias");
            });

            modelBuilder.Entity<Domicilio>(entity =>
            {
                entity.HasIndex(e => e.IdBarrio, "IX_FK_Domicilios_Barrios");

                entity.HasIndex(e => e.IdDepartamento, "IX_FK_Domicilios_Departamentos");

                entity.HasIndex(e => e.IdLocalidad, "IX_FK_Domicilios_Localidades");

                entity.HasIndex(e => e.IdProvincia, "IX_FK_Domicilios_Provincias");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdBarrioNavigation)
                    .WithMany(p => p.Domicilios)
                    .HasForeignKey(d => d.IdBarrio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Domicilios_Barrios");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Domicilios)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Domicilios_Departamentos");

                entity.HasOne(d => d.IdLocalidadNavigation)
                    .WithMany(p => p.Domicilios)
                    .HasForeignKey(d => d.IdLocalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Domicilios_Localidades");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Domicilios)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Domicilios_Provincias");
            });

            modelBuilder.Entity<Earticulo>(entity =>
            {
                entity.ToTable("EArticulos");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CodBarra)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Costo).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.CostoInicial).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descuento1).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.Descuento2).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.Descuento3).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.DescuentoPorc1).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.DescuentoPorc2).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.DescuentoPorc3).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Iva)
                    .HasColumnType("numeric(5, 2)")
                    .HasColumnName("IVA");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioL1).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.PrecioL2).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.PrecioL3).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.PrecioPorcL1).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.PrecioPorcL2).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.PrecioPorcL3).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Stock).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.StockMinimo).HasColumnType("numeric(17, 2)");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Earticulos)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EArticulos_Empresas");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Earticulos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK_EArticulos_Marcas");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Earticulos)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK_EArticulos_Proveedores");

                entity.HasOne(d => d.IdRubroNavigation)
                    .WithMany(p => p.Earticulos)
                    .HasForeignKey(d => d.IdRubro)
                    .HasConstraintName("FK_EArticulos_Rubros");

                entity.HasOne(d => d.IdUnidadNavigation)
                    .WithMany(p => p.Earticulos)
                    .HasForeignKey(d => d.IdUnidad)
                    .HasConstraintName("FK_EArticulos_Unidades");
            });

            modelBuilder.Entity<Ecompra>(entity =>
            {
                entity.ToTable("ECompras");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Importe).HasColumnType("numeric(17, 2)");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Ecompras)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ECompras_Empresas");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Ecompras)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK_ECompras_Proveedores");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Ecompras)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ECompras_Usuarios");
            });

            modelBuilder.Entity<EcomprasDetalle>(entity =>
            {
                entity.ToTable("EComprasDetalles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Importe).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.Precio).HasColumnType("numeric(17, 2)");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.EcomprasDetalles)
                    .HasForeignKey(d => d.IdArticulo)
                    .HasConstraintName("FK_EComprasDetalles_Articulos");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.EcomprasDetalles)
                    .HasForeignKey(d => d.IdCompra)
                    .HasConstraintName("FK_EComprasDetalles_Compras");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.EcomprasDetalles)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EComprasDetalles_Empresas");
            });

            modelBuilder.Entity<Ecuenta>(entity =>
            {
                entity.ToTable("ECuentas");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdReferencia).HasColumnName("idReferencia");

                entity.Property(e => e.SaldoInicial).HasColumnType("numeric(17, 2)");
            });

            modelBuilder.Entity<Edeposito>(entity =>
            {
                entity.ToTable("EDepositos");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Deposito)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdBarrio).HasColumnName("idBarrio");

                entity.Property(e => e.IdEncargado).HasColumnName("idEncargado");

                entity.Property(e => e.IdLocalidad).HasColumnName("idLocalidad");

                entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");
            });

            modelBuilder.Entity<Emarca>(entity =>
            {
                entity.ToTable("EMarcas");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Marca)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Emarcas)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMarcas_Empresas");
            });

            modelBuilder.Entity<EmovimStock>(entity =>
            {
                entity.ToTable("EMovimStock");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Egreso).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdArticulo).HasColumnName("idArticulo");

                entity.Property(e => e.IdClienteDestino).HasColumnName("idClienteDestino");

                entity.Property(e => e.IdClienteOrigen).HasColumnName("idClienteOrigen");

                entity.Property(e => e.IdDepositoDestino).HasColumnName("idDepositoDestino");

                entity.Property(e => e.IdDepositoOrigen).HasColumnName("idDepositoOrigen");

                entity.Property(e => e.IdProveedorDestino).HasColumnName("idProveedorDestino");

                entity.Property(e => e.IdProveedorOrigen).HasColumnName("idProveedorOrigen");

                entity.Property(e => e.Ingreo).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.Stock).HasColumnType("numeric(17, 2)");
            });

            modelBuilder.Entity<Emovimiento>(entity =>
            {
                entity.ToTable("EMovimientos");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Contrasiento)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Credito).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.Debito).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdCheque).HasColumnName("idCheque");

                entity.Property(e => e.IdCompra).HasColumnName("idCompra");

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.IdNotaCredito).HasColumnName("idNotaCredito");

                entity.Property(e => e.IdNotaDebito).HasColumnName("idNotaDebito");

                entity.Property(e => e.IdVenta).HasColumnName("idVenta");

                entity.Property(e => e.Saldo).HasColumnType("numeric(17, 2)");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Compra).HasDefaultValueSql("('0')");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NotaCredito).HasDefaultValueSql("('0')");

                entity.Property(e => e.NotaDebito).HasDefaultValueSql("('0')");

                entity.Property(e => e.NroDoc).HasColumnType("decimal(17, 0)");

                entity.Property(e => e.Presupuesto).HasDefaultValueSql("('0')");

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Remito).HasDefaultValueSql("('0')");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Venta).HasDefaultValueSql("('0')");

                entity.HasOne(d => d.IdDomicilioNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdDomicilio)
                    .HasConstraintName("FK_Empresas_Domicilios");

                entity.HasOne(d => d.IdTipoDocNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdTipoDoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empresas_TiposDocumento");
            });

            modelBuilder.Entity<Epresupuesto>(entity =>
            {
                entity.ToTable("EPresupuestos");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descuento).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.DescuentoPorc).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Importe).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.ImporteTotal).HasColumnType("numeric(17, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Epresupuestos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_EPresupuestos_Clientes");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Epresupuestos)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EPresupuestos_Empresas");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Epresupuestos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_EPresupuestos_Usuarios");
            });

            modelBuilder.Entity<EpresupuestosDetalle>(entity =>
            {
                entity.ToTable("EPresupuestosDetalles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Importe).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.Precio).HasColumnType("numeric(17, 2)");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.EpresupuestosDetalles)
                    .HasForeignKey(d => d.IdArticulo)
                    .HasConstraintName("FK_EPresupuestosDetalles_Articulos");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.EpresupuestosDetalles)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EPresupuestosDetalles_Empresas");

                entity.HasOne(d => d.IdPresupuestoNavigation)
                    .WithMany(p => p.EpresupuestosDetalles)
                    .HasForeignKey(d => d.IdPresupuesto)
                    .HasConstraintName("FK_EPresupuestosDetalles_Presupuestos");
            });

            modelBuilder.Entity<Eremito>(entity =>
            {
                entity.ToTable("ERemitos");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EntregaNombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.RecibeNombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RecibeNroDocumento).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Eremitos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_ERemitos_Clientes");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Eremitos)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ERemitos_Empresas");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Eremitos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_ERemitos_Usuarios");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.Eremitos)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ERemitos_EVentas");
            });

            modelBuilder.Entity<EremitosDetalle>(entity =>
            {
                entity.ToTable("ERemitosDetalles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.EremitosDetalles)
                    .HasForeignKey(d => d.IdArticulo)
                    .HasConstraintName("FK_ERemitosDetalles_Articulos");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.EremitosDetalles)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ERemitosDetalles_Empresas");

                entity.HasOne(d => d.IdRemitoNavigation)
                    .WithMany(p => p.EremitosDetalles)
                    .HasForeignKey(d => d.IdRemito)
                    .HasConstraintName("FK_ERemitosDetalles_Remitos");
            });

            modelBuilder.Entity<Erubro>(entity =>
            {
                entity.ToTable("ERubros");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rubro)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Erubros)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_ERubros_Empresas");
            });

            modelBuilder.Entity<Eventa>(entity =>
            {
                entity.ToTable("EVentas");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descuento).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.DescuentoPorc).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Importe).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.ImporteTotal).HasColumnType("numeric(17, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Eventa)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_EVentas_Clientes");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Eventa)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EVentas_Empresas");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Eventa)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_EVentas_Usuarios");
            });

            modelBuilder.Entity<EventasDetalle>(entity =>
            {
                entity.ToTable("EVentasDetalles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Importe).HasColumnType("numeric(17, 2)");

                entity.Property(e => e.Precio).HasColumnType("numeric(17, 2)");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.EventasDetalles)
                    .HasForeignKey(d => d.IdArticulo)
                    .HasConstraintName("FK_EVentasDetalles_Articulos");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.EventasDetalles)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EVentasDetalles_Empresas");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.EventasDetalles)
                    .HasForeignKey(d => d.IdVenta)
                    .HasConstraintName("FK_EVentasDetalles_Ventas");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GruposItemsMenu>(entity =>
            {
                entity.ToTable("GruposItemsMenu");

                entity.HasIndex(e => e.IdGrupo, "IX_FK_GruposItemsMenu_Grupos");

                entity.HasIndex(e => e.IdItemMenu, "IX_FK_GruposItemsMenu_ItemsMenu");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.GruposItemsMenus)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GruposItemsMenu_Grupos");

                entity.HasOne(d => d.IdItemMenuNavigation)
                    .WithMany(p => p.GruposItemsMenus)
                    .HasForeignKey(d => d.IdItemMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GruposItemsMenus_ItemsMenu");
            });

            modelBuilder.Entity<GruposUsuario>(entity =>
            {
                entity.HasIndex(e => e.IdGrupo, "IX_FK_GruposUsuarios_Grupos");

                entity.HasIndex(e => e.IdUsuario, "IX_FK_GruposUsuarios_Usuarios");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.GruposUsuarios)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GruposUsuarios_Grupos");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.GruposUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GruposUsuarios_Usuarios");
            });

            modelBuilder.Entity<ItemsMenu>(entity =>
            {
                entity.ToTable("ItemsMenu");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Localidade>(entity =>
            {
                entity.HasIndex(e => e.IdDepartamento, "IX_FK_Localidades_Departamentos");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Localidades)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Localidades_Departamentos");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasIndex(e => e.IdDomicilio, "IX_FK_Proveedores_Domicilios");

                entity.HasIndex(e => e.IdTipoDocumento, "IX_FK_Proveedores_TiposDocumento");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMail");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.NroDocumento).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDomicilioNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.IdDomicilio)
                    .HasConstraintName("FK_Proveedores_Domicilios");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proveedores_TiposDocumento");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sucursale>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMail");

                entity.Property(e => e.Sucursal)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Web)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBancoNavigation)
                    .WithMany(p => p.Sucursales)
                    .HasForeignKey(d => d.IdBanco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sucursales_Bancos");
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

            modelBuilder.Entity<Unidade>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Unidad)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

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
            });

            modelBuilder.Entity<UsuariosItemsMenu>(entity =>
            {
                entity.ToTable("UsuariosItemsMenu");

                entity.HasIndex(e => e.IdItemMenu, "IX_FK_UsuariosItemsMenu_ItemsMenu");

                entity.HasIndex(e => e.IdUsuario, "IX_FK_UsuariosItemsMenu_Usuarios");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdItemMenuNavigation)
                    .WithMany(p => p.UsuariosItemsMenus)
                    .HasForeignKey(d => d.IdItemMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosItemsMenu_ItemsMenu");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuariosItemsMenus)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosItemsMenu_Usuarios");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
