using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;
using Microsoft.Identity.Client;

namespace Data.Access.Repositories;

public class CategoryRepository :Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
        
    }

    public void Delete(Category entity)
    {
        _dbSet.Remove(entity);
        _axionTechDB.SaveChanges();
    }

    public void Update(Category entity)
    {
        _dbSet.Update(entity);
        _axionTechDB.SaveChanges();
    }

    //public void Add(Category entity)
    //{
    //    throw new NotImplementedException();
    //}

    //public IQueryable<Category> GetAll()
    //{
    //    throw new NotImplementedException();
    //}

    //bu yapılar Repository den geliyor
}
