using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountCards.API.Controllers.Shops.Dto;
using DiscountCards.Core.Domains.Shops.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiscountCards.API.Controllers.Shops
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ShopDto>> GetAllShopsAsync()
        {
            var shops = await _shopService.GetAllShopsAsync();

            return shops.Select(x => new ShopDto()
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}