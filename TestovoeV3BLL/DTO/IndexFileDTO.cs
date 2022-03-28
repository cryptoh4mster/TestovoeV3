using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeV3BLL.DTO
{
    public class IndexFileDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public IFormFile File { get; set; }
    }
}
