using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.Kernel;
using Entities;

namespace Persistance;

public class FakeRepositoryGeneric<T> : IRepositoryGeneric<T> where T : class, IBaseEntity
{
    private readonly List<T> _listEntity = new List<T>();
    private readonly Fixture _fixture = new Fixture();

    public FakeRepositoryGeneric()
    {
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _fixture.Customizations.Add(
            new TypeRelay(
                typeof(CompleteItemEntity),
                typeof(ToolEntity)));
        _listEntity = _fixture.CreateMany<T>(15).ToList(); 
    }
    public IEnumerable<T> GetAll()
    {
        return _listEntity;
    }

    public T GetSingle(Guid id)
    {
        throw new NotImplementedException();
    }

    public int Create(T t)
    {
        var listEntityCount = _listEntity.Count;

        _listEntity.Add(t);

        return _listEntity.Count - listEntityCount;
    }
    
    public bool Update(T entity)
    {
        var entityToUpdateIndex = _listEntity.FindIndex(t => t.Id == entity.Id);
        
        try
        {
            _listEntity[entityToUpdateIndex] = entity;
            return true;
        }
        catch (Exception e)
        {
            return false;
        }

    }
    
    public int Delete(Guid id)
    {
        var newListEntity = _listEntity.Where(t => t.Id != id).ToList();

        return _listEntity.Count - newListEntity.Count;
    }


}