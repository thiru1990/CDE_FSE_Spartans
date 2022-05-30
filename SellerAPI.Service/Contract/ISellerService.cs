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
        Task<bool> AddProducts(ProductDetails request);
        Task<Data.Models.Response.BidDetailsResponse> GetBidDetails(int productId);
        Task<bool> DeleteProduct(string productId);
    }
}
