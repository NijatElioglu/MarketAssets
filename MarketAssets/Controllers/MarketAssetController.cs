using MarketAssets.Application.Features.MarketAsset.Query;
using MarketAssets.Domain.Entities;
using MarketAssetService.Application.Features.MarketAsset.Command.Create;
using MarketAssetService.Application.Features.MarketAsset.Command.Update;
using MarketAssetService.Application.Features.MarketAsset.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketAssetService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketAssetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MarketAssetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<MarketAsset>>> GetMarketAssets()
        {
            var assets = await _mediator.Send(new GetMarketAssetsQuery());
            return Ok(assets);
        }
        [HttpGet("{symbol}")]
        public async Task<ActionResult<MarketAsset>> GetMarketAssetPrice(string symbol)
        {
            var query = new GetMarketAssetPriceQuery { Symbol = symbol };
            var asset = await _mediator.Send(query);
            if (asset == null)
            {
                return NotFound();
            }
            return Ok(asset);
        }

        [HttpPut("{symbol}")]
        public async Task<IActionResult> UpdateMarketAssetPrice(string symbol, [FromBody] UpdateMarketAssetPriceCommand command)
        {
            if (symbol != command.Symbol)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateMarketAsset([FromBody] CreateMarketAssetCommand command)
        {
            var assetId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetMarketAssetPrice), new { symbol = command.Symbol }, assetId);
        }
    }
}
