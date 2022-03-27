using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.IO.Compression;

namespace TestovoeV3DAL.Helpers
{
    //TODO: Сделать нормально contenttype и имя файла и contentdisposition
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
                            ContentType = "test",
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
