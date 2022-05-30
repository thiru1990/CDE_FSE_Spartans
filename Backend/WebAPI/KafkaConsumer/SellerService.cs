using KafkaService.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaService
{
   public class SellerService
    {
        private readonly IMongoCollection<Seller> _sellerCollection;

        public SellerService()
            //IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
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

        public async Task CreateAsync(Seller newseller) =>
            await _sellerCollection.InsertOneAsync(newseller);

        public async Task UpdateAsync(string id, Seller updatedseller) =>
            await _sellerCollection.ReplaceOneAsync(x => x.Id == id, updatedseller);

        public async Task RemoveAsync(string id) =>
            await _sellerCollection.DeleteOneAsync(x => x.Id == id);
    }
}
