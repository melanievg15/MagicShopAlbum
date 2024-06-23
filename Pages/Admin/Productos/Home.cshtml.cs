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

        public List<Producto> Productos { get; set; } = new List<Producto>(); // Lista de productos para mostrar en la p�gina

        public string SearchQuery { get; set; } // Variable para almacenar la cadena de b�squeda

        public string SearchType { get; set; } // Variable para almacenar el tipo de b�squeda

        public HomeModel(AppDBContext context)
        {
            this.context = context; // Inicializaci�n del contexto de la base de datos en el constructor
        }

        public async Task OnGetAsync(string searchQuery, string searchType)
        {
            IQueryable<Producto> productosQuery = context.Albumes; // Consulta inicial de todos los productos desde la base de datos

            // Verifica si hay valores de b�squeda no nulos o vac�os
            if (!string.IsNullOrEmpty(searchQuery) && !string.IsNullOrEmpty(searchType))
            {
                // Convierte el tipo de b�squeda a min�sculas para asegurar la comparaci�n no sensible a may�sculas/min�sculas
                switch (searchType.ToLower())
                {
                    case "nombre":
                        // Filtra los productos cuyo nombre contiene la cadena de b�squeda
                        productosQuery = productosQuery.Where(p => p.nombre.Contains(searchQuery));
                        break;
                    case "artista":
                        // Filtra los productos cuyo artista contiene la cadena de b�squeda
                        productosQuery = productosQuery.Where(p => p.artista.Contains(searchQuery));
                        break;
                    case "precio":
                        // Intenta convertir la cadena de b�squeda a decimal para filtrar por precio
                        if (decimal.TryParse(searchQuery, out var precio))
                        {
                            productosQuery = productosQuery.Where(p => p.precio == precio);
                        }
                        break;
                    default:
                        break; // No hace nada si el tipo de b�squeda no coincide con los casos anteriores
                }
            }

            // Ejecuta la consulta y carga los productos filtrados en la lista Productos
            Productos = await productosQuery.ToListAsync();
        }
    }
}