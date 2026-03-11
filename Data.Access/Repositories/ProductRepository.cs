using Core.Dtos.Entities.Product;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure;
using Data.Infrastructure.Entities;

namespace Data.Access.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AxionTechDB axionTechDB) : base(axionTechDB)
    {
    }

    private readonly IProductPictureRepository _productPictureRepository;

    public List<Product> ProductListWithCategory()
    {
        return _dbSet.ToList();
    }


    public List<ProductListDto> List()
    {
        return GetAll().Select(p => new
        ProductListDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            CategoryId = p.CategoryId,
            Picture = _productPictureRepository.GetById(p.ProductPictures.FirstOrDefault().Id).Url,
            Price = 100

        }).ToList();

    }

    //public IQueryable<Product> GetAllQuery()
    //{
    //    string test= _axionTechDB.ProductPicture.Where(k=>k.IsMain==true && k.Id==90).FirstOrDefault().Url;

    //}
}
