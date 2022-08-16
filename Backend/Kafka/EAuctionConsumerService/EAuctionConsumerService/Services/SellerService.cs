using EAuctionConsumerService.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAuctionConsumerService.Services
{
   public class SellerService
    {
        private readonly IMongoCollection<Seller> _sellerCollection;

        public SellerService()
        //IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient("mongodb://fsese3:jZ4XiRObOhBSQwvzIngPJgDh1jGOExLWsXhWyytgMwICagtczoplK9VxxE29tNozYaBYcTz5eLNdlVVMBrf7pw==@fsese3.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@fsese3@");
            //bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase("EAuction_Seller");
            //bookStoreDatabaseSettings.Value.DatabaseName);

            _sellerCollection = mongoDatabase.GetCollection<Seller>("Seller");
            //bookStoreDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<Seller>> GetAsync() =>
            await _sellerCollection.Find(_ => true).ToListAsync();

        public async Task<Seller?> GetAsync(string id) =>
            await _sellerCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public void CreateSeller(Seller newseller) =>
            _sellerCollection.InsertOneAsync(newseller);

        public async Task UpdateAsync(string id, Seller updatedseller) =>
            await _sellerCollection.ReplaceOneAsync(x => x.Id == id, updatedseller);

        public void RemoveAsync(string id) =>
             _sellerCollection.DeleteOneAsync(x => x.Id == id);    
}
}
