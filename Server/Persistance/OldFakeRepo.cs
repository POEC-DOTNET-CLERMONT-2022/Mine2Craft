using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.Kernel;
using Entities;

namespace Persistance;

public class OldFakeRepo<T> : IRepositoryGeneric<T> where T : class, IBaseEntity, new()
{
    private readonly List<T> _listEntity = new List<T>();
    
    private readonly List<ItemEntity> _listItemEntity = new List<ItemEntity>();

    private readonly Fixture _fixture = new Fixture();

    public OldFakeRepo()
    {
        
    }

    private void LoadData()
    {
        var item = new ItemEntity();
        var item2 = new ItemEntity();
        var item3 = new ItemEntity();

        item.Id = new Guid();
        item.Name = "New Item";
        item.Description = "New Desc";
        item.IsCombustible = 0;
        item.IsCooked = 1;
        item.ImagePath = "";

        item2.Id = new Guid();
        item2.Name = "New Item";
        item2.Description = "New Desc";
        item2.IsCombustible = 0;
        item2.IsCooked = 1;
        item2.ImagePath = "";

        item3.Id = new Guid();
        item3.Name = "New Item";
        item3.Description = "New Desc";
        item3.IsCombustible = 0;
        item3.IsCooked = 1;
        item3.ImagePath = "";


        _listItemEntity.Add(item);
        _listItemEntity.Add(item2);
        _listItemEntity.Add(item3);
    }


    public IEnumerable<T> GetAll()
    {
        return (IEnumerable<T>)_listItemEntity;
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