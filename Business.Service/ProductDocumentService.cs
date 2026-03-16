using Business.Service.Interfaces;
using Core.Models.Entities.ProductDocument;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;
using System.Reflection.Metadata;

namespace Business.Service;

public class ProductDocumentService : IProductDocumentService
{
    private readonly IProductDocumentRepository _productDocumentRepository;
   
    public ProductDocumentService(IProductDocumentRepository productDocumentRepository)
    {
        _productDocumentRepository = productDocumentRepository;
    }
    public void Create(CreateProductDocumentRequestModel request)
    {
        var newProductDocument = new ProductDocument
        {
            ProductId = request.ProductId,
            Url = request.Url,
            FileName = request.FileName,
            FileType = request.FileType
        };
        _productDocumentRepository.Add(newProductDocument);
    }

    public void Delete(DeleteProductDocumentRequestModel request)
    {
        var documentToDelete = _productDocumentRepository.GetById(request.Id);
        if (documentToDelete == null)
        {
            throw new Exception("Product document not found.");
        }
        _productDocumentRepository.Delete(documentToDelete);
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
        if (documentToUpdate==null)
        {
            throw new Exception("Document not found");
        }
        documentToUpdate.ProductId = request.ProductId;
        documentToUpdate.Url = request.Url;
        documentToUpdate.FileName = request.FileName;
        documentToUpdate.FileType = request.FileType;

        _productDocumentRepository.Update(documentToUpdate);
    }
}
