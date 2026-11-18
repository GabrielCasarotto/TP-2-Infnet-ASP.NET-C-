using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tp_2_C_ASP.NET.Pages.CityManager
{
    public class NoteItem
    {
        public string FileName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }

    public class ListNotesModel : PageModel
    {
        private readonly IWebHostEnvironment _env;

        public ListNotesModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public List<NoteItem>
    Notes { get; set; } = new();

    public void OnGet()
    {
    string uploadsFolder = Path.Combine(_env.WebRootPath, "files");
    if (Directory.Exists(uploadsFolder))
    {
    string[] files = Directory.GetFiles(uploadsFolder, "*.txt");

    foreach (string filePath in files)
    {
    string fileName = Path.GetFileName(filePath);
    string content = System.IO.File.ReadAllText(filePath);

    Notes.Add(new NoteItem
    {
    FileName = fileName,
    Content = content
    });
    }
    }
   }
  }
}
