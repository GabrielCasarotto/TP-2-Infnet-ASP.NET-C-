using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tp_2_C_ASP.NET.Pages.CityManager
{
    public class SaveNoteModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        public SaveNoteModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public string SuccessMessage { get; set; } = string.Empty;
        public string DownloadUrl { get; set; } = string.Empty;

        public class InputModel
        {
            [Required(ErrorMessage = "O conteúdo da nota não pode estar vazio.")]
            public string Content { get; set; } = string.Empty;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string uploadsFolder = Path.Combine(_env.WebRootPath, "files");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            string fileName = $"note-{DateTime.Now:yyyyMMddHHmmssfff}.txt";
            string filePath = Path.Combine(uploadsFolder, fileName);

            System.IO.File.WriteAllText(filePath, Input.Content);

            SuccessMessage = $"Arquivo '{fileName}' salvo com sucesso!";
            DownloadUrl = $"/files/{fileName}";

            return Page();
        }
    }
}