using AutoMapper;
using Dtos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Models;
using Persistance;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mine2CraftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompleteItemController : ControllerBase
    {
        private readonly IRepositoryGeneric<CompleteItemEntity> _completeItemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CompleteItemController> _logger;
        
        public CompleteItemController(IRepositoryGeneric<CompleteItemEntity> completeItemRepository, IMapper mapper, ILogger<CompleteItemController> logger)
        {
            _completeItemRepository = completeItemRepository;
            _mapper = mapper;
            _logger = logger;
        }
        // GET: api/<CompleteItemController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        { 
            try
            {
                var completeItemEntities = _completeItemRepository.GetAll();
                var completeItemDtos = _mapper.Map<IEnumerable<CompleteItemDto>>(completeItemEntities);
                return Ok(completeItemDtos);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occured during get all request on complete item");
                return StatusCode(500);
            }
        }
        
        // POST api/<CompleteItemController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Post(CompleteItemDto completeItemDtoToCreate)
        {
            try
            {
                var completeItemEntityToCreate = _mapper.Map<CompleteItemEntity>(completeItemDtoToCreate);
                return Ok(_completeItemRepository.Create(completeItemEntityToCreate).ToString());
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
        public IActionResult Put(Guid guid, [FromBody] CompleteItemDto completeItemDtoToUpdate)
        {
            try
            {
                var completeItemEntityToCreate = _mapper.Map<CompleteItemEntity>(completeItemDtoToUpdate);
                return Ok(_completeItemRepository.Update(completeItemEntityToCreate).ToString());
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
                return Ok(_completeItemRepository.Delete(id).ToString()); 
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occured during delete request on complete item");
                return StatusCode(500);
            }
            
        }

    }
}
