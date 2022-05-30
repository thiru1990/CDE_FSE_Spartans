using Confluent.Kafka;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace E_Auction.Model
{
    public class AddBuyer
    {
        public class Command : IRequest
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
            public decimal BidAmount { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, Unit>
        {
            #region Declarations
            private readonly ILogger<AddBuyer> _logger;
            private ProducerConfig _producerconfig;
            #endregion

            #region Constructor
            public CommandHandler(ILogger<AddBuyer> logger, ProducerConfig ProducerConfig)
            {
                _logger = logger;
                _producerconfig = ProducerConfig;
            }
            #endregion

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("AddBuyer IN");
                var buyer = new BidRequest
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Address = request.Address,
                    City = request.City,
                    State = request.State,
                    Pin = request.Pin,
                    Phone = request.Phone,
                    Email = request.Email,
                    ProductId = request.ProductId,
                    BidAmount = request.BidAmount,
                };
                string serializedData = JsonConvert.SerializeObject(buyer);
                using (var producer = new ProducerBuilder<Null, string>(_producerconfig).Build())
                {
                    await producer.ProduceAsync("PlaceBid", new Message<Null, string>() { Value = serializedData });
                    producer.Flush(TimeSpan.FromSeconds(10));
                }
                _logger.LogInformation("AddBuyer OUT");
                //return await Task.FromResult(true);
                return Unit.Value;
            }
        }
    }
}
