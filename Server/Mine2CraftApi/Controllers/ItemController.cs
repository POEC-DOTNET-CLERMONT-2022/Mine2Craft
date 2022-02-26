using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dtos;
using Entities;
using Persistance;


namespace Mine2CraftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IRepositoryGeneric<ItemEntity> _itemRepository;
        private IMapper _mapper;
        // TODO Add Ilogger
        public ItemController(IRepositoryGeneric<ItemEntity> userRepository, IMapper mapper)
        {
            _itemRepository = userRepository;
            _mapper = mapper;
        }

         // GET: api/<ItemController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult Get()
        {
            try
            {
                var itemEntity = _itemRepository.GetAll();
                var dto = _mapper.Map<IEnumerable<ItemDto>>(itemEntity);
                return Ok(dto);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ItemController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] ItemDto itemDto)
        {
            var itemEntity = _mapper.Map<ItemEntity>(itemDto);
            _itemRepository.Create(itemEntity);
    
            return Ok(CreatedAtAction(nameof(Get), new {id = itemEntity.Id}, itemEntity));
        }

        // PUT api/<ItemController>/5
        [HttpPut("{guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
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
            catch (Exception)
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
            try
            {
                var response = _itemRepository.Delete(guid);
                if (response == 1)
                    return Ok();
                else if (response == 0)
                    return NotFound();
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
