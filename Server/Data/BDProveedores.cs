using BlazorApp_Act17.Shared.Clases;
using Microsoft.EntityFrameworkCore;
namespace BlazorApp_Act17.Server.Data
{
    public class BDProveedoresContext : DbContext
    {
        public BDProveedoresContext(DbContextOptions<BDProveedoresContext> options) : base(options)
        {

        }
        public DbSet<Proveedores> Proveedores /*Nombre que se le asigna a la tabla de la base de datos*/ { get; set; }
        public DbSet<Productos> Productos /*Nombre que se le asigna a la tabla de la base de datos*/ { get; set; }
        public DbSet<Ventas> Ventas { get; set; }


    }
}
