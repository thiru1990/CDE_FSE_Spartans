using AutoMapper;
using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SellerAPI.Data.Contract;
using SellerAPI.Data.Models;
using SellerAPI.Data.Models.Response;
using SellerAPI.Service.Contract;
using SellerAPI.Service.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SellerAPI.Service
{
    public class SellerService: ISellerService
    {
        #region Declarations
        private readonly ILogger<SellerService> _logger;
        private ProducerConfig _producerconfig;
        private readonly IMapper _mapper;
        private readonly ISellerDataService _dataServices;
        #endregion

        #region Constructor
        public SellerService(ILogger<SellerService> logger, ProducerConfig ProducerConfig, IMapper mapper, ISellerDataService dataServices)
        {
            _logger = logger;
            _producerconfig = ProducerConfig;
            _mapper = mapper;
            _dataServices = dataServices;

        }
        #endregion

        #region Operations
        public async Task<bool> AddProduct(ProductDetails request)
        {
            _logger.LogInformation("SellerService AddProduct IN");
            string serializedData = JsonConvert.SerializeObject(request);
            using (var producer = new ProducerBuilder<Null, string>(_producerconfig).Build())
            {
                await producer.ProduceAsync("AddProduct", new Message<Null, string>() { Value = serializedData });
                producer.Flush(TimeSpan.FromSeconds(10));
            }
            _logger.LogInformation("SellerService AddProduct OUT");
            return await Task.FromResult(true);
        }

        public async Task<bool> AddProducts(ProductDetails request)
        {
            _logger.LogInformation("SellerService AddProduct IN");
            await _dataServices.AddProducts(_mapper.Map<Seller>(request));            
            _logger.LogInformation("SellerService AddProduct OUT");
            return await Task.FromResult(true);
        }

        public async Task<Data.Models.Response.BidDetailsResponse> GetBidDetails(int productId)
        {
            _logger.LogInformation("SellerService GetBidDetails IN");
             var response =  await _dataServices.GetBidDetails(productId);
            _logger.LogInformation("SellerService GetBidDetails OUT");
            return response;
        }

        public async Task<bool> DeleteProduct(string productId)
        {
            _logger.LogInformation("SellerService DeleteProduct IN");
            //using (var producer = new ProducerBuilder<Null,string>(_producerconfig).Build())
            //{
            //    await producer.ProduceAsync("DeleteProduct", new Message<Null, string>() { Value = productId });
            //    producer.Flush(TimeSpan.FromSeconds(10));
            //}
            await _dataServices.DeleteProduct(productId);
                _logger.LogInformation("SellerService DeleteProduct OUT");
            return await Task.FromResult(true);
        }
        #endregion

    }
}
