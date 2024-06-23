using MagicShopAlbum.DB;
using MagicShopAlbum.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MagicShopAlbum.Pages.Admin.Productos
{
    public class HomeModel : PageModel
    {
        private readonly AppDBContext context; // Contexto de la base de datos

        public List<Producto> Productos { get; set; } = new List<Producto>(); // Lista de productos para mostrar en la página

        public string SearchQuery { get; set; } // Variable para almacenar la cadena de búsqueda

        public string SearchType { get; set; } // Variable para almacenar el tipo de búsqueda

        public HomeModel(AppDBContext context)
        {
            this.context = context; // Inicialización del contexto de la base de datos en el constructor
        }

        public async Task OnGetAsync(string searchQuery, string searchType)
        {
            IQueryable<Producto> productosQuery = context.Albumes; // Consulta inicial de todos los productos desde la base de datos

            // Verifica si hay valores de búsqueda no nulos o vacíos
            if (!string.IsNullOrEmpty(searchQuery) && !string.IsNullOrEmpty(searchType))
            {
                // Convierte el tipo de búsqueda a minúsculas para asegurar la comparación no sensible a mayúsculas/minúsculas
                switch (searchType.ToLower())
                {
                    case "nombre":
                        // Filtra los productos cuyo nombre contiene la cadena de búsqueda
                        productosQuery = productosQuery.Where(p => p.nombre.Contains(searchQuery));
                        break;
                    case "artista":
                        // Filtra los productos cuyo artista contiene la cadena de búsqueda
                        productosQuery = productosQuery.Where(p => p.artista.Contains(searchQuery));
                        break;
                    case "precio":
                        // Intenta convertir la cadena de búsqueda a decimal para filtrar por precio
                        if (decimal.TryParse(searchQuery, out var precio))
                        {
                            productosQuery = productosQuery.Where(p => p.precio == precio);
                        }
                        break;
                    default:
                        break; // No hace nada si el tipo de búsqueda no coincide con los casos anteriores
                }
            }

            // Ejecuta la consulta y carga los productos filtrados en la lista Productos
            Productos = await productosQuery.ToListAsync();
        }
    }
}