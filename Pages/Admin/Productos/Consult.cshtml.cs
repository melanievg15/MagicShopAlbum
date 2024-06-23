using MagicShopAlbum.DB;
using MagicShopAlbum.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicShopAlbum.Pages.Admin.Productos
{
    public class ConsultModel : PageModel
    {
        private readonly AppDBContext context;

        public string Nombre { get; set; }

        public List<Producto> Productos { get; set; } = new List<Producto>();

        public ConsultModel(AppDBContext context)
        {
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                Response.Redirect("/Admin/Productos/Home");
                return;
            }

            Productos = context.Albumes.Where(a => a.nombre.Contains(Nombre)).ToList();

            Response.Redirect("/Admin/Productos/Home");
            return;
        }
    }
}