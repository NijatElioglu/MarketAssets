using MarketAssets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAssets.Domain.Intefaces
{
    public interface IMarketAssetRepository
    {

        Task<List<MarketAsset>> GetAllAsync();
        Task<MarketAsset> GetBySymbolAsync(string symbol);
        Task AddAsync(MarketAsset asset);
        Task UpdateAsync(MarketAsset asset);
    }
}
