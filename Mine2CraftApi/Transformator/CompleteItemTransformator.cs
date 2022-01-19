using AutoMapper;
using Dtos;
using Models;

namespace Mine2CraftApi.Transformator
{
    public class CompleteItemTransformator
    {
        private IMapper _mapper;

        public CompleteItemTransformator(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<CompleteItemDto> ToDto(IEnumerable<CompleteItemModel> completeItemsModel)
        {
            return _mapper.Map<IEnumerable<CompleteItemDto>>(completeItemsModel);
        }

        public CompleteItemModel ToModel(CompleteItemDto completeItemDto)
        {
            return _mapper.Map<CompleteItemModel>(completeItemDto);
        }
    }
}
