using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SellerAPI.Data.Contract;
using SellerAPI.Data.Models;
using SellerAPI.Data.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerAPI.Data
{
    public class SellerDataService : ISellerDataService
    {
        #region Declarations
        private readonly ILogger<SellerDataService> _logger;
        private readonly IMongoCollection<Seller> _sellerCollection;
        private readonly IMongoCollection<Buyer> _buyerCollection;
        #endregion

        #region Constructor 
        public SellerDataService(IOptions<SellerMongoDBConfig> sellerDatabaseSettings,
            IOptions<BuyerMongoDBConfig> buyerDatabaseSettings, ILogger<SellerDataService> logger)
        {
            var sellerMongoClient = new MongoClient(
       sellerDatabaseSettings.Value.ConnectionString);

            var sellerMongoDatabase = sellerMongoClient.GetDatabase(
                sellerDatabaseSettings.Value.DatabaseName);

            _sellerCollection = sellerMongoDatabase.GetCollection<Seller>(
                sellerDatabaseSettings.Value.CollectionName);

            var buyerMongoClient = new MongoClient(
      buyerDatabaseSettings.Value.ConnectionString);

            var buyerMongoDatabase = buyerMongoClient.GetDatabase(
                buyerDatabaseSettings.Value.DatabaseName);

            _buyerCollection = buyerMongoDatabase.GetCollection<Buyer>(
                buyerDatabaseSettings.Value.CollectionName);

            _logger = logger;

        }
        #endregion

        #region Operations
        public async Task<bool> AddProducts(Seller request)
        {
            _logger.LogInformation("SellerDataService AddProduct IN");
            await _sellerCollection.InsertOneAsync(request);
            _logger.LogInformation("SellerDataService AddProduct OUT");
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteProduct(string productId)
        {
            _logger.LogInformation("SellerDataService DeleteProduct IN");
            await _sellerCollection.DeleteOneAsync(x => x.Id == productId);
            _logger.LogInformation("SellerDataService DeleteProduct OUT");
            return await Task.FromResult(true);
        }

        public async Task<BidDetailsResponse> GetBidDetails(int productId)
        {            
            _logger.LogInformation("SellerDataService GetBidDetails IN");
            var bidsReceived = new List<BidsReceived>();
          var sellerinfo = await _sellerCollection.Find(x => x.ProductId == productId).FirstOrDefaultAsync();
          var bidsList =  await _buyerCollection.Find(x => x.ProductId == productId).SortByDescending(x => x.BidAmount).ToListAsync();
            bidsList.ForEach(item => bidsReceived.Add(new BidsReceived() { BidAmount = item.BidAmount, Email = item.Email
            }));
            var response = new BidDetailsResponse {
                ShortDescription =  sellerinfo.ShortDescription,
                DetailedDescription = sellerinfo.DetailedDescription,
                Category = sellerinfo.Category,
                StartingPrice = sellerinfo.StartingPrice,
                BidEndDate = sellerinfo.BidEndDate,
                BidsReceived = bidsReceived
                };
            _logger.LogInformation("SellerDataService GetBidDetails OUT");
            return await Task.FromResult(response);
        }
        #endregion
    }
}
