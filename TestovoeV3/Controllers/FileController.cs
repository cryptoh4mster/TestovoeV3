using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestovoeV3.Logger;
using TestovoeV3.ViewModels;
using TestovoeV3BLL.DTO;
using TestovoeV3BLL.Services;

namespace TestovoeV3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly ILoggerManager _logger;
        public FileController(IFileService fileService, IMapper mapper, ILoggerManager logger)
        {
            _fileService = fileService;
            _mapper = mapper;
            _logger = logger;
        }
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

        [HttpPost]
        [Route("files/add")]
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

        [HttpDelete]
        [Route("files/{id}")]
        public async Task<ActionResult> DeleteMovieById(int id)
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
