using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.IRepositories;
using Talabat.Core.Models;
using Talabat.Dtos;
using Talabat.Error;
using Talabat.Repository;

namespace Talabat.Controllers
{
   
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository , IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasket (string id)
        {
            var result = await _basketRepository.getBasketAsync(id);
            
            return Ok( result ?? new CustomerBasket(id));
        }

        [HttpPost]

        public async Task <ActionResult<CustomerBasket>> UpdateBasekt (CustomerBasketDto basket)
        {

            var basketmapping = _mapper.Map<CustomerBasketDto,CustomerBasket>(basket);
            var result = await _basketRepository.updateBasketAsync(basketmapping);
            if(result==null) {
                return BadRequest(new ApiResponse(400));
                    
                    }

            return Ok(result);
        }


        [HttpDelete]
        public async Task DeleteBasket (string id)
        {
            await _basketRepository.DeleteBasketAsync(id);

            
        }



    }
}
