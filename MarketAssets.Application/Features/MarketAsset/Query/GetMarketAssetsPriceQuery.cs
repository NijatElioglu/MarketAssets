using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAssets.Application.Features.MarketAsset.Query
{
    public class GetMarketAssetPriceQuery : IRequest<MarketAssets.Domain.Entities.MarketAsset>
    {
        public string Symbol { get; set; }
    }
}
