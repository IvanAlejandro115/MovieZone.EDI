using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MovieZone
{
    // 🗄️ TU CLASE CONTEXTO: Representa la base de datos real en C#
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Esta propiedad le dice a EF Core que fabrique una tabla llamada "PeliculasColeccion"
        public DbSet<PeliculaColeccion> PeliculasColeccion { get; set; }
    }

    // 📋 TU ENTIDAD (TABLA): El molde que se guardará físicamente en el disco
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
    }
}
