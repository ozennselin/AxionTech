using Data.Infrastructure.Entities;

namespace Data.Access.Repositories.Interfaces;

public interface ICategoryRepository:IRepository<Category>
{
    void Delete(Category entity);
    void Update(Category entity);

}
