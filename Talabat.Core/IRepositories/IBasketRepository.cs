using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models;

namespace Talabat.Core.IRepositories
{
    public interface IBasketRepository
    {

        Task<CustomerBasket?> getBasketAsync(string BasketId);
        Task<CustomerBasket?> updateBasketAsync(CustomerBasket customerBasket);

        Task<bool> DeleteBasketAsync(string BasketId);


    }
}
