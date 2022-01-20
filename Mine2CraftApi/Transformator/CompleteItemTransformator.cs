using Dtos;
using Entities;
using Models;

namespace Mine2CraftApi.Transformator
{
    public class CompleteItemTransformator
    {
        private Mapper.MapperCustom Mapper { get; } = new Mapper.MapperCustom();

        public IEnumerable<CompleteItemDto> ToDto(IEnumerable<CompleteItemEntity> completeItemsModel)
        {
            return Mapper.Mapper.Map<IEnumerable<CompleteItemDto>>(completeItemsModel);
        }

        public CompleteItemModel ToModel(CompleteItemDto completeItemDto)
        {
            return Mapper.Mapper.Map<CompleteItemModel>(completeItemDto);
        }
    }
}
