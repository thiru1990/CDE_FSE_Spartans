using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace E_Auction.Model
{
    public class UpdateBid
    {
        public class Command : IRequest
        {
            public string Email { get; set; }
            public int ProductId { get; set; }
            public decimal BidAmount { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, Unit>
        {
            #region Declarations
            private readonly ILogger<UpdateBid> _logger;
            private readonly IMongoCollection<Buyer> _buyerCollection;
            #endregion

            #region Constructor
            public CommandHandler(IOptions<BuyerMongoDBConfig> buyerDatabaseSettings, ILogger<UpdateBid> logger)
            {
                    var mongoClient = new MongoClient(
                    buyerDatabaseSettings.Value.ConnectionString);

                var mongoDatabase = mongoClient.GetDatabase(
                    buyerDatabaseSettings.Value.DatabaseName);

                _buyerCollection = mongoDatabase.GetCollection<Buyer>(
                    buyerDatabaseSettings.Value.CollectionName);
                _logger = logger;
            }
            #endregion

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("UpdateBid IN");
                var filter = Builders<Buyer>.Filter.Eq(f => f.Email,request.Email) & Builders<Buyer>.Filter.Eq(f => f.ProductId, request.ProductId);
               await _buyerCollection.UpdateOneAsync(filter, Builders<Buyer>.Update.Set("BidAmount", request.BidAmount));
                _logger.LogInformation("UpdateBid OUT");
                //return await Task.FromResult(true);
                return Unit.Value;
            }
        }


    }
}
