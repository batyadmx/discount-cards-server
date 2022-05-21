using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCards.Core.Domains.ShopLocations.Services
{
    public interface IShopLocationsService
    {
        Task<ShopLocation> GetShopLocation(ShopLocationRequest request);
    }
}
