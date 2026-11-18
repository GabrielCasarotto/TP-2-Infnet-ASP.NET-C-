using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tp_2_C_ASP.NET.Pages.CityManager
{
    public class ListaCidadesModel : PageModel
    {
        public List<string>
    Cities { get; set; } = ["Rio", "São Paulo", "Brasília"];

        public void OnGet() {}
   }
}
