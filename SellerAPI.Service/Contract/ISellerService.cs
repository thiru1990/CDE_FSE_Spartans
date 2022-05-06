using SellerAPI.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerAPI.Service.Contract
{
   public interface ISellerService
    {
        Task<bool> AddProduct(ProductDetails request);
        Task<List<BidDetails>> GetBidDetails(int productId);
        Task<bool> DeleteProduct(int productId);
    }
}
