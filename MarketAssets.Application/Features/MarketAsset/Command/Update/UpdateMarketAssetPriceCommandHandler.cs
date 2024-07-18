using MarketAssets.Domain.Intefaces;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAssetService.Application.Features.MarketAsset.Command.Update
{

    public class UpdateMarketAssetPriceCommandHandler : IRequestHandler<UpdateMarketAssetPriceCommand, Unit>
    {
        private readonly IMarketAssetRepository _repository;

        public UpdateMarketAssetPriceCommandHandler(IMarketAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateMarketAssetPriceCommand request, CancellationToken cancellationToken)
        {
            var asset = await _repository.GetBySymbolAsync(request.Symbol);
            if (asset == null)
            {
                asset = new MarketAssets.Domain.Entities.MarketAsset
                {
                    Symbol = request.Symbol,
                    Price = request.Price,
                    LastUpdated = request.LastUpdated
                };
                await _repository.AddAsync(asset);
            }
            else
            {
                asset.Price = request.Price;
                asset.LastUpdated = request.LastUpdated;
                await _repository.UpdateAsync(asset);
            }

            return Unit.Value;
        }
    }
}
