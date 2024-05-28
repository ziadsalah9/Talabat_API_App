using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models.OrederAggrigation;

namespace Talabat.Core.Services.Contract
{
    public interface IOrderService
    {

        Task<Order> CreateOrder(string BuyerEmail ,string basketId , int deliverymethodId,Address shippingAddress );
        Task<IReadOnlyList<Order>> GetOrderForUserAsync(string BuyerEmail);

        Task<Order> GetOrderByIDforUserAsync(int orderId,string BuyerEmail);

    }
}
