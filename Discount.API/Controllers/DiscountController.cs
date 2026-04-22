using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DiscountController : ControllerBase
    {
        private IDiscountRepository _repository { get; set; }

        public DiscountController(IDiscountRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{productName}", Name = "GetDiscount")]
        public async Task<ActionResult<Coupon>> GetDiscount (string productName)
        {
            return Ok(await _repository.GetCoupon(productName) ?? new Coupon(0, "Sem desconto", "Sem desconto"));
        }

        [HttpPost]
        public async Task<ActionResult<Coupon>> CreateDiscount ([FromBody] Coupon coupon)
        {
            await _repository.CreateCoupon(coupon);
            return CreatedAtRoute("GetDiscount", new { productName = coupon.ProductName }, coupon);
        }

        [HttpPut]
        public async Task<ActionResult<Coupon>> UpdateDiscount ([FromBody] Coupon coupon)
        {
            return Ok(await _repository.UpdateCoupon(coupon));
        }

        [HttpDelete("{productName}", Name = "DeleteDiscount")]
        public async Task<ActionResult<bool>> DeleteDiscount (string productName)
        {
            return Ok(_repository.DeleteCoupon(productName));
        }
        
    }
}