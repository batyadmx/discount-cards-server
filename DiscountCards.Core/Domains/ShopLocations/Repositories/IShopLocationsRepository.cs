using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCards.Core.Domains.ShopLocations.Repositories
{
    public interface IShopLocationsRepository
    {
        Task Add(ShopLocation shopLocation, ShopLocationRequest request);
        Task<List<ShopLocation>> GetAll(ShopLocationRequest request);
    }
}
