using Confluent.Kafka;
using Newtonsoft.Json;
using EAuctionConsumerService.Services;
using System;
using System.Threading.Tasks;
using System.Threading;
using EAuctionConsumerService.Models;

namespace EAuctionConsumerService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var config = new ConsumerConfig
            {
                GroupId = "demo_group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
            {
                #region Add Product                
                consumer.Subscribe("PlaceBid");

                //CancellationTokenSource cts = new CancellationTokenSource();
                //Console.CancelKeyPress += (_, e) =>
                //{
                //    e.Cancel = true; // prevent the process from terminating.
                //    cts.Cancel();
                //};
                try
                {
                    while (true)
                    {
                        try
                        {
                            var cr = consumer.Consume();
                            if (cr != null)
                            {
                                var buyer = JsonConvert.DeserializeObject<Buyer>(cr.Message.Value);
                                var service = new BuyerDBService();
                                service.CreateBuyer(buyer);
                            }
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Error occurred: {e.Error.Reason}");

                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Ensure the consumer leaves the group cleanly and final offsets are committed.
                    consumer.Close();
                }
                #endregion
            }

            //using (var c = new ConsumerBuilder<Null, string>(config).Build())
            //{
            //    #region Delete Product                
            //    c.Subscribe("DeleteProduct");
            //    var cancelToken = new CancellationTokenSource();
            //    //CancellationTokenSource cts = new CancellationTokenSource();
            //    //Console.CancelKeyPress += (_, e) =>
            //    //{
            //    //    e.Cancel = true; // prevent the process from terminating.
            //    //    cts.Cancel();
            //    //};
            //    try
            //    {
            //        //Task.Run(async () =>
            //        //{
            //        //    while (true)
            //        //    {
            //        //        var cr = c.Consume();
            //        //        var sellerservice = new SellerService();
            //        //        await sellerservice.RemoveAsync(cr.Message.Value.ToString());
            //        //    }
            //        //});
            //        while (true)
            //        {
            //            try
            //            {
            //                var cr = c.Consume(cancelToken.Token);
            //                var val = cr.Message.Value.ToString();
            //                var sellerservice = new SellerService();
            //                sellerservice.RemoveAsync(cr.Message.Value.ToString());
            //            }
            //            catch (ConsumeException e)
            //            {
            //                Console.WriteLine($"Error occurred: {e.Error.Reason}");

            //            }
            //        }
            //    }
            //    catch (OperationCanceledException)
            //    {
            //        // Ensure the consumer leaves the group cleanly and final offsets are committed.
            //        c.Close();
            //    }
            //    #endregion                
            //}

            //using (var APConsumer = new ConsumerBuilder<Null, string>(config).Build())
            //{
            //    #region Add Product                
            //    APConsumer.Subscribe("AddProduct");

            //    //CancellationTokenSource cts = new CancellationTokenSource();
            //    //Console.CancelKeyPress += (_, e) =>
            //    //{
            //    //    e.Cancel = true; // prevent the process from terminating.
            //    //    cts.Cancel();
            //    //};
            //    try
            //    {
            //        while (true)
            //        {
            //            try
            //            {
            //                var cr = APConsumer.Consume();
            //                if(cr!= null)
            //                {                             
            //                var seller = JsonConvert.DeserializeObject<Seller>(cr.Message.Value);
            //                    var sellerservice = new SellerService();
            //                    sellerservice.CreateSeller(seller);
            //                }
            //            }
            //            catch (ConsumeException e)
            //            {
            //                Console.WriteLine($"Error occurred: {e.Error.Reason}");

            //            }
            //        }
            //    }
            //    catch (OperationCanceledException)
            //    {
            //        // Ensure the consumer leaves the group cleanly and final offsets are committed.
            //        APConsumer.Close();
            //    }
            //    #endregion
            //}
        }
    }
}
