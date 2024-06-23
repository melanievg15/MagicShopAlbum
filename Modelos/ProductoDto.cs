using System.ComponentModel.DataAnnotations;

namespace MagicShopAlbum.Modelos
{
	public class ProductoDto
	{
        // Declaración de una propiedad pública de tipo string con getter y setter automáticos.
        // Se establece un atributo que indica que esta propiedad es obligatoria.
        // Se establece un atributo que limita la longitud máxima de la cadena a 100 caracteres.
        [Required, MaxLength(100)]
        public string nombre { get; set; } = ""; // Inicialización de la propiedad con una cadena vacía.

        // Declaración de una propiedad pública de tipo string con getter y setter automáticos.
        // Se establece un atributo que indica que esta propiedad es obligatoria.
        // Se establece un atributo que limita la longitud máxima de la cadena a 100 caracteres.
        [Required, MaxLength(100)]
        public string artista { get; set; } = ""; // Inicialización de la propiedad con una cadena vacía.

        // Declaración de una propiedad pública de tipo decimal con getter y setter automáticos.
        // Se establece un atributo que indica que esta propiedad es obligatoria.
        [Required]
        public decimal precio { get; set; }

        // Declaración de una propiedad pública de tipo string con getter y setter automáticos.
        // Se establece un atributo que indica que esta propiedad es obligatoria.
        // Se establece un atributo que limita la longitud máxima de la cadena a 100 caracteres.
        [Required, MaxLength(100)]
        public string tipo { get; set; } = ""; // Inicialización de la propiedad con una cadena vacía.

        // Declaración de una propiedad pública de tipo entero con getter y setter automáticos.
        // Se establece un atributo que indica que esta propiedad es obligatoria.
        [Required]
        public int cantidad { get; set; }
    }
}
