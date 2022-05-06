using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerAPI.CustomFilter
{
    public class HeaderParameterFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();                      
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "CorrelationId",
                In = ParameterLocation.Header,
                Description = "Unique identifier to track every request"
            });

        }
    }
}
