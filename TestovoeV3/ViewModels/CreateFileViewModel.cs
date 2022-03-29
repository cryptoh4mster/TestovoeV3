using Microsoft.AspNetCore.Http;

namespace TestovoeV3.ViewModels
{
    public class CreateFileViewModel
    {
        /// <summary>
        /// ViewModel для добавления файла
        /// </summary>
        public int Id { get; set; }
        public string FileName { get; set; }
        public IFormFile File { get; set; }
    }
}
