using MarketAssets.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAssets.Infrastucture.DAL
{
    public class MarketAssetDbContext : DbContext
    {
        public DbSet<MarketAsset> MarketAssets { get; set; }

        public MarketAssetDbContext(DbContextOptions<MarketAssetDbContext> options)
            : base(options)
        {
        }
    }
}
