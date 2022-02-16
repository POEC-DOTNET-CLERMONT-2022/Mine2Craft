using AutoMapper;
using Dtos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Persistance;

namespace Mine2CraftApi.Controllers;

[Route("api/[controller]")]
[ApiController]
//TODO: à supprimer
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
    
    [HttpPut("{guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public IActionResult Put(Guid guid, [FromBody] ToolDto toolToCreate)
    {
        try
        {
            var toolEntity = _mapper.Map<ToolEntity>(toolToCreate);
            var updateEntity = _completeItemRepository.Update(toolEntity);
            if (updateEntity == false)
                return NotFound();
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
}