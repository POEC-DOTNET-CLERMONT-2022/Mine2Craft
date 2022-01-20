using AutoMapper;
using MapperCustom.Profile;

namespace Mapper
{
    public class MapperCustom
    {
        private readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg => {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<CompleteItemProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public IMapper Mapper => Lazy.Value;

    }
}