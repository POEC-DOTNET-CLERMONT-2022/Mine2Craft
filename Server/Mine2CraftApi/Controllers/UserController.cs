using AutoMapper;
using Dtos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Persistance;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mine2CraftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryGeneric<UserEntity> _userItemRepository;
        private readonly IMapper _mapper;

        public UserController(IRepositoryGeneric<UserEntity> userItemRepository, IMapper mapper)
        {
            _userItemRepository = userItemRepository;
            _mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var userEntities = _userItemRepository.GetAll();
                var userDtos = _mapper.Map<IEnumerable<UserDto>>(userEntities);
                return Ok(userDtos);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public int Post(UserDto userDtoToCreate)
        {
            //return _userManager.CreateUser(userDtoToCreate);
            //TODO: à implementer ! ou à supprimer 
            throw new NotImplementedException();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public int Delete(Guid id)
        {
            //return _userManager.DeleteUser(id);
            //TODO: à implementer ! ou à supprimer 
            throw new NotImplementedException();
        }
    }
}
