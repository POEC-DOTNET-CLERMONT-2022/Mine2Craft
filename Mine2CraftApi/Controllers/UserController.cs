using AutoMapper;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using Persistance.Manager.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mine2CraftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _userManager.Mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            return _userManager.GetAllUser();
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
            return _userManager.CreateUser(userDtoToCreate);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
