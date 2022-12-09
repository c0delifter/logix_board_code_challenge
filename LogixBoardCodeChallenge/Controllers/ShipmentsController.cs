using LogixBoardCodeChallenge.Domain.Interfaces;
using LogixBoardCodeChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace LogixBoardCodeChallenge.Controllers
{
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly IApi _api;
        public ShipmentsController(IApi api)
        {
            _api = api;
        }

        [HttpGet("api/shipments/{id}")]
        public async Task<bool> Get(string id, CancellationToken cancellationToken)
        {
            await _api.GetShipment(id, cancellationToken);
            return true;
        }

        [HttpPost("api/shipments")]
        public async Task<bool> Post(Shipment shipment, CancellationToken cancellationToken)
        {
            await _api.UpsertShipment(shipment, cancellationToken);
            return true;
        }
    }
}
