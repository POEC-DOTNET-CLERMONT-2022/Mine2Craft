using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Entities;

namespace Persistance;

public class FakeRepositoryGeneric<T> : IRepositoryGeneric<T> where T : class, IBaseEntity, new()
{
    private readonly List<T> _listEntity = new List<T>();
    private readonly Fixture _fixture = new Fixture();

    public FakeRepositoryGeneric()
    {
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
        throw new NotImplementedException();
    }

    public int Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Update(T entity)
    {
        throw new NotImplementedException();
    }
}