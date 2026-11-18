using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tp_2_C_ASP.NET.Pages.CityManager
{
    public class CityDetailsModel : PageModel
    {
        public string CityName { get; set; } = string.Empty;

        public void OnGet(string cityName)
        {
            CityName = cityName ?? string.Empty;
        }
    }
}