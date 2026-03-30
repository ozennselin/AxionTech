using Business.Service.Interfaces;
using Core.Models.Entities.CartItem;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Service;

public class CartItemService : ICartItemService
{
    private readonly ICartItemRepository _cartItemRepository;
    public CartItemService(ICartItemRepository cartItemRepository)
    {
        _cartItemRepository = cartItemRepository;
    }
    public void Create(CreateCartItemRequestModel request)
    {
        var newCartItem = new CartItem
        {
            CartId = request.CartId,
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            UnitPrice = request.UnitPrice
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
        var cartItems = _cartItemRepository.GetAllQuery(x => x.CartId == cartId).Include(x=>x.Product).ToList();

        return cartItems.Select(x => new CartItemResponseModel
        {
            Id = x.Id,
            CartId = x.CartId,
            ProductId = x.ProductId,
            Quantity = x.Quantity,
            UnitPrice = x.UnitPrice,
            LineTotal = x.LineTotal,
            ProductName=x.Product.Name
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
        _cartItemRepository.Update(cartItemToUpdate);
    }
}
