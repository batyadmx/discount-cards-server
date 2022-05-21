using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCards.Core.Domains.ShopLocations.Repositories
{
    public interface IShopLocationsRepository
    {
        Task<ShopLocation> Get(ShopLocationRequest request);
        Task Add(ShopLocation shopLocation);
    }
}
