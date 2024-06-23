using MagicShopAlbum.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MagicShopAlbum.Pages.Admin.Productos
{
    // Clase DropModel que hereda de PageModel
    public class DropModel : PageModel
    {
        private readonly AppDBContext context; // Declara una variable privada para almacenar el contexto de la base de datos

        public string errorMessage = ""; // Declara una variable pública para almacenar mensajes de error (actualmente no utilizada)

        // Constructor que recibe el contexto de la base de datos mediante inyección de dependencias
        public DropModel(AppDBContext context)
        {
            this.context = context; // Asigna el contexto de la base de datos recibido al campo privado context
        }

        // Método llamado cuando se realiza una solicitud GET a la página
        public void OnGet(int? id)
        {
            if (id == null)
            {
                // Si el parámetro id es nulo, redirige al usuario a la página principal de administración y termina la ejecución del método
                Response.Redirect("/Admin/Productos/Home");
                return;
            }

            // Busca un álbum en la base de datos con el id proporcionado
            var producto = context.Albumes.Find(id);
            if (producto == null)
            {
                // Si no se encuentra el álbum con el id proporcionado, redirige al usuario a la página principal de administración y termina la ejecución del método
                Response.Redirect("/Admin/Productos/Home");
                return;
            }

            // Si se encuentra el álbum, pasa su nombre y id a la vista utilizando ViewData para mostrar información al usuario
            ViewData["AlbumName"] = producto.nombre;
            ViewData["AlbumId"] = producto.id;
        }

        // Método llamado cuando se envía un formulario con el método POST
        public void OnPost(int? id)
        {
            if (id == null)
            {
                // Si el parámetro id es nulo, redirige al usuario a la página principal de administración y termina la ejecución del método
                Response.Redirect("/Admin/Productos/Home");
                return;
            }

            // Busca un álbum en la base de datos con el id proporcionado
            var producto = context.Albumes.Find(id);
            if (producto == null)
            {
                // Si no se encuentra el álbum con el id proporcionado, redirige al usuario a la página principal de administración y termina la ejecución del método
                Response.Redirect("/Admin/Productos/Home");
                return;
            }

            // Si se encuentra el álbum, se procede a eliminarlo de la base de datos
            context.Albumes.Remove(producto); // Marca el álbum para ser eliminado
            context.SaveChanges(); // Guarda los cambios en la base de datos

            // Después de eliminar el álbum, redirige al usuario a la página principal de administración
            Response.Redirect("/Admin/Productos/Home");
        }
    }
}
