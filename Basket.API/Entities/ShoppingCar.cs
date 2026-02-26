using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities
{
    public class ShoppingCar
    {
   
        public string? UserName { get; set;}
        public List<ShoppingCarItem> Items { get; set;} = new List<ShoppingCarItem>();
        
        public ShoppingCar()
        {
            
        }

        public ShoppingCar(string userName) 
        {
            this.UserName = userName;
        }

        public decimal TotalPrice()
        {
            return this.Items.Sum(x => x.Price);
        }
    }
}