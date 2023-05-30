using BlazorApp_Act17.Shared.Clases;
using Microsoft.EntityFrameworkCore;
namespace BlazorApp_Act17.Server.Data
{
    public class BDProveedoresContext : DbContext
    {
        public BDProveedoresContext(DbContextOptions<BDProveedoresContext> options) : base(options)
        {

        }
        public DbSet<Proveedores> Proveedores { get; set; } /*Nombre que se le asigna a la tabla de la base de datos*/ 
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Productos> Productos { get; set; } /*Nombre que se le asigna a la tabla de la base de datos*/ 

    }
}
