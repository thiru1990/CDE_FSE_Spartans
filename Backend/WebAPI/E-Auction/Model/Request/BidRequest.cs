using System;

namespace E_Auction.Model
{
    public class BidRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pin { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int ProductId { get; set; }
        public decimal BidAmount  { get; set; }

}
}
