using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeV3BLL.DTO;
using TestovoeV3DAL.Entities;
using TestovoeV3DAL.Interfaces;

namespace TestovoeV3BLL.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;
        public FileService(IFileRepository fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<IndexFileDTO>> GetFiles()
        {
            IEnumerable<File> files = await _fileRepository.GetFiles();
            IEnumerable<IndexFileDTO> filesDTOs = _mapper.Map<IEnumerable<IndexFileDTO>>(files);
            return filesDTOs;
        }

        public async Task<IndexFileDTO> GetFileById(int id)
        {
            File file = await _fileRepository.GetFileById(id);
            IndexFileDTO fileDTO = _mapper.Map<IndexFileDTO>(file);
            return fileDTO;
        }

        public async Task DeleteFileById(int id)
        {
            await _fileRepository.DeleteFileById(id);
        }

        public async Task<CreateFileDTO> AddFile(CreateFileDTO fileDTO)
        {
            File file = _mapper.Map<File>(fileDTO);
            File fileForMapping = await _fileRepository.AddFile(file);
            return _mapper.Map<CreateFileDTO>(fileForMapping);
        }

    }
}
