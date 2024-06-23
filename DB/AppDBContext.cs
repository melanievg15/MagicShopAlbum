using MagicShopAlbum.Modelos;
using Microsoft.EntityFrameworkCore;

namespace MagicShopAlbum.DB
{
    // Define la clase AppDBContext que hereda de DbContext
    public class AppDBContext : DbContext
    {
        // Constructor que recibe DbContextOptions para configurar el contexto de base de datos
        public AppDBContext(DbContextOptions options) : base(options)
        {
            // Constructor que pasa las opciones al constructor base de DbContext
        }

        // Propiedad DbSet que representa la tabla "Albumes" en la base de datos
        public DbSet<Producto> Albumes { get; set; }
    }
}