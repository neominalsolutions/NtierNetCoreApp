using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DatabaseScaffoldApplication.Services.Models;
using DatabaseScaffoldApplication.Extentions;

namespace DatabaseScaffoldApplication.Services
{
    public class CartSession : ICartSession
    {
        private IHttpContextAccessor _context;

        public CartSession(IHttpContextAccessor context)
        {
            _context = context;
        }

        public void Clear()
        {
            _context.HttpContext.Session.Remove("Cart");
        }

        public Cart Get()
        {
           return  _context.HttpContext.Session.GetObject<Cart>("Cart");
        }

        public void Set(Cart cart)
        {
            _context.HttpContext.Session.SetObject<Cart>("Cart", cart);
        }
    }
}
