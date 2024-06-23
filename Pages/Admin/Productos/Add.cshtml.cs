using MagicShopAlbum.DB;
using MagicShopAlbum.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicShopAlbum.Pages.Admin.Productos
{
    // Clase AddModel que hereda de PageModel
    public class AddModel : PageModel
    {
        // Campos privados para el entorno de alojamiento web y el contexto de base de datos
        private readonly IWebHostEnvironment environment;
        private readonly AppDBContext context;

        // Propiedad para vincular datos de producto
        [BindProperty]
        public ProductoDto ProductoDto { get; set; } = new ProductoDto();

        // Constructor que inicializa el entorno de alojamiento web y el contexto de base de datos
        public AddModel(IWebHostEnvironment environment, AppDBContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        // Método OnGet que se ejecuta en las solicitudes GET
        public void OnGet()
        {
        }

        // Variables para almacenar mensajes de error y éxito
        public string errorMessage = "";
        public string successMessage = "";

        // Método OnPost que se ejecuta en las solicitudes POST
        public void OnPost()
        {
            // Verifica si el modelo es válido
            if (!ModelState.IsValid)
            {
                errorMessage = "Por favor, complete todos los campos";  // Establece el mensaje de error
                return;  // Salida temprana si el modelo no es válido
            }

            // Crear un nuevo objeto Producto con los datos del formulario
            Producto producto = new Producto()
            {
                nombre = ProductoDto.nombre,
                artista = ProductoDto.artista,
                precio = ProductoDto.precio,
                tipo = ProductoDto.tipo,
                cantidad = ProductoDto.cantidad,
            };

            // Agrega el nuevo producto a la base de datos
            context.Albumes.Add(producto);
            context.SaveChanges();  // Guarda los cambios en la base de datos

            // Limpia el formulario
            ProductoDto.nombre = "";
            ProductoDto.artista = "";
            ProductoDto.precio = 0;
            ProductoDto.tipo = "";
            ProductoDto.cantidad = 0;

            // Limpia el estado del modelo
            ModelState.Clear();

            // Establece el mensaje de éxito
            successMessage = "Album agregado";

            // Redirige a la página principal de administración de productos
            Response.Redirect("/Admin/Productos/Home");
        }
    }
}