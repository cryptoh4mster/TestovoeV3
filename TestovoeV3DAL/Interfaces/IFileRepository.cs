using System.Collections.Generic;
using System.Threading.Tasks;
using TestovoeV3DAL.Entities;

namespace TestovoeV3DAL.Interfaces
{
    public interface IFileRepository
    {
        Task<IEnumerable<File>> GetFiles();
        Task<File> GetFileById(int id);
        Task<File> AddFile(File file);
        Task DeleteFileById(int id);
    }   
}
