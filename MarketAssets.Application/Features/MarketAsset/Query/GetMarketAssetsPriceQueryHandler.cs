using MarketAssets.Domain.Intefaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAssets.Application.Features.MarketAsset.Query
{
    public class GetMarketAssetPriceQueryHandler : IRequestHandler<GetMarketAssetPriceQuery, MarketAssets.Domain.Entities.MarketAsset>
    {
        private readonly IMarketAssetRepository _repository;

        public GetMarketAssetPriceQueryHandler(IMarketAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<MarketAssets.Domain.Entities.MarketAsset> Handle(GetMarketAssetPriceQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetBySymbolAsync(request.Symbol);
        }
    }
}
