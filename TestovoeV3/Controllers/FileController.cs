using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TestovoeV3.Logger;
using TestovoeV3.ViewModels;
using TestovoeV3BLL.DTO;
using TestovoeV3BLL.Services;

namespace TestovoeV3.Controllers
{
    /// <summary>
    /// Контроллер для работы с файлами
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly ILoggerManager _logger;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="fileService">Сервис для работы с файлами из BLL</param>
        /// <param name="mapper">Класс для маппинга VM->DTO DTO->VM</param>
        /// <param name="logger">Класс для логгирования ошибок</param>
        public FileController(IFileService fileService, IMapper mapper, ILoggerManager logger)
        {
            _fileService = fileService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Получение всех файлов и передача на клиент
        /// </summary>
        /// <returns>Список VM файлов</returns>
        [HttpGet]
        [Route("files")]
        public async Task<ActionResult<IEnumerable<IndexFileViewModel>>> GetFiles()
        {
            IEnumerable<IndexFileDTO> fileDTOs = await _fileService.GetFiles();
            IEnumerable<IndexFileViewModel> fileViewModels = _mapper.Map<IEnumerable<IndexFileViewModel>>(fileDTOs);
            if(fileViewModels == null)
            {
                return NotFound(new { message = "Файлы не найдены" });
            }
            return Ok(fileViewModels);
        }

        /// <summary>
        /// Получить файл по id и передать на клиент
        /// </summary>
        /// <param name="id">Id файла</param>
        /// <returns>VM файл</returns>
        [HttpGet]
        [Route("files/{id}")]
        public async Task<ActionResult<IndexFileViewModel>> GetFileById(int id)
        {
            try
            {
                IndexFileDTO fileDTO = await _fileService.GetFileById(id);
                IndexFileViewModel fileViewModel = _mapper.Map<IndexFileViewModel>(fileDTO);
                return Ok(fileViewModel);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound("Файла с таким id не существует");
            }
        }

        /// <summary>
        /// Получить с клиента VM файла и отправить VM нового файла в BLL
        /// </summary>
        /// <param name="fileViewModel">VM файла</param>
        /// <returns>Добавленный VM файла</returns>
        [HttpPost]
        [Route("files")]
        public async Task<ActionResult<CreateFileViewModel>> AddFile([FromForm] CreateFileViewModel fileViewModel)
        {
            try
            {
                CreateFileDTO fileDTO = _mapper.Map<CreateFileDTO>(fileViewModel);

                fileViewModel = _mapper.Map<CreateFileViewModel>(await _fileService.AddFile(fileDTO));

                return Ok(fileViewModel);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound("Возникли проблемы с загрузкой файла");
            }
        }

        /// <summary>
        /// Удалить файл по Id
        /// </summary>
        /// <param name="id">Id файла</param>
        /// <returns>Результат операции</returns>
        [HttpDelete]
        [Route("files/{id}")]
        public async Task<ActionResult> DeleteFileById(int id)
        {
            try
            {
                await _fileService.DeleteFileById(id);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound("Файла с таким id не существует");
            }
        }
    }
}
