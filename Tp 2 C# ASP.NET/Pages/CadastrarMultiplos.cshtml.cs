using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tp_2_C_ASP.NET.Pages.CityManager
{
    public class CadastrarMultiplosModel : PageModel
    {
        [BindProperty]
        public List<InputModel>
    Inputs { get; set; } = new();

    public List<Country>
        SubmittedCountries { get; set; } = new();

        public class InputModel
        {
        public string CountryName { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        }

        public void OnGet()
        {
        for (int i = 0; i < 5; i++)
        {
        Inputs.Add(new InputModel());
        }
        }

        public IActionResult OnPost()
        {
        foreach (var item in Inputs)
        {
        if (!string.IsNullOrWhiteSpace(item.CountryName) && !string.IsNullOrWhiteSpace(item.CountryCode))
        {
        SubmittedCountries.Add(new Country
        {
        CountryName = item.CountryName,
        CountryCode = item.CountryCode
        });
        }
        }

        while (Inputs.Count < 5)
        {
        Inputs.Add(new InputModel());
        }

        return Page();
        }
    }
}
