using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerAPI.Model.Response
{
    public class BidDetailsResponse
    {
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public string Category { get; set; }//should be enum
        public decimal StartingPrice { get; set; }
        public DateTime BidEndDate { get; set; }
        public List<BidsReceived> BidsReceived { get; set; }
    }
}
