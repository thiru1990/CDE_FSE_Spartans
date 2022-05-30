using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerAPI.Service.Model
{
   public class BidDetails
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public string Category { get; set; }//should be enum
        public decimal StartingPrice { get; set; }
        public DateTime BidEndDate { get; set; }
        public decimal BidAmount { get; set; }
    }
}
