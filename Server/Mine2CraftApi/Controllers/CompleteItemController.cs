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
        
        public CompleteItemController(IRepositoryGeneric<CompleteItemEntity> completeItemRepository, IMapper mapper)
        {
            _completeItemRepository = completeItemRepository;
            _mapper = mapper;
        }
        // GET: api/<CompleteItemController>
        [HttpGet]
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
                return StatusCode(500);
            }
        }

        // GET api/<CompleteItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompleteItemController>
        [HttpPost]
        public IActionResult Post(CompleteItemDto completeItemDtoToCreate)
        {
            CompleteItemEntity completeItemEntityToCreate = _mapper.Map<ToolEntity>(completeItemDtoToCreate);
            return Ok(_completeItemRepository.Create(completeItemEntityToCreate));
        }

        // PUT api/<CompleteItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotSupportedException();
        }

        // DELETE api/<CompleteItemController>/5
        [HttpDelete("{id}")]
        public int Delete(Guid id)
        {
            return _completeItemRepository.Delete(id);
        }

    }
}
