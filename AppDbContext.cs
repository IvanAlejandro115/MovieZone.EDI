using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MovieZone
{
    // 🗄️ TU CLASE CONTEXTO: Representa la base de datos real en C#
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Tablas de la base de datos
        public DbSet<PeliculaColeccion> PeliculasColeccion { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Precarga (Seed Data) de categorías para cumplir con la rúbrica y poblar el desplegable
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Acción / DC Comics" },
                new Categoria { Id = 2, Nombre = "Aventura / Fantasía" },
                new Categoria { Id = 3, Nombre = "Terror / Paranormal" },
                new Categoria { Id = 4, Nombre = "Animación / Videojuegos" },
                new Categoria { Id = 5, Nombre = "Acción / Suspenso" }
            );
        }
    }

    // SEGUNDA ENTIDAD (TABLA RELACIONADA): Categorías
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = "";

        // Propiedad de navegación: una categoría tiene muchas películas
        public List<PeliculaColeccion> Peliculas { get; set; } = new();
    }


    // ENTIDAD PRINCIPAL: PeliculaColeccion vinculada a Categoria
    public class PeliculaColeccion
    {
        [Key] // Define que este campo es la Llave Primaria automática (Exigido en Unidad 3)
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Titulo { get; set; } = "";

        [Required]
        public string Etiqueta { get; set; } = "";

        public string Imagen { get; set; } = "";

        // CLAVE FORÁNEA (Foreign Key) exigida para la relación entre las dos entidades
        public int? CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}

