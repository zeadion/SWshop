

using System.Collections.Generic;
using System.Linq;
using SWshop.MVC.Models;

namespace SWshop.MVC.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }

        public decimal CartTotal()
        {
            return CartItems.Sum(cartItem => cartItem.GetRegularPrice());
        }

        public decimal CartPromotionTotal()
        {
            return CartItems.Sum(cartItem => cartItem.GetPromotionPrice());
        }


    }
    
}