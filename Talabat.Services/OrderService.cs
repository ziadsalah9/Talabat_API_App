
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.IRepositories;
using Talabat.Core.Models;
using Talabat.Core.Models.OrederAggrigation;
using Talabat.Core.Services.Contract;

namespace Talabat.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<DeliveryMethod> _deliveryMethodRepo;
        private readonly IGenericRepository<Order> _orderRepo;

        public OrderService(IBasketRepository basketRepository ,IGenericRepository<Product> ProductRepository ,IGenericRepository<DeliveryMethod> DeliveryMethodRepo , IGenericRepository<Order> orderRepo )
        {
            _basketRepository = basketRepository;
            _productRepository = ProductRepository;
            _deliveryMethodRepo = DeliveryMethodRepo;
            _orderRepo = orderRepo;
        }

        public async Task<Order> CreateOrder(string BuyerEmail, string basketId, int deliverymethodId, Address shippingAddress)
        {

            // 1 -  Get Basket repoistory (which contains product user want to buy )

            var basket = await _basketRepository.getBasketAsync(basketId);

            // 2 -  item user selected in basket from product Repo (to validate because he may be send me fake price) -- just want (id , quantity)

              List<OrderItem> OrderItems = new List<OrderItem>();

             if(basket?.Items?.Count>=0)
            {
                foreach (var item in basket.Items)
                {

                    var product = await _productRepository.GetByIdAsync(item.Id);

                    var productitemordered = new ProductItemOrderd(item.Id,product.Name,product.PictureUrl);

                    var orderitems = new OrderItem(productitemordered, product.Price,item.Quantity)


                      OrderItems.Add(orderitems);
                }
                
            }

            // 3 - calculate SubTotal Price

             var subTotal = OrderItems.Sum(p=>p.Quantity * p.Price);

            // 4- Get deliveryMtheod from delivery method Rebo

            var deliverymethod = await _deliveryMethodRepo.GetByIdAsync(deliverymethodId);

            // 5- create order 
            var order = new Order(BuyerEmail, shippingAddress, deliverymethod, OrderItems, subTotal);
             
            
            await _orderRepo.AddAsync(order);   

            // 6 - save to database

         
        }

        public Task<Order> GetOrderByIDforUserAsync(int orderId, string BuyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrderForUserAsync(string BuyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
