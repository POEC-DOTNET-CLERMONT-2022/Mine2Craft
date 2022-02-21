using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dtos;
using Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mine2CraftApi.Controllers;
using Moq;
using Persistance;
using Xunit;

namespace Mine2CraftTest
{
    public class CompleteItemTest
    {
        private CompleteItemController CompleteItemController{ get; }

        private readonly IRepositoryGeneric<CompleteItemEntity> _completeItemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CompleteItemController> _logger;

        private readonly Mock<FakeRepositoryGeneric<CompleteItemEntity>> _mock =
            new Mock<FakeRepositoryGeneric<CompleteItemEntity>>();

        public CompleteItemTest()
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CompleteItemEntity, CompleteItemDto>()
                        .IncludeAllDerived();
            
                    cfg.CreateMap<CompleteItemDto, CompleteItemEntity>()
                        .IncludeAllDerived();
            
                    cfg.CreateMap<ArmorEntity, ArmorDto>().ReverseMap();
                    cfg.CreateMap<ToolEntity, ToolDto>().ReverseMap();
                    
                    cfg.CreateMap<ItemEntity, ItemDto>().ReverseMap();
                    
                    cfg.CreateMap<WorkbenchEntity, WorkbenchDto>().ReverseMap();
                }
            );

            _mapper = new Mapper(config);
            _completeItemRepository = new FakeRepositoryGeneric<CompleteItemEntity>();
            _logger = new LoggerFactory().CreateLogger<CompleteItemController>();
            
            //test unitaire avec fake repo
            //test de composant avec sqlRepo
            
            CompleteItemController = new CompleteItemController(_mock.Object, _mapper, _logger);
        }

        [Fact]
        public async Task GetAllCompleteItemTest()
        {
            //Arrange

            //Action
            var actionResultGetRequest = CompleteItemController.Get();

            //Assert
            actionResultGetRequest.Should().NotBeNull();
            
            var okResult = actionResultGetRequest as OkObjectResult;
            okResult.Should().NotBeNull();

            var completeItemDtos = okResult.Value as List<CompleteItemDto>;
            completeItemDtos.Count().Should().Be(15);
        }

        [Fact]
        public async Task CreateCompleteItemTest()
        {
            //Arrange
            CompleteItemDto toolToCreate =
                new ToolDto(Guid.NewGuid(), "test", 50, "Description", new List<WorkbenchDto>(), 10);
            _mock.Setup(repo => repo.Create(It.IsAny<ToolEntity>()))
                .Returns(() => Task.FromResult("1"));
            

            //Action
            var actionResultPostRequest = CompleteItemController.Post(toolToCreate);

            //Assert
            _mock.Verify(repo => repo.Create(It.IsAny<ToolEntity>()), Times.Once);
            actionResultPostRequest.Should().NotBeNull();
            
            var okResult = actionResultPostRequest as OkObjectResult;
            okResult.Should().NotBeNull();

            var numberOfInsertions = Int32.Parse(okResult.Value.ToString());
            numberOfInsertions.Should().Be(1);
        }
        
        [Fact]
        public async Task UpdateCompleteItemTest()
        {
            //Arrange
            var actionResultGetRequest = CompleteItemController.Get();
            var okResult = actionResultGetRequest as OkObjectResult;
            var completeItemDtos = okResult.Value as List<CompleteItemDto>;
            var firstCompleteItemDto = completeItemDtos.First();
            
            
            //Action
            var actionResultPutRequest = CompleteItemController.Put(firstCompleteItemDto.Id, firstCompleteItemDto);

            //Assert
            actionResultPutRequest.Should().NotBeNull();
            
            var okResultUpdate = actionResultPutRequest as OkObjectResult;
            okResultUpdate.Should().NotBeNull();

            var updateSucced = okResultUpdate.Value.ToString();
            updateSucced.Should().Be("True");
        }

        [Fact]
        public async Task DeleteCompleteItemTest()
        {
            //Arrange
            var actionResultGetRequest = CompleteItemController.Get();
            var okResult = actionResultGetRequest as OkObjectResult;
            var completeItemDtos = okResult.Value as List<CompleteItemDto>;
            var firstCompleteItemDto = completeItemDtos.First();
            
            //Action
            var actionResultDeleteRequest = CompleteItemController.Delete(firstCompleteItemDto.Id);

            //Assert
            actionResultDeleteRequest.Should().NotBeNull();
            
            var okResultDelete = actionResultDeleteRequest as OkObjectResult;
            okResultDelete.Should().NotBeNull();

            var numberOfDeletions = Int32.Parse(okResultDelete.Value.ToString());
            numberOfDeletions.Should().Be(1);
        }
    }
}