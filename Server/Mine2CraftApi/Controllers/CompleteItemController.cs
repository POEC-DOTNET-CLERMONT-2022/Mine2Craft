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
            //TODO : Ajouter des logs
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
        
        // POST api/<CompleteItemController>
        [HttpPost]
        public IActionResult Post(CompleteItemDto completeItemDtoToCreate)
        {
            //TODO ajouter des logs 
            //TODO : gestion d'exception
            var completeItemEntityToCreate = _mapper.Map<CompleteItemEntity>(completeItemDtoToCreate);
            return Ok(_completeItemRepository.Create(completeItemEntityToCreate).ToString());
        }

        // PUT api/<CompleteItemController>/5
        [HttpPut("{guid}")]
        public IActionResult Put(Guid guid, [FromBody] CompleteItemDto completeItemDtoToUpdate)
        {
            var completeItemEntityToCreate = _mapper.Map<CompleteItemEntity>(completeItemDtoToUpdate);
            return Ok(_completeItemRepository.Update(completeItemEntityToCreate).ToString());
        }

        // DELETE api/<CompleteItemController>/5
        [HttpDelete("{id}")]
        public int Delete(Guid id)
        {
            return _completeItemRepository.Delete(id);
        }

    }
}
