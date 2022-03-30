using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.IO.Compression;

namespace TestovoeV3BLL.Helpers
{
    /// <summary>
    /// Класс для преобразования IFormFile в bytes[]
    /// </summary>
    public class FileToByteResolver : IValueConverter<IFormFile, byte[]>
    {
        public byte[] Convert(IFormFile file, ResolutionContext context)
        {
            if (file.Length > 0)
            {
                using (var input = new MemoryStream())
                {
                    using (var compressor = new GZipStream(input, CompressionMode.Compress))
                    {
                        file.CopyTo(compressor);
                    }
                    return input.ToArray();
                }
            }
            return null;
        }
    }
}
