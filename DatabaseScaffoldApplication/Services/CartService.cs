using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseScaffoldApplication.Services.Models;

namespace DatabaseScaffoldApplication.Services
{
    public class CartService : ICartService
    {

        private ICartSession _cartSession;

        public CartService(ICartSession cartSession)
        {
            _cartSession = cartSession;
        }

        public void AddToCart(CartItem cartItem)
        {
            var _cart = _cartSession.Get();

            if (_cart == null)
            {
                var newCart = new Cart();
                newCart.CartItems.Add(cartItem);
                _cartSession.Set(newCart);
            }
            else
            {
                var _existingItem = _cart.CartItems.FirstOrDefault(x => x.Id == cartItem.Id);

                if(_existingItem != null)
                {
                    _existingItem.Quantity += cartItem.Quantity;
                }
                else
                {
                    _cart.CartItems.Add(cartItem);
                }

                _cartSession.Set(_cart);

            }
        }

        public Cart GetCart()
        {
            return _cartSession.Get();
        }

        public void RemoveFromCart(CartItem cartItem)
        {
            var _cart = _cartSession.Get();

            if (_cart == null)
            {
                _cart.CartItems.Remove(cartItem);
            }
        }
    }
}
