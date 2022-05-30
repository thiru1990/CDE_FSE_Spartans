using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace KafkaService
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

            using (var c = new ConsumerBuilder<Null, string>(config).Build())
            {
                #region Delete Product                
                c.Subscribe("DeleteProduct");

                //CancellationTokenSource cts = new CancellationTokenSource();
                //Console.CancelKeyPress += (_, e) =>
                //{
                //    e.Cancel = true; // prevent the process from terminating.
                //    cts.Cancel();
                //};
                try
                {
                    Task.Run(async() => 
                    {
                        while (true)
                        {
                            var cr = c.Consume();
                            var sellerservice = new SellerService();
                           await sellerservice.RemoveAsync(cr.Message.Value.ToString());
                        }
                    });
                    //while (true)
                    //{
                    //    try
                    //    {
                            
                    //        var cr = c.Consume();
                    //        var val = cr.Message.Value.ToString();
                    //        var sellerservice = new SellerService();
                    //        sellerservice.RemoveAsync(cr.Message.Value.ToString());
                    //    }
                    //    catch (ConsumeException e)
                    //    {
                    //        Console.WriteLine($"Error occurred: {e.Error.Reason}");

                    //    }
                    //}
                }
                catch (OperationCanceledException)
                {
                    // Ensure the consumer leaves the group cleanly and final offsets are committed.
                    c.Close();
                }
                #endregion

                #region Add Product                
                c.Subscribe("AddProduct");

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
                            var cr = c.Consume();
                            var val = cr.Message.Value.ToString();
                            var pro =  JsonConvert.DeserializeObject(cr.Message.Value);
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
                    c.Close();
                }
                #endregion
            }
        }

    }

}
