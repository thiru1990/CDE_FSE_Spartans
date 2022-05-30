using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Auction.Model
{
    public class UpdateBidRequest
    {
        public string Email { get; set; }
        public int ProductId { get; set; }
        public decimal BidAmount { get; set; }
    }
}
