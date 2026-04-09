using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.Cart;
using Core.Models.Entities.CartItem;
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

    public ResponseMessageEnum Create(CreateCartRequestModel request)
    {
        try
        {
            bool cartExists = _cartRepository.GetAllQuery(c => c.UserId == request.UserId).Any();

            if (cartExists)//daha önce sepete en az bir ürün ekleydiyse Cart tablosuna bu User için kayıt vardır anlamına gelir
            {
                var createCartItem = new CartItem
                {
                    ProductId = request.ProductId,
                    Quantity = 1,
                    UnitPrice = request.UnitPrice,

                };
               
            }
            else//sepete ilk ürün eklenirken bu kısım çalışacak,2. ürün ve sonrası için bu kısım çalışmaz
            {
                var createCart = new Cart
                {
                    UserId = request.UserId
                };
                _cartRepository.Add(createCart);

                var createCartItem = new CartItem
                {
                    CartId=1,
                    ProductId = request.ProductId,
                    Quantity = 1,
                    UnitPrice = request.UnitPrice,
                };
            }
        
            
            return ResponseMessageEnum.UpdateSuccess;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.UpdateErrorWithMessage;
        }
    }

    public ResponseMessageEnum Delete(DeleteCartRequestModel request)
    {
        try
        {
            var cartToDelete = _cartRepository.GetById(request.Id);

            if (cartToDelete == null)
            {
                return ResponseMessageEnum.NotFound;
            }

            _cartRepository.Delete(cartToDelete);
            return ResponseMessageEnum.Success;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.DeleteErrorWithMessage;
        }
    }

    public CartResponseModel GetById(int id)
    {
        var getCart = _cartRepository.GetById(id);

        if (getCart == null)
        {
            return null;
        }

        return new CartResponseModel
        {
            Id = getCart.Id,
            UserId = getCart.UserId
        };
    }

    public List<CartResponseModel> List()
    {
        var carts = _cartRepository.GetAll().ToList();

        return carts.Select(c => new CartResponseModel
        {
            Id = c.Id,
            UserId = c.UserId,
            //Items = _cartItemRepository
            //    .GetAllQuery(x => x.CartId == c.Id)
            //    .Select(ci => new CartItemResponseModel
            //    {
            //        Id = ci.Id,
            //        CartId = ci.CartId,
            //        ProductId = ci.ProductId,
            //        Quantity = ci.Quantity,
            //        UnitPrice = ci.UnitPrice,
            //        LineTotal = ci.LineTotal
            //    })
            //    .ToList()
        }).ToList();
    }

    public ResponseMessageEnum Update(UpdateCartRequestModel request)
    {
        try
        {
            var cartToUpdate = _cartRepository.GetById(request.Id);

            if (cartToUpdate == null)
            {
                return ResponseMessageEnum.NotFound;
            }

            cartToUpdate.UserId = request.UserId;

            _cartRepository.Update(cartToUpdate);
            return ResponseMessageEnum.UpdateSuccess;
        }
        catch (Exception)
        {
            return ResponseMessageEnum.UpdateErrorWithMessage;
        }
    }
}
