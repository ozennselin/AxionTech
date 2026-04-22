using Business.Service.Interfaces;
using Core.Models.Entities.Cart;
using Core.Models.Entities.CartItem;
using Data.Access.Repositories;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Service;

public class CartItemService : ICartItemService
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IProductService _productService;

    public CartItemService(ICartItemRepository cartItemRepository, ICartRepository cartRepository, IProductService productService = null)
    {
        _cartItemRepository = cartItemRepository;
        _cartRepository = cartRepository;
        _productService = productService;
    }
    public void Create(CreateCartItemRequestModel request)
    {
        var newCartItem = new CartItem
        {
            CartId = request.CartId,
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            UnitPrice = request.UnitPrice,
            LineTotal = request.Quantity * request.UnitPrice
        };
        _cartItemRepository.Add(newCartItem);
    }

    public void Delete(DeleteCartItemRequestModel request)
    {
        var cartItenmToDelete = _cartItemRepository.GetById(request.Id);
        if (cartItenmToDelete == null)
        {
            throw new Exception("Cart item not found.");
        }
        _cartItemRepository.Delete(cartItenmToDelete);
    }

    public List<CartItemResponseModel> GetByCartId(int cartId)
    {
        var cartItems = _cartItemRepository.GetAllQuery(x => x.CartId == cartId).Include(x => x.Product).ToList();

        return cartItems.Select(x => new CartItemResponseModel
        {
            Id = x.Id,
            CartId = x.CartId,
            ProductId = x.ProductId,
            Quantity = x.Quantity,
            UnitPrice = x.UnitPrice,
            LineTotal = x.LineTotal,
            ProductName = x.Product.Name
        }).ToList();
    }

    public void Update(UpdateCartItemRequestModel request)
    {
        var cartItemToUpdate = _cartItemRepository.GetById(request.Id);

        if (cartItemToUpdate == null)
        {
            throw new Exception("Cart item not found.");
        }

        cartItemToUpdate.Quantity = request.Quantity;
        cartItemToUpdate.UnitPrice = request.UnitPrice;
        cartItemToUpdate.LineTotal = request.Quantity * request.UnitPrice;
        _cartItemRepository.Update(cartItemToUpdate);
    }

    public List<CartItemResponseModel> List(int? userId = null)
    {
        var cartId = _cartRepository.GetEntityQuery(k => !userId.HasValue || k.UserId == userId.Value).Id;

        var getCartItems = _cartItemRepository.GetAllQuery(x => x.CartId == cartId).ToList();

        return getCartItems.Select(ci => new CartItemResponseModel
        {
            Id = ci.Id,
            CartId = ci.CartId,
            ProductId = ci.ProductId,
            ProductName =_productService.GetById(ci.ProductId).Name,
            Quantity = ci.Quantity,
            UnitPrice = 20,//ProductPrice getirilecek
            LineTotal =112 //ci.Quantity * 20,
        }).ToList();
    }
}
