using MarketAssets.Domain.Entities;
using MarketAssets.Domain.Intefaces;
using MarketAssets.Infrastucture.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAssets.Infrastucture.Implementations
{
    public class MarketAssetRepository : IMarketAssetRepository
    {
        private readonly MarketAssetDbContext _context;

        public MarketAssetRepository(MarketAssetDbContext context)
        {
            _context = context;
        }

        public async Task<List<MarketAsset>> GetAllAsync()
        {
            return await _context.MarketAssets.ToListAsync();
        }

        public async Task<MarketAsset> GetBySymbolAsync(string symbol)
        {
            return await _context.MarketAssets.FirstOrDefaultAsync(ma => ma.Symbol == symbol);
        }

        public async Task AddAsync(MarketAsset asset)
        {
            _context.MarketAssets.Add(asset);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MarketAsset asset)
        {
            _context.MarketAssets.Update(asset);
            await _context.SaveChangesAsync();
        }
    }
}
