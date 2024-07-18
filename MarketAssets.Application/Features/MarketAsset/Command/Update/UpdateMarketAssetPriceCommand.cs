using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAssetService.Application.Features.MarketAsset.Command.Update
{
    public class UpdateMarketAssetPriceCommand:IRequest<Unit>
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
