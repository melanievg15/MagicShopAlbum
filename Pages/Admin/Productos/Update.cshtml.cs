using MagicShopAlbum.DB;
using MagicShopAlbum.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicShopAlbum.Pages.Admin.Productos
{
    // Clase UpdateModel que hereda de PageModel
    public class UpdateModel : PageModel
    {
        // Campos privados para el entorno de alojamiento web y el contexto de base de datos
        private readonly IWebHostEnvironment environment;
        private readonly AppDBContext context;

        // Propiedad para vincular datos del DTO del producto
        [BindProperty]
        public ProductoDto ProductoDto { get; set; } = new ProductoDto();

        // Propiedad para almacenar el producto
        public Producto Producto { get; set; } = new Producto();

        // Variables para almacenar mensajes de error y éxito
        public string errorMessage = "";
        public string successMessage = "";

        // Constructor que inicializa el entorno de alojamiento web y el contexto de base de datos
        public UpdateModel(IWebHostEnvironment environment, AppDBContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        // Método que se ejecuta en las solicitudes GET
        public void OnGet(int? id)
        {
            // Si el ID es nulo, redirige a la página principal de administración de productos
            if (id == null)
            {
                Response.Redirect("/Admin/Productos/Home");
                return;
            }

            // Busca el producto en la base de datos por su ID
            var producto = context.Albumes.Find(id);
            // Si no se encuentra el producto, redirige a la página principal de administración de productos
            if (producto == null)
            {
                Response.Redirect("/Admin/Productos/Home");
                return;
            }

            // Rellena el DTO del producto con los datos del producto encontrado
            ProductoDto.nombre = producto.nombre;
            ProductoDto.artista = producto.artista;
            ProductoDto.precio = producto.precio;
            ProductoDto.tipo = producto.tipo;
            ProductoDto.cantidad = producto.cantidad;

            // Asigna el producto encontrado a la propiedad Producto
            Producto = producto;
        }

        // Método que se ejecuta en las solicitudes POST
        public void OnPost(int? id)
        {
            // Si el ID es nulo, redirige a la página principal de administración de productos
            if (id == null)
            {
                Response.Redirect("/Admin/Productos/Home");
                return;
            }

            /*
            // Verifica si el modelo es válido
            if (!ModelState.IsValid)
            {
                errorMessage = "Por favor, complete todos los campos";  // Establece el mensaje de error
                return;  // Salida temprana si el modelo no es válido
            }
            */

            // Busca el producto en la base de datos por su ID
            var producto = context.Albumes.Find(id);
            // Si no se encuentra el producto, redirige a la página principal de administración de productos
            if (producto == null)
            {
                Response.Redirect("/Admin/Productos/Home");
                return;
            }

            // Actualiza el producto en la base de datos con los datos del DTO
            producto.nombre = ProductoDto.nombre;
            producto.artista = ProductoDto.artista;
            producto.precio = ProductoDto.precio;
            producto.tipo = ProductoDto.tipo;
            producto.cantidad = ProductoDto.cantidad;

            // Guarda los cambios en la base de datos
            context.SaveChanges();

            // Asigna el producto actualizado a la propiedad Producto
            Producto = producto;

            // Establece el mensaje de éxito
            successMessage = "Album actualizado";

            // Redirige a la página principal de administración de productos
            Response.Redirect("/Admin/Productos/Home");
        }
    }
}