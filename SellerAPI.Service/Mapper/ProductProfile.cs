using AutoMapper;
using SellerAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerAPI.Service.Mapper
{
   public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<SellerAPI.Service.Model.ProductDetails, Seller>();
        }
    }
}
