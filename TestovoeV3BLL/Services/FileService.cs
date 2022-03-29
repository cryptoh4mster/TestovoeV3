using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestovoeV3BLL.DTO;
using TestovoeV3DAL.Entities;
using TestovoeV3DAL.Interfaces;

namespace TestovoeV3BLL.Services
{
    /// <summary>
    /// Сервис BLL для работы с файлами
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// Репозиторий для работы с файлами
        /// </summary>
        private readonly IFileRepository _fileRepository;
        /// <summary>
        /// Маппер
        /// </summary>
        private readonly IMapper _mapper;
        public FileService(IFileRepository fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Получить ДТО всех файлов
        /// </summary>
        /// <returns>ДТО всех файлов</returns>
        public async Task<IEnumerable<IndexFileDTO>> GetFiles()
        {
            IEnumerable<File> files = await _fileRepository.GetFiles();
            IEnumerable<IndexFileDTO> filesDTOs = _mapper.Map<IEnumerable<IndexFileDTO>>(files);
            return filesDTOs;
        }
        /// <summary>
        /// Получить файл по id и преобразовать в dto
        /// </summary>
        /// <param name="id"> Id файла</param>
        /// <returns>ДТО по Id</returns>
        public async Task<IndexFileDTO> GetFileById(int id)
        {
            File file = await _fileRepository.GetFileById(id);
            IndexFileDTO fileDTO = _mapper.Map<IndexFileDTO>(file);
            return fileDTO;
        }

        /// <summary>
        /// Удалить файл по Id
        /// </summary>
        /// <param name="id">Id файла</param>
        /// <returns></returns>
        public async Task DeleteFileById(int id)
        {
            await _fileRepository.DeleteFileById(id);
        }

        /// <summary>
        /// Добавить дто файла 
        /// </summary>
        /// <param name="fileDTO"> Дто файла для добавления в бд</param>
        /// <returns>Добавленный дто файл</returns>
        public async Task<CreateFileDTO> AddFile(CreateFileDTO fileDTO)
        {
            File file = _mapper.Map<File>(fileDTO);
            File fileForMapping = await _fileRepository.AddFile(file);
            return _mapper.Map<CreateFileDTO>(fileForMapping);
        }

    }
}
