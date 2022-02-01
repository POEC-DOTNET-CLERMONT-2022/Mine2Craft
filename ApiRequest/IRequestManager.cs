namespace ApiRequest;

public interface IRequestManager<TModel, TDto>  where TModel : class
                                                where TDto : class
{
    Task<IEnumerable<TModel>> GetAll();
}