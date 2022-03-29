using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestovoeV3.Controllers;
using TestovoeV3.Mappings;
using TestovoeV3.ViewModels;
using TestovoeV3BLL.DTO;
using TestovoeV3BLL.Services;
using Xunit;

namespace TestovoeV3.Tests
{
    public class FileControllerTests
    {
        private readonly Mock<IFileService> _fileService = new();
        private readonly FileController _controller;
        private readonly IMapper _mapper;
        
        readonly List<IndexFileDTO> fakeList = new List<IndexFileDTO> 
        { 
            new IndexFileDTO { FileName = "test1", File = null},
            new IndexFileDTO { FileName = "test2", File = null}
        };
        public FileControllerTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingsProfile());
            });

            _mapper = mockMapper.CreateMapper();
            _controller = new FileController(_fileService.Object, _mapper, null);
        }
        
        
        [Fact]
        public async Task GetAllFilesFromFileControllerAsync_ExpectListOfFiles()
        {
            //Arrange
            _fileService.Setup(service => service.GetFiles()).ReturnsAsync(fakeList);

            //Act
            var result = await _controller.GetFiles();
            
            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<IndexFileViewModel>>>(result);
            var returnValue = (actionResult.Result as OkObjectResult).Value as IEnumerable<IndexFileViewModel>;
            var checkReturnValue = Assert.IsAssignableFrom<IEnumerable<IndexFileViewModel>>(returnValue);
            var testFile = checkReturnValue.FirstOrDefault();

            Assert.Equal(2, checkReturnValue.Count());
            Assert.Equal("test1", testFile.FileName);
        }

        [Fact]
        public async Task AddFileFromFileControllerAsync_ExpectFile()
        {
            //Arrange
            var testFileDTO = new CreateFileDTO { FileName = "test3", File = null };
            var testFileViewModel = new CreateFileViewModel { FileName = "test3", File = null };

            _fileService.Setup(service => service.AddFile(It.IsAny<CreateFileDTO>())).ReturnsAsync(testFileDTO);
            
            //Act
            var result = await _controller.AddFile(testFileViewModel);

            //Assert
            var actionResult = Assert.IsType<ActionResult<CreateFileViewModel>>(result);
            var returnValue = (actionResult.Result as OkObjectResult).Value as CreateFileViewModel;
            var checkReturnValue = Assert.IsType<CreateFileViewModel>(returnValue);

            Assert.Equal("test3", checkReturnValue.FileName);
        }
    }
}
