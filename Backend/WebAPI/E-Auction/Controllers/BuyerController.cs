using BuyerAPI.Service.Contract;
using E_Auction.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Auction
{    
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/buyer")]
    public class BuyerController : ControllerBase
    {
        #region Declarations
        private readonly ILogger<BuyerController> _logger;
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public BuyerController(ILogger<BuyerController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        #endregion

        #region Operations

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("place-bid")]
        public async Task<IActionResult> PlaceBid(BidRequest request)
        {
            _logger.LogInformation("BuyerController AddProduct IN");
           var command = new AddBuyer.Command{
               FirstName = request.FirstName,
               LastName = request.LastName,
               Address = request.Address,
               City = request.City,
               State = request.State,
               Pin = request.Pin,
               Phone = request.Phone,
               Email = request.Email,
               ProductId = request.ProductId,
               BidAmount = request.BidAmount
           };
            await _mediator.Send(command);
            _logger.LogInformation("BuyerController AddProduct OUT");
            return Ok("Success");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("update-bid")]
        public async Task<IActionResult> UpdateBid(UpdateBidRequest request)
        {
            _logger.LogInformation("BuyerController AddProduct IN");
            var command = new UpdateBid.Command
            {
              Email = request.Email,
              BidAmount = request.BidAmount,
              ProductId = request.ProductId
            };
            await _mediator.Send(command);
            _logger.LogInformation("BuyerController AddProduct OUT");
            return Ok("Success");
        }

        #endregion
    }
}
