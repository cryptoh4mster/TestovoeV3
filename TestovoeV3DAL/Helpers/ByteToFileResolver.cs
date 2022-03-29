using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.IO.Compression;

namespace TestovoeV3DAL.Helpers
{
    /// <summary>
    /// Класс для преобразования byte[] в IFormFile
    /// Используется встроенная в .net функция для сжатия массива байтов
    /// </summary>
    public class ByteToFileResolver : IValueConverter<byte[], IFormFile>
    {
        public IFormFile Convert(byte[] data, ResolutionContext context)
        {
            using (var input = new MemoryStream(data))
            {
                using (var decompressor = new GZipStream(input, CompressionMode.Decompress))
                {
                    using (var output = new MemoryStream())
                    {
                        decompressor.CopyTo(output);
                        IFormFile file = new FormFile(output, 0, output.Length, "name", "fileName")
                        {
                            Headers = new HeaderDictionary(),
                            ContentType = "application/json",
                            ContentDisposition = "form-data"
                        };
                        System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
                        {
                            FileName = file.FileName
                        };
                        return file;
                    }
                }
            }
        }
    }
}
