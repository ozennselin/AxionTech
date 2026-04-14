using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.Category;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;

namespace Business.Service;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

    public CategoryService(
        ICategoryRepository categoryRepository,
        IUserRepository userRepository,
        IProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    public ResponseMessageEnum Create(CreateCategoryRequestModel request)
    {
        try
        {
            Category category = new Category();

            category.ParentId = request.ParentId;
            category.Name = request.Name;
            category.Description = request.Description;
            category.CreateDate = request.CreateDate;
            category.CreatorId = request.CreatorId;

            _categoryRepository.Add(category);

            return ResponseMessageEnum.UpdateSuccess;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.UpdateErrorWithMessage;
        }
    }

    public ResponseMessageEnum Delete(DeleteCategoryRequestModel request)
    {
        try
        {
            var categoryToDelete = _categoryRepository.GetById(request.Id);

            if (categoryToDelete == null)
            {
                return ResponseMessageEnum.NotFound;
            }

            _categoryRepository.Delete(categoryToDelete);

            return ResponseMessageEnum.Success;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.DeleteErrorWithMessage;
        }
    }

    public CategoryResponseModel? GetById(int id)
    {
        var item = _categoryRepository.GetById(id);

        if (item == null)
            return null;

        return new CategoryResponseModel
        {
            Id = item.Id,
            ParentId = item.ParentId,
            Name = item.Name,
            Description = item.Description,
            UserNameLastname = "Admin",
            ProductCount = _productRepository.GetAll().Count(p => p.CategoryId == item.Id)
        };
    }

    public List<CategoryResponseModel> List()
    {
        var dbList = _categoryRepository.GetAll().ToList();

        return dbList.Select(item => new CategoryResponseModel
        {
            Id = item.Id,
            ParentId = item.ParentId,
            Name = item.Name,
            Description = item.Description,
            UserNameLastname = "Admin",
            ProductCount = _productRepository.GetAll().Count(p => p.CategoryId == item.Id)
        }).ToList();
    }

    public ResponseMessageEnum Update(UpdateCategoryRequestModel request)
    {
        try
        {
            var categoryToUpdate = _categoryRepository.GetById(request.Id);

            if (categoryToUpdate == null)
            {
                return ResponseMessageEnum.NotFound;
            }

            categoryToUpdate.ParentId = request.ParentId;
            categoryToUpdate.Name = request.Name;
            categoryToUpdate.Description = request.Description;

            _categoryRepository.Update(categoryToUpdate);

            return ResponseMessageEnum.UpdateSuccess;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.UpdateErrorWithMessage;
        }
    }
}