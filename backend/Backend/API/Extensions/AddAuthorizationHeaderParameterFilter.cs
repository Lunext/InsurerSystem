using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Backend.Shared;

public class AddAuthorizationHeaderParameterFilter
    :IOperationFilter
{
    private readonly string apiKey; 

    

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters ??= new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "token",
            In = ParameterLocation.Header,
            Description = "Introduce a token",
            Required = true,
            Schema = new OpenApiSchema { Type = "string"}
        });
    }

   
}

