using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.ProductDocument;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;
using System.Linq;

namespace Business.Service;

public class ProductDocumentService : IProductDocumentService
{
    private readonly IProductDocumentRepository _productDocumentRepository;

    public ProductDocumentService(IProductDocumentRepository productDocumentRepository)
    {
        _productDocumentRepository = productDocumentRepository;
    }
    public ResponseMessageEnum Create(CreateProductDocumentRequestModel request)
    {
        try
        {
            var newProductDocument = new ProductDocument
            {
                ProductId = request.ProductId,
                Url = request.Url,
                FileName = request.FileName,
                FileType = request.FileType,
                CreateDate = DateTime.Now,
                CreatorId = 1
            };
            _productDocumentRepository.Add(newProductDocument);
            return ResponseMessageEnum.Success;
        }
        catch { return ResponseMessageEnum.Error; }
    }

    public ResponseMessageEnum Delete(DeleteProductDocumentRequestModel request)
    {
        var documentToDelete = _productDocumentRepository.GetById(request.Id);
        if (documentToDelete == null) return ResponseMessageEnum.NotExist;

        _productDocumentRepository.Delete(documentToDelete);
        return ResponseMessageEnum.Success;
    }

    public List<ProductDocumentResponseModel> GetByProductId(int productId)
    {
        var documents = _productDocumentRepository.GetByProductId(productId);
        return documents.Select(d => new ProductDocumentResponseModel
        {
            Id = d.Id,
            ProductId = d.ProductId,
            Url = d.Url,
            FileName = d.FileName,
            FileType = d.FileType
        }).ToList();
    }

    public void Update(UpdateProductDocumentRequestModel request)
    {
        var documentToUpdate = _productDocumentRepository.GetById(request.Id);
        if (documentToUpdate == null)
        {
            throw new Exception("Product document not found.");
        }
        documentToUpdate.ProductId = request.ProductId;
        documentToUpdate.Url = request.Url;
        documentToUpdate.FileName = request.FileName;
        documentToUpdate.FileType = request.FileType;
        _productDocumentRepository.Update(documentToUpdate);
    }
}