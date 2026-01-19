using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class CategoryRepository :Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
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
