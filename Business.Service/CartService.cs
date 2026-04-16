using Business.Service.Interfaces;
using Core.Enums;
using Core.Models.Entities.Cart;
using Core.Models.Entities.CartItem;
using Data.Access.Repositories.Interfaces;
using Data.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Business.Service;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IProductPictureRepository _productPicture;

    public CartService(ICartRepository cartRepository, ICartItemRepository cartItemRepository, IProductPictureRepository productPicture)
    {
        _cartRepository = cartRepository;
        _cartItemRepository = cartItemRepository;
        _productPicture = productPicture;
    }

    public ResponseMessageEnum Create(CreateCartRequestModel request)
    {
        try
        {
            bool cartExists = _cartRepository.GetAllQuery(c => c.UserId == request.UserId).Any();
            var createCartItem = new CartItem();

            if (!cartExists)//sepete ilk ürün eklenirken bu kısım çalışacak,2. ürün ve sonrası için bu kısım çalışmaz
            {
                var createCart = new Cart
                {
                    UserId = request.UserId,
                    CreateDate = DateTime.Now,
                    CreatorId = request.UserId
                };

                _cartRepository.Add(createCart);
            }
            var getCartId = _cartRepository.GetEntityQuery(c => c.UserId == request.UserId).Id;

            var getSameProduct = _cartItemRepository.GetEntityQuery(k => k.CartId == getCartId && k.ProductId == request.ProductId);
            if (getSameProduct != null)//aynı üründe sepette varsa yeni data eklenmiyecek, Quantity 1 artırılacak
            {
                getSameProduct.Quantity = getSameProduct.Quantity + 1;
                getSameProduct.UpdateDate = DateTime.Now;
                getSameProduct.UpdaterId = request.UserId;

                _cartItemRepository.Update(createCartItem);

            }
            else
            {
                createCartItem = new CartItem
                {
                    CartId = getCartId,
                    ProductId = request.ProductId,
                    Quantity = 1,
                    UnitPrice = request.UnitPrice,
                    CreateDate = DateTime.Now,
                    CreatorId = request.UserId
                };

                _cartItemRepository.Add(createCartItem);

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

    public CartResponseModel GetCartByUserId(int userId)
    {
        var getCart = _cartRepository.GetEntityQuery(c => c.UserId == userId);

        if (getCart == null)
        {
            return null;
        }

        var getCartItem = _cartItemRepository.GetAllQuery(x => x.CartId == getCart.Id).ToList();

        var result = new CartResponseModel
        {
            UserId = userId,
            Id = getCart.Id,
            Items = getCartItem.Select(ci => new CartItemResponseModel
            {
                Id = ci.Id,
                CartId = ci.CartId,
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
                PictureUrl = _productPicture.GetMainPictureByProductId(ci.ProductId)?.Url,
                ProductName ="test isim",
                UnitPrice = ci.UnitPrice,
                LineTotal = ci.Quantity * ci.UnitPrice
            }).ToList()
        };

        return result;

    }
}
