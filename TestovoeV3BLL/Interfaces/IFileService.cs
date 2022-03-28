using System.Collections.Generic;
using System.Threading.Tasks;
using TestovoeV3BLL.DTO;

namespace TestovoeV3BLL.Services
{
    public interface IFileService
    {
        Task<IEnumerable<IndexFileDTO>> GetFiles();
        Task<CreateFileDTO> AddFile(CreateFileDTO fileDTO);
        Task<IndexFileDTO> GetFileById(int id);
        Task DeleteFileById(int id);

    }
}
