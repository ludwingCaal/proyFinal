using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Tienda.Model
{
    public class TiendaDataContext:DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Compra> Compras { get; set; }
		public DbSet<DetalleCompra> DetalleCompras { get; set; }
		public DbSet<DetalleFactura> DetalleFacturas { get; set; }
		public DbSet<EmailCliente> EmailClientes { get; set; }
		public DbSet<EmailProveedor> EmailProveedores { get; set; }
		public DbSet<Factura> Facturas { get; set; }
		public DbSet<Inventario> Inventarios { get; set; }
		public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
		public DbSet<TelefonoCliente> TelefonoClientes { get; set; }
		public DbSet<TelefonoProveedor> TelefonoProveedores { get; set; }
        public DbSet<TipoEmpaque> TipoEmpaques { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.Entity<Categoria>().ToTable("Categoria")
				.HasKey(ca => new { ca.CodigoCategoria })
				.Property(ca => ca.Descripcion)
				.IsRequired()
				.HasMaxLength(128);


			modelBuilder.Entity<Cliente>().ToTable("Cliente")
				.HasKey(d => new { d.Nit })
				.Property(d => d.Dpi)
				.IsRequired()
				.HasMaxLength(64);
			modelBuilder.Entity<Cliente>()
				.Property(d => d.Nombre)
				.IsRequired()
				.HasMaxLength(128);
			/*modelBuilder.Entity<Cliente>().ToTable("Cliente")
				.Property(d => d.Direccion)
				.HasMaxLength(128);*/


			modelBuilder.Entity<Compra>().ToTable("Compra")
				.HasKey(c => new { c.IdCompra })
				.Property(c => c.NumeroDocumento)
				.IsRequired();

			//Este Bloque de codigo es cuando la llave foranea de una tabla no se llama igual a la 
			//llave primaria que hace referencia.
			modelBuilder.Entity<Compra>()
				.HasRequired<Proveedor>(p => p.Proveedor)
				.WithMany(p => p.Compras)
				.HasForeignKey<int>(c => c.CodigoProveedor); 
				
			/*modelBuilder.Entity<Compra>().ToTable("Compra")
				.Property(c => c.Fecha)
				.IsRequired();
			modelBuilder.Entity<Compra>().ToTable("Compra")
				.Property(c => c.Total)
				.IsRequired();*/


			modelBuilder.Entity<DetalleCompra>().ToTable("DetalleCompra")
				.HasKey(d => new { d.IdDetalle });
			modelBuilder.Entity<DetalleCompra>()
				.HasRequired<Compra>(c => c.Compra)
				.WithMany(c => c.DetalleCompras)
				.HasForeignKey<int>(d => d.IdCompra);
			modelBuilder.Entity<DetalleCompra>()
				.HasRequired<Producto>(p => p.Producto)
				.WithMany(p => p.DetalleCompras)
				.HasForeignKey<int>(d => d.CodigoProducto);
			modelBuilder.Entity<DetalleCompra>()
				.Property(d => d.Cantidad)
				.IsRequired();
			modelBuilder.Entity<DetalleCompra>()
				.Property(d => d.Precio)
				.IsRequired();


			modelBuilder.Entity<DetalleFactura>().ToTable("DetalleFactura")
				.HasKey(df => new { df.CodigoDetalle });
			modelBuilder.Entity<DetalleFactura>()
				.HasRequired<Factura>(fa => fa.Factura)
				.WithMany(fa => fa.DetalleFacturas)
				.HasForeignKey<int>(df => df.NumeroFactura);
			modelBuilder.Entity<DetalleFactura>()
				.HasRequired<Producto>(c => c.Producto)
				.WithMany(c => c.DetalleFacturas)
				.HasForeignKey<int>(cp => cp.CodigoProducto);
			modelBuilder.Entity<DetalleFactura>()
				.Property(df => df.Cantidad)
				.IsRequired();
			modelBuilder.Entity<DetalleFactura>()
				.Property(df => df.Precio)
				.IsRequired();


			modelBuilder.Entity<EmailCliente>()
				.ToTable("EmailCliente")
				.HasKey(e => new { e.CodigoEmail })
				.Property(e => e.Email)
				.HasMaxLength(128)
				.IsRequired();
			modelBuilder.Entity<EmailCliente>()
				.HasRequired<Cliente>(cl => cl.Cliente)
				.WithMany(cl => cl.EmailClientes)
				.HasForeignKey<string>(e=>e.Nit);


			modelBuilder.Entity<EmailProveedor>()
				.ToTable("EmailProveedor")
				.HasKey(ep => new { ep.CodigoEmail })
				.Property(ep => ep.Email)
				.HasMaxLength(64)
				.IsRequired();
			modelBuilder.Entity<EmailProveedor>()
				.HasRequired<Proveedor>(p => p.Proveedor)
				.WithMany(p => p.EmailProveedors)
				.HasForeignKey<int>(ep => ep.CodigoProveedor);


			modelBuilder.Entity<Factura>()
				.ToTable("Factura")
				.HasKey(f => new { f.NumeroFactura });
			modelBuilder.Entity<Factura>()
				.HasRequired<Cliente>(c => c.Cliente)
				.WithMany(c => c.Facturas)
				.HasForeignKey<string>(f => f.Nit);


			modelBuilder.Entity<Inventario>()
				.ToTable("Inventario")
				.HasKey(i => new { i.CodigoInventario });
			modelBuilder.Entity<Inventario>()
				.HasRequired<Producto>(p => p.Producto)
				.WithMany(p => p.Inventarios)
				.HasForeignKey<int>(i => i.CodigoProducto);
			modelBuilder.Entity<Inventario>()
				.Property(i => i.Fecha)
				.IsRequired();
			modelBuilder.Entity<Inventario>()
				.Property(i => i.Precio)
				.IsRequired();
			/*modelBuilder.Entity<Inventario>()
				.Property(i => i.Entradas)
				.IsRequired();
			modelBuilder.Entity<Inventario>()
				.Property(i => i.Salidas)
				.IsRequired();*/


			modelBuilder.Entity<Producto>().ToTable("Producto")
				.HasKey(p => new { p.CodigoProducto });
			modelBuilder.Entity<Producto>()
				.HasRequired<Categoria>(ca => ca.Categoria)
				.WithMany(ca => ca.Productos)
				.HasForeignKey<int>(p => p.CodigoCategoria);
			modelBuilder.Entity<Producto>()
				.HasRequired<TipoEmpaque>(t => t.TipoEmpaque)
				.WithMany(t => t.Productos)
				.HasForeignKey<int>(p => p.CodigoEmpaque);
			modelBuilder.Entity<Producto>()
				.Property(p => p.PrecioUnitario)
				.IsRequired();
			modelBuilder.Entity<Producto>()
				.Property(p => p.PrecioPorDocena)
				.IsRequired();
			modelBuilder.Entity<Producto>()
				.Property(p => p.PrecioPorMayor)
				.IsRequired();


            modelBuilder.Entity<Proveedor>().ToTable("Proveedor")
                .HasKey(pr => new { pr.CodigoProveedor })
                .Property(pr => pr.Nit)
                .HasMaxLength(64)
				.IsRequired();
            modelBuilder.Entity<Proveedor>()
                .Property(pr => pr.RazonSocial)
				.HasMaxLength(128)
				.IsRequired();
            modelBuilder.Entity<Proveedor>()
                .Property(pr => pr.Direccion)
                .HasMaxLength(128)
				.IsRequired();
            modelBuilder.Entity<Proveedor>()
                .Property(pr => pr.PaginaWeb)
                .HasMaxLength(64)
				.IsRequired();
            modelBuilder.Entity<Proveedor>()
                .Property(e => e.ContactoPrincipal)
                .HasMaxLength(64)
				.IsRequired();


			modelBuilder.Entity<TelefonoCliente>()
				.ToTable("TelefonoCliente")
				.HasKey(t => new { t.CodigoTelefono })
				.Property(t => t.Numero)
				.HasMaxLength(32)
				.IsRequired();
			modelBuilder.Entity<TelefonoCliente>()
				.HasRequired<Cliente>(c => c.Cliente)
				.WithMany(c => c.TelefonoClientes)
				.HasForeignKey<string>(t => t.Nit);


			modelBuilder.Entity<TelefonoProveedor>()
				.ToTable("TelefonoProveedor")
				.HasKey(tp => new { tp.CodigoTelefono })
				.Property(tp => tp.Numero)
				.IsRequired()
				.HasMaxLength(32);
			modelBuilder.Entity<TelefonoProveedor>()
				.HasRequired<Proveedor>(pr => pr.Proveedor)
				.WithMany(pr => pr.TelefonoProveedors)
				.HasForeignKey<int>(tp => tp.CodigoProveedor);


            modelBuilder.Entity<TipoEmpaque>().ToTable("TipoEmpaque")
                .HasKey(t => new { t.CodigoEmpaque })
                .Property(t => t.Descripcion)
                .HasMaxLength(128)
				.IsRequired();

        }
    }
}
