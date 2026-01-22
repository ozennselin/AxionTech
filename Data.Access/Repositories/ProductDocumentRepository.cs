using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class ProductDocumentRepository : Repository<ProductDocument>, IProductDocumentRepository
{
    public ProductDocumentRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }
}
