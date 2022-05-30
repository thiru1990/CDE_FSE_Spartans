using Confluent.Kafka;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SellerAPI.Model
{
    public class DeleteProduct
    {
        public class Command : IRequest
        {
           public string id { get; set; } 
        }

     

        public class CommandHandler : IRequestHandler<Command, Unit>
        {
            #region Declarations
            private readonly ILogger<DeleteProduct> _logger;
            private ProducerConfig _producerconfig;
            #endregion

            #region Constructor
            public CommandHandler(ILogger<DeleteProduct> logger, ProducerConfig ProducerConfig)
            {
                _logger = logger;
                _producerconfig = ProducerConfig;
            }
            #endregion

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("DeleteProduct IN");
                using (var producer = new ProducerBuilder<Null, string>(_producerconfig).Build())
                {
                    await producer.ProduceAsync("DeleteProduct", new Message<Null, string>() { Value = request.id });
                    producer.Flush(TimeSpan.FromSeconds(10));
                }
                _logger.LogInformation("DeleteProduct OUT");
                //return await Task.FromResult(true);
                return Unit.Value;
            }
        }

    }

    
}
