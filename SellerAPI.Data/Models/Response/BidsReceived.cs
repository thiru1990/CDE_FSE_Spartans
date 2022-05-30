using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerAPI.Data.Models.Response
{
   public class BidsReceived
    {
        public string Email { get; set; }
        public decimal BidAmount { get; set; }
    }
}
