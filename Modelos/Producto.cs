using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MagicShopAlbum.Modelos
{
	public class Producto
	{
        // Declaración de una propiedad pública de tipo entero con getter y setter automáticos.
        public int id { get; set; }

        // Declaración de una propiedad pública de tipo string con getter y setter automáticos.
        // Se establece un atributo que limita la longitud máxima de la cadena a 100 caracteres.
        [MaxLength(100)]
        public string nombre { get; set; } = ""; // Inicialización de la propiedad con una cadena vacía.

        // Declaración de una propiedad pública de tipo string con getter y setter automáticos.
        // Se establece un atributo que limita la longitud máxima de la cadena a 100 caracteres.
        [MaxLength(100)]
        public string artista { get; set; } = ""; // Inicialización de la propiedad con una cadena vacía.

        // Declaración de una propiedad pública de tipo decimal con getter y setter automáticos.
        // Se establece un atributo de precisión con un total de 16 dígitos y 2 decimales.
        [Precision(16, 2)]
        public decimal precio { get; set; }

        // Declaración de una propiedad pública de tipo string con getter y setter automáticos.
        // Se establece un atributo que limita la longitud máxima de la cadena a 100 caracteres.
        [MaxLength(100)]
        public string tipo { get; set; } = ""; // Inicialización de la propiedad con una cadena vacía.

        // Declaración de una propiedad pública de tipo entero con getter y setter automáticos.
        public int cantidad { get; set; }
    }
}
