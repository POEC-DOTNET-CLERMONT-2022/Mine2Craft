using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dtos;
using Entities;
using Persistance;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mine2CraftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IRepositoryGeneric<ItemEntity> _itemRepository;
        private IMapper _mapper;

        public ItemController(IRepositoryGeneric<ItemEntity> userRepository, IMapper mapper)
        {
            _itemRepository = userRepository;
            _mapper = mapper;
        }

         // GET: api/<ItemController>
        [HttpGet]
        public ActionResult Get()
        {
            var itemEntity = _itemRepository.GetAll();
            var dto = _mapper.Map<IEnumerable<ItemDto>>(itemEntity);
            return Ok(dto);
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ItemController>
        [HttpPost]
        public IActionResult Post([FromBody] ItemDto itemDto)
        {
            var itemEntity = _mapper.Map<ItemEntity>(itemDto);
            _itemRepository.Add(itemEntity);
    
            return Ok(CreatedAtAction(nameof(Get), new {id = itemEntity.Id}, itemEntity));
        }

        // PUT api/<ItemController>/5
        [HttpPut("{guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        //TODO: soit on mets des ProducesResponseType partout soit pas du tout
        public IActionResult Put(Guid guid, [FromBody] ItemDto itemDto)
        {
            try
            {
                var itemEntity = _mapper.Map<ItemEntity>(itemDto);
                var updateEntity = _itemRepository.Update(itemEntity);
                if (updateEntity == false)
                    return NotFound();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{guid}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Delete(Guid guid)
        {
            var response = _itemRepository.Delete(guid);
            if (response == 0) 
                return NotFound();
            if (response == 1) 
                return Ok();

            return StatusCode(500);
        }
    }
}
