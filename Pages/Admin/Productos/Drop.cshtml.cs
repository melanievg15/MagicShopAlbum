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

        public string errorMessage = ""; // Declara una variable p�blica para almacenar mensajes de error (actualmente no utilizada)

        // Constructor que recibe el contexto de la base de datos mediante inyecci�n de dependencias
        public DropModel(AppDBContext context)
        {
            this.context = context; // Asigna el contexto de la base de datos recibido al campo privado context
        }

        // M�todo llamado cuando se realiza una solicitud GET a la p�gina
        public void OnGet(int? id)
        {
            if (id == null)
            {
                // Si el par�metro id es nulo, redirige al usuario a la p�gina principal de administraci�n y termina la ejecuci�n del m�todo
                Response.Redirect("/Admin/Productos/Home");
                return;
            }

            // Busca un �lbum en la base de datos con el id proporcionado
            var producto = context.Albumes.Find(id);
            if (producto == null)
            {
                // Si no se encuentra el �lbum con el id proporcionado, redirige al usuario a la p�gina principal de administraci�n y termina la ejecuci�n del m�todo
                Response.Redirect("/Admin/Productos/Home");
                return;
            }

            // Si se encuentra el �lbum, pasa su nombre y id a la vista utilizando ViewData para mostrar informaci�n al usuario
            ViewData["AlbumName"] = producto.nombre;
            ViewData["AlbumId"] = producto.id;
        }

        // M�todo llamado cuando se env�a un formulario con el m�todo POST
        public void OnPost(int? id)
        {
            if (id == null)
            {
                // Si el par�metro id es nulo, redirige al usuario a la p�gina principal de administraci�n y termina la ejecuci�n del m�todo
                Response.Redirect("/Admin/Productos/Home");
                return;
            }

            // Busca un �lbum en la base de datos con el id proporcionado
            var producto = context.Albumes.Find(id);
            if (producto == null)
            {
                // Si no se encuentra el �lbum con el id proporcionado, redirige al usuario a la p�gina principal de administraci�n y termina la ejecuci�n del m�todo
                Response.Redirect("/Admin/Productos/Home");
                return;
            }

            // Si se encuentra el �lbum, se procede a eliminarlo de la base de datos
            context.Albumes.Remove(producto); // Marca el �lbum para ser eliminado
            context.SaveChanges(); // Guarda los cambios en la base de datos

            // Despu�s de eliminar el �lbum, redirige al usuario a la p�gina principal de administraci�n
            Response.Redirect("/Admin/Productos/Home");
        }
    }
}
