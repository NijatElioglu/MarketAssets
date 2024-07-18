using MarketAssets.Domain.Intefaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAssetService.Application.Features.MarketAsset.Command.Create
{
    public class CreateMarketAssetCommandHandler : IRequestHandler<CreateMarketAssetCommand, int>
    {
        private readonly IMarketAssetRepository _repository;

        public CreateMarketAssetCommandHandler(IMarketAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateMarketAssetCommand request, CancellationToken cancellationToken)
        {
            var asset = new MarketAssets.Domain.Entities.MarketAsset
            {
                Id=request.Id,
                Symbol = request.Symbol,
                Price = request.Price,
                LastUpdated = request.LastUpdated
            };

            await _repository.AddAsync(asset);
            return asset.Id;
        }
    }
}
