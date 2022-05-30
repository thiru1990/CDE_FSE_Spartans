using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAuctionConsumerService.Services
{
   public class BuyerDBService
    {
        private readonly IMongoCollection<Models.Buyer> _sellerCollection;

        public BuyerDBService()
        //IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            //bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase("EAuction_Buyer");
            //bookStoreDatabaseSettings.Value.DatabaseName);

            _sellerCollection = mongoDatabase.GetCollection<Models.Buyer>("Buyer");
            //bookStoreDatabaseSettings.Value.BooksCollectionName);
        }

        public void CreateBuyer(Models.Buyer newbuyer) =>
          _sellerCollection.InsertOneAsync(newbuyer);
    }
}
