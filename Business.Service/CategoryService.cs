using Business.Service.Interfaces;
using Core.Models.Entities.Category;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;

namespace Business.Service;

public class CategoryService : ICategoryService
{
    ICategoryRepository _categoryRepository;
    IUserRepository _userRepository;
    IProductRepository _productRepository;

    public CategoryService(ICategoryRepository categoryRepository, IUserRepository userRepository, IProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }
    public void Create(CreateCategoryRequestModel request)
    {
        //Aşağıdaki kod yapısı olmaması gerekli ama bu aşamada tutalım=> Mapper gelecek

        Category category = new Category();
        category.Name = request.Name;
        category.Description = request.Description;
        category.CreateDate = request.CreateDate;
        category.CreatorId = request.CreatorId;

        _categoryRepository.Add(category);
    }

    public void Delete(DeleteCategoryRequestModel request)
    {
        throw new NotImplementedException();
    }

    public List<CategoryResponseModel> List()
    {
        CategoryResponseModel categoryResponseModel = new CategoryResponseModel();
        List<CategoryResponseModel> list = new List<CategoryResponseModel>();

        var dbList = _categoryRepository.GetAll();
        foreach (var item in dbList)
        {
            categoryResponseModel.Id = item.Id;
            categoryResponseModel.Name = item.Name;
            categoryResponseModel.Description = item.Description;
            categoryResponseModel.UserNameLastname = "Admin";
            categoryResponseModel.ProductCount = 0;

            list.Add(categoryResponseModel);

        }
        return list;
    }

    public void Update(UpdateCategoryRequestModel request)
    {
        throw new NotImplementedException();
    }
}
