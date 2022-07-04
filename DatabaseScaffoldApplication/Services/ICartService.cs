using DatabaseScaffoldApplication.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Services
{
   public  interface ICartService
    {
        void AddToCart(CartItem cartItem);
        void RemoveFromCart(CartItem cartItem);
        Cart GetCart();
    }
}
