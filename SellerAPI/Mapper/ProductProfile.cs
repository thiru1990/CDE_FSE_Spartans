using AutoMapper;
using SellerAPI.Model;
using SellerAPI.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerAPI.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductRequest, ProductDetails>();
        }
    }
}
