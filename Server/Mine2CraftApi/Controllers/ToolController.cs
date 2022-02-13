using AutoMapper;
using Dtos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Persistance;

namespace Mine2CraftApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToolController : ControllerBase
{
    private readonly IRepositoryGeneric<CompleteItemEntity> _completeItemRepository;
    private readonly IMapper _mapper;
        
    public ToolController(IRepositoryGeneric<CompleteItemEntity> completeItemRepository, IMapper mapper)
    {
        _completeItemRepository = completeItemRepository;
        _mapper = mapper;
    }
    
    // POST api/<CompleteItemController>
    [HttpPost]
    public IActionResult Post(ToolDto toolDtoToCreate)
    {
        var completeItemEntityToCreate = _mapper.Map<ToolEntity>(toolDtoToCreate);
        return Ok(_completeItemRepository.Create(completeItemEntityToCreate));
    }
}