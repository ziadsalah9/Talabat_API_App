using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.IRepositories;
using Talabat.Core.Models;

namespace Talabat.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _Redisdatabase;

        public BasketRepository(IConnectionMultiplexer Redis)
        {
            _Redisdatabase = Redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string BasketId)
        {
           return await _Redisdatabase.KeyDeleteAsync(BasketId);
        }

        public async Task<CustomerBasket?> getBasketAsync(string BasketId)
        {

            var basket = await _Redisdatabase.StringGetAsync(BasketId);
            return basket.IsNullOrEmpty?null:JsonSerializer.Deserialize<CustomerBasket> (basket) ; 
        }

        public async Task<CustomerBasket?> updateBasketAsync(CustomerBasket customerBasket)
        {
            var createdorupdated = await _Redisdatabase.StringSetAsync(customerBasket.Id,JsonSerializer.Serialize (customerBasket), TimeSpan.FromDays(30));
            if (!createdorupdated) return null;
            return await getBasketAsync (customerBasket.Id);

        }
    }
}
