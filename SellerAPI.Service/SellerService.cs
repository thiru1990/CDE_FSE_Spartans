using Microsoft.Extensions.Logging;
using SellerAPI.Service.Contract;
using SellerAPI.Service.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SellerAPI.Service
{
    public class SellerService: ISellerService
    {
        #region Declarations
        private readonly ILogger<SellerService> _logger;
        #endregion

        #region Constructor
        public SellerService(ILogger<SellerService> logger)
        {
            _logger = logger;
        }
        #endregion

        #region Operations
        public async Task<bool> AddProduct(ProductDetails request)
        {
            _logger.LogInformation("SellerService AddProduct IN");
            _logger.LogInformation("SellerService AddProduct OUT");
            return await Task.FromResult(true);
        }

        public async Task<List<BidDetails>> GetBidDetails(int productId)
        {
            _logger.LogInformation("SellerService GetBidDetails IN");
            var response = new List<BidDetails> { new BidDetails { ProductID = 1, ProductName = "abc", BidAmount = 201, StartingPrice = 100 } };
            _logger.LogInformation("SellerService GetBidDetails OUT");
            return await Task.FromResult(response);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            _logger.LogInformation("SellerService DeleteProduct IN");
            _logger.LogInformation("SellerService DeleteProduct OUT");
            return await Task.FromResult(true);
        }
        #endregion

    }
}
