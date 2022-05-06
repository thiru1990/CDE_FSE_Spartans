﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerAPI.Service.Model
{
  public class ProductDetails
    {

            public string ProductName { get; set; }
            public string ShortDescription { get; set; }
            public string DetailedDescription { get; set; }
            public string Category { get; set; }//should be enum
            public decimal StartingPrice { get; set; }
            public DateTime BidEndDate { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Pin { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
        }    
}
