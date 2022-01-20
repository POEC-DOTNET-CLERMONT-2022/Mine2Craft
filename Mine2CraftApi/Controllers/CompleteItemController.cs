using AutoMapper;
using Dtos;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Mine2CraftApi.Transformator;
using Models;
using Persistance;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mine2CraftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompleteItemController : ControllerBase
    {
        private readonly BddCompleteItemManager _bddCompleteItemManager;

        private readonly CompleteItemTransformator _completeItemTransformator;
        public CompleteItemController(IMapper mapper)
        {
            _completeItemTransformator = new CompleteItemTransformator();

            _bddCompleteItemManager = new BddCompleteItemManager();
        }
        // GET: api/<CompleteItemController>
        [HttpGet]
        public IEnumerable<CompleteItemDto> Get()
        { 
            return _completeItemTransformator.ToDto(_bddCompleteItemManager.GetAllCompleteItems());
        }

        // GET api/<CompleteItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompleteItemController>
        [HttpPost]
        public void Post(CompleteItemDto completeItemDto)
        {
            _bddCompleteItemManager.CreateCompleteItem(completeItemDto);
        }

        // PUT api/<CompleteItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotSupportedException();
        }

        // DELETE api/<CompleteItemController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _bddCompleteItemManager.DeleteCompleteItem(id);
        }
    }
}
