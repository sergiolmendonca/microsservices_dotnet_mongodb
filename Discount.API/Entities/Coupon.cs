using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.API.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public required string ProductName { get; set; }
        public required string Description { get; set; }
        public int Amount { get; set; }

        [SetsRequiredMembers]
        public Coupon(int amount, string productName, string description)
        {
            this.Amount = amount;
            this.ProductName = productName;
            this.Description = description;
        }
    }
}