using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Services.Models
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public decimal TotalPrice { get {
                return CartItems.Sum(x => x.Quantity * x.Price);
            }
        }

    }
}
