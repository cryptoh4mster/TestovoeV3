using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestovoeV3.ViewModels
{
    public class IndexFileViewModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public IFormFile File { get; set; }
    }
}
