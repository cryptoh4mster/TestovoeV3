using Microsoft.AspNetCore.Http;

namespace TestovoeV3BLL.DTO
{
    /// <summary>
    /// ДТО для добавления файла
    /// </summary>
    public class CreateFileDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public IFormFile File { get; set; }
    }
}
