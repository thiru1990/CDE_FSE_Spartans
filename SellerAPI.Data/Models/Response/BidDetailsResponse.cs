using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerAPI.Data.Models.Response
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
