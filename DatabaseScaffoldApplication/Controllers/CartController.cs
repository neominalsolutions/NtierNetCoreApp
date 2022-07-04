using DatabaseScaffoldApplication.Extentions;
using DatabaseScaffoldApplication.Models;
using DatabaseScaffoldApplication.Services;
using DatabaseScaffoldApplication.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        private IHttpContextAccessor _context;

        public CartController(ICartService cartService, IHttpContextAccessor httpContext)
        {
            _cartService = cartService;
            _context = httpContext;
        }



        public IActionResult Index()
        {
            //böyle direct session erişmiyoruz test edilebilirlik açısından yanlış
            //_session.SetString("aa", "asdsa");
            //_session.Get("aa");





            if (_cartService.GetCart() == null)
            {
                _cartService.AddToCart(new CartItem { Id = 1, Name = "Kazak", Price = 100, Quantity = 1 });
            }
            

            var model = new CartViewModel
            {
                Cart = _cartService.GetCart() == null ? new Cart() : _cartService.GetCart()
            };




            return View(model);
        }


        [HttpPost]
        public JsonResult AddToCart(CartItem cartItem)
        {
            _cartService.AddToCart(cartItem);


     

            var jsonResult = new
            {
                cartItems = _cartService.GetCart().CartItems,
                total = _cartService.GetCart().TotalPrice,
                message = "Product added to system successfully!"
            };

            return Json(jsonResult);

        }
    }
}
