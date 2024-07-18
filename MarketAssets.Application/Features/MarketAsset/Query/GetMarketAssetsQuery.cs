using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAssetService.Application.Features.MarketAsset.Queries
{
    public class GetMarketAssetsQuery : IRequest<List<MarketAssets.Domain.Entities.MarketAsset>>
    {
    }
}
