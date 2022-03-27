using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestovoeV3.ViewModels
{
    public class IndexFileViewModel
    {
        public string FileName { get; set; }
        public IFormFile Image { get; set; }
    }
}
