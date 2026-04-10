using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
   
        public string UserName { get; set;}
        public List<ShoppingCartItem> Items { get; set;} = new List<ShoppingCartItem>();
        
        public ShoppingCart()
        {
            this.UserName = "";
        }

        public ShoppingCart(string userName) 
        {
            this.UserName = userName;
        }

        public decimal TotalPrice()
        {
            return this.Items.Sum(x => x.Price);
        }
    }
}