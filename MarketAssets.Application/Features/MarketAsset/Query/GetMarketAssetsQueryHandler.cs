
using MarketAssets.Domain.Intefaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAssetService.Application.Features.MarketAsset.Queries
{
    public class GetMarketAssetsQueryHandler : IRequestHandler<GetMarketAssetsQuery, List<MarketAssets.Domain.Entities.MarketAsset>>
    {
        private readonly IMarketAssetRepository _repository;

        public GetMarketAssetsQueryHandler(IMarketAssetRepository repository)
        {
            _repository = repository;
        }

       

         async Task<List<MarketAssets.Domain.Entities.MarketAsset>> IRequestHandler<GetMarketAssetsQuery, List<MarketAssets.Domain.Entities.MarketAsset>>.Handle(GetMarketAssetsQuery request, CancellationToken cancellationToken)
        {

            return await _repository.GetAllAsync();
        }
    }
}
