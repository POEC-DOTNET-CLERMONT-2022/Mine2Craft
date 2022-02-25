using AutoMapper;
using Dtos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Persistance;

namespace Mine2CraftApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FurnaceController : ControllerBase
{
    private readonly IRepositoryGeneric<FurnaceEntity> _furnaceRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<FurnaceController> _logger;
        
    public FurnaceController(IRepositoryGeneric<FurnaceEntity> furnaceRepository, IMapper mapper, ILogger<FurnaceController> logger)
    {
        _furnaceRepository = furnaceRepository;
        _mapper = mapper;
        _logger = logger;
    }
    
    // GET: api/<FurnaceController>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public IActionResult Get()
    { 
        try
        {
            var furnaceEntities = _furnaceRepository.GetAll();
            var furnaceDtos = _mapper.Map<IEnumerable<FurnaceDto>>(furnaceEntities);
            return Ok(furnaceDtos);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occured during get all request on complete item");
            return StatusCode(500);
        }
    }
    
    // POST api/<FurnaceControlle>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public IActionResult Post([FromBody] FurnaceDto furnaceDtoToCreate)
    {
        try
        {
            var furnaceEntityoCreate = _mapper.Map<FurnaceEntity>(furnaceDtoToCreate);
            return Ok(_furnaceRepository.Create(furnaceEntityoCreate).ToString());
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occured during post request on complete item");
            return StatusCode(500);
        }
        
    }
    
    // PUT api/<CompleteItemController>/5
    [HttpPut("{guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public IActionResult Put(Guid guid, [FromBody] FurnaceDto furnaceDtoToUpdate)
    {
        try
        {
            var furnaceEntityToUpdate = _mapper.Map<FurnaceEntity>(furnaceDtoToUpdate);
            return Ok(_furnaceRepository.Update(furnaceEntityToUpdate).ToString());
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occured during put request on complete item");
            return StatusCode(500);
        }
           
    }
    
    // DELETE api/<CompleteItemController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public IActionResult Delete(Guid id)
    {
        try
        {
            return Ok(_furnaceRepository.Delete(id).ToString()); 
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occured during delete request on complete item");
            return StatusCode(500);
        }
            
    }
}