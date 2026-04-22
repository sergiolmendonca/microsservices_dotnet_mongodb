using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Discount.API.Entities;
using Npgsql;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private NpgsqlConnection GetNpgsqlConnection()
        {
            return new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        }

        public async Task<Coupon> GetCoupon(string productName)
        {
            var connection = GetNpgsqlConnection();

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>(
                "SELECT * FROM Coupon WHERE ProductName = @ProductName", 
                new { ProductName = productName });

            return coupon ?? new Coupon(0, "Sem desconto", "sem desconto");
        }

        public async Task<bool> CreateCoupon(Coupon coupon)
        {
            var connection = GetNpgsqlConnection();

            var affected = await connection.ExecuteAsync(
                @"INSERT INTO Coupon (ProductName, Description, Amount)
                    VALUES (@ProductName, @Description, @Amount)", coupon);
            
            if (affected == 0) return false;

            return true;
        }

        public async Task<bool> UpdateCoupon(Coupon coupon)
        {
            var connection = GetNpgsqlConnection();

            var affected = await connection.ExecuteAsync(
                @"UPDATE Coupon SET ProductName = @ProductName, Description = @Descripition, Amount = @Amount
                    WHERE Id = @Id", coupon);
            
            if (affected == 0) return false;

            return true;
        }

        public async Task<bool> DeleteCoupon(string productName)
        {
            var connection = GetNpgsqlConnection();

            var affected = await connection.ExecuteAsync(
                @"DELETE FROM Coupon WHERE ProductName = @ProductName", 
                    new  { ProductName = productName });
            
            if (affected == 0) return false;

            return true;
        }
    }
}