using AutoMapper;
using Dtos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Models;
using Persistance.Manager.CompleteItem;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mine2CraftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompleteItemController : ControllerBase
    {
        private readonly ICompleteItemManager _completeItemManager;
        
        public CompleteItemController(ICompleteItemManager completeItemManager, IMapper mapper)
        {
            _completeItemManager = completeItemManager;
            _completeItemManager.Mapper = mapper;
        }
        // GET: api/<CompleteItemController>
        [HttpGet]
        public IEnumerable<CompleteItemDto> Get()
        { 
            return _completeItemManager.GetAllCompleteItems();
        }

        // GET api/<CompleteItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompleteItemController>
        [HttpPost]
        public int Post(CompleteItemDto completeItemDto)
        {
            return _completeItemManager.CreateCompleteItem(completeItemDto);
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
            return _completeItemManager.DeleteCompleteItem(id);
        }

    }
}
