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
            var mongoClient = new MongoClient("mongodb://fsese3:jZ4XiRObOhBSQwvzIngPJgDh1jGOExLWsXhWyytgMwICagtczoplK9VxxE29tNozYaBYcTz5eLNdlVVMBrf7pw==@fsese3.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@fsese3@");
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
