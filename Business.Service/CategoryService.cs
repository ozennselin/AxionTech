using Business.Service.Interfaces;
using Core.Models.Entities.Category;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;

namespace Business.Service;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

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
        var categoryToDelete = _categoryRepository.GetById(request.Id);
        if (categoryToDelete == null)
        {
            throw new Exception("Category not found");
        }
        _categoryRepository.Delete(categoryToDelete);
    }

    public List<CategoryResponseModel> List()
    {
        CategoryResponseModel categoryResponseModel = new CategoryResponseModel();
        var list = new List<CategoryResponseModel>();

        var dbList = _categoryRepository.GetAll();

        foreach (var item in dbList)
        {
            var categoryResponseModelAdd = new CategoryResponseModel
            {
                Id = item.Id,
                ParentId = item.ParentId,
                Name = item.Name,
                Description = item.Description,
                UserNameLastname = "Admin",
                ProductCount = 0,
            };
            list.Add(categoryResponseModelAdd);
        }


        return list;
    }

    public void Update(UpdateCategoryRequestModel request)
    {
       var categoryToUpdate = _categoryRepository.GetById(request.Id);
        if (categoryToUpdate == null)
        {
            throw new Exception("Category not found");
        }
        categoryToUpdate.Name = request.Name;
        categoryToUpdate.Description = request.Description;
      _categoryRepository.Update(categoryToUpdate);
    }
}
