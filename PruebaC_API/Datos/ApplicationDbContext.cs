using Microsoft.EntityFrameworkCore;
using PruebaC_API.Modelos;

namespace PruebaC_API.Datos
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
                
        }
        public DbSet<Prueba> Pruebas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prueba>().HasData(
                new Prueba()
            {
                Id = 1,
                Nombre = "Algun Nombre",
                Detalle = "Algun detalle",
                ImagenUrl = "",
                Distancia = 10,
                Ocupantes = 5,
                Amenidad = "",
                Tarifa = 100,
                Fechacreacion = DateTime.Now,
                FechaActualizacion = DateTime.Now,

                },
             new Prueba()
             {
                 Id = 2,
                 Nombre = "Algun Nombre",
                 Detalle = "Algun detalle",
                 ImagenUrl = "",
                 Distancia = 10,
                 Ocupantes = 5,
                 Amenidad = "",
                 Tarifa = 100,
                 Fechacreacion = DateTime.Now,
                 FechaActualizacion = DateTime.Now,

             
                }
            );
        }
    }
}
