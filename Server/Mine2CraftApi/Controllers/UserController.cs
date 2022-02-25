using AutoMapper;
using Dtos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json.Linq;
using Persistance;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mine2CraftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryGeneric<UserEntity> _userRepository;
        private readonly IMapper _mapper;

        public UserController(IRepositoryGeneric<UserEntity> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var userEntities = _userRepository.GetAll();
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
        public int Post(JObject userDtoToCreate)
        {
            var nickname = userDtoToCreate.GetValue("Nickname");
            var email = userDtoToCreate.GetValue("Email");
            var password = userDtoToCreate.GetValue("Password");

            var userToCreate = new UserEntity();
            userToCreate.Nickname = nickname.ToString();
            userToCreate.Email = email.ToString();
            userToCreate.Password = password.ToString();
            userToCreate.UserRole = UserRole.Admin;

            return _userRepository.Create(userToCreate);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, [FromBody] UserDto userDtoToUpdate)
        {
            var userToUpdate = _userRepository.GetSingle(id);
            userToUpdate.UserRole = (UserRole)userDtoToUpdate.UserRole;

            return _userRepository.Update(userToUpdate);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public int Delete(Guid id)
        {
            return _userRepository.Delete(id);
        }
    }
}
