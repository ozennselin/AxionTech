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


    //bu yapılar Repository den geliyor
}
