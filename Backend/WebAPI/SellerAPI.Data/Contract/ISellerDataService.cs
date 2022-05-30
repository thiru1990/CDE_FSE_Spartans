using SellerAPI.Data.Models;
using SellerAPI.Data.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerAPI.Data.Contract
{
   public interface ISellerDataService
    {
        Task<bool> AddProducts(Seller request);
        Task<bool> DeleteProduct(string productId);
        Task<BidDetailsResponse> GetBidDetails(int productId);
    }
}
