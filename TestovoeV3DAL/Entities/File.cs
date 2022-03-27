using System;
using System.Collections.Generic;
using System.Text;

namespace TestovoeV3DAL.Entities
{
    public class File
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public float Size { get; set; }
        public byte[] Data { get; set; }
    }
}
