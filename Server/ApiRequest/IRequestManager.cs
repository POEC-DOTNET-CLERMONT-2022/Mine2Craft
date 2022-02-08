using Models;

namespace ApiRequest;

public interface IRequestManager<TModel, TDto>  where TModel : class
                                                where TDto : class
{
    Task<IEnumerable<TModel>> GetAll();

    Task Add(TModel model);

    Task Delete(Guid guid);

    Task Update(TModel model, Guid guid);
}