using Microsoft.AspNetCore.Http;

namespace TestovoeV3.ViewModels
{
    public class CreateFileViewModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public IFormFile File { get; set; }
    }
}
