using Business.Service.Interfaces;
using Core.Models.Entities.Cart;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;

namespace Business.Service;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly ICartItemRepository _cartItemRepository;

    public CartService(ICartRepository cartRepository, ICartItemRepository cartItemRepository)
    {
        _cartRepository = cartRepository;
        _cartItemRepository = cartItemRepository;
    }

    public void Create(CreateCartRequestModel request)
    {
       var createCart = new Cart
        {
            UserId = request.UserId
        };
        _cartRepository.Add(createCart);
    }

    public void Delete(DeleteCartRequestModel request)
    {
        var carttoDelete = _cartRepository.GetById(request.Id);
        if (carttoDelete == null)
        {
            _cartRepository.Delete(carttoDelete);
        }
    }

    public CartResponseModel GetByCartId(int cartId)
    {
        var getCart = _cartRepository.GetById(cartId);
        if (getCart == null)
        {
           throw new Exception("Cart not found");
        }
        return new CartResponseModel
        {
            Id = getCart.Id,
            UserId = getCart.UserId
        };
    }

    public void Update(UpdateCartRequestModel request)
    {
        var carttoUpdate = _cartRepository.GetById(request.Id);
        if(carttoUpdate == null)
        {
            throw new Exception("Cart not found");
        }
        carttoUpdate.UserId = request.UserId;
        _cartRepository.Update(carttoUpdate);
    }
}
