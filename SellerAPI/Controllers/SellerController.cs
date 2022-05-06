using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SellerAPI.Model;
using SellerAPI.Service;
using SellerAPI.Service.Contract;
using SellerAPI.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerAPI.Controllers
{   
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("e-auction/api/{V:apiVersion}/seller")]
    public class SellerController : ControllerBase
    {
        #region Declarations
        private readonly ILogger<SellerController> _logger;
        private readonly ISellerService _SellerService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public SellerController(ILogger<SellerController> logger, ISellerService SellerService, IMapper mapper)
        {
            _logger = logger;
            _SellerService = SellerService;
            _mapper = mapper;
    }
        #endregion

        #region Operations

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("add-product")]
        public async Task<IActionResult> AddProduct(ProductRequest request)
        {
            _logger.LogInformation("SellerController AddProduct IN");
            await _SellerService.AddProduct(_mapper.Map<ProductDetails>(request));
            _logger.LogInformation("SellerController AddProduct OUT");
            return Ok("Success");
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("show-bids")]
        public async Task<IActionResult> GetBidDetails(int productId)
        {
            _logger.LogInformation("SellerController GetBidDetails IN");
            await _SellerService.GetBidDetails(productId);
            _logger.LogInformation("SellerController GetBidDetails OUT");
            return Ok("Success");
        }


        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            _logger.LogInformation("SellerController DeleteProduct IN");
            await _SellerService.DeleteProduct(productId);
             _logger.LogInformation("SellerController DeleteProduct OUT");
            return Ok("Success");
        }
        #endregion

    }
}
