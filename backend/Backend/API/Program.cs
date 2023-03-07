using Backend.Shared;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy", policy => {
        policy.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .WithOrigins("http://127.0.0.1:5173");
    });
});


builder.Services.AddScoped<HeaderMiddleware>();
builder.Services.AddInsurerContext();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(doc =>
{
    doc.SwaggerDoc("v1", new()
    {
        Title="Insurer Service API",
        Version="v1"

    });
    

    doc.OperationFilter<AddAuthorizationHeaderParameterFilter>();

   

});


//To inject the repository
builder.Services.AddScoped<IInsurerRepository, InsurerRepository>();
//To inject the fluent validation the entries
builder.Services.AddScoped<IValidator<Insurer>, InsurerValidator>();






var app = builder.Build();

//app.Use(async (context, next) =>
//{
//    context.Response.Headers.Add("Content-Type", "text/javascript");
//    await next();
//});

app.UseCors("CorsPolicy");
//app.UseCors(configurePolicy: options =>
//{


////ptions.AllowAnyOrigin();
//    options.WithMethods("GET", "POST", "PUT", "DELETE");
//    //options.WithOrigins(
//       // "http://127.0.0.1:5173");
//    options.WithHeaders("Authorization");
//});



// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{

   
    app.UseSwagger();

    
    app.UseSwaggerUI(doc =>
    {
      
        doc.SwaggerEndpoint("/swagger/v1/swagger.json", "" +
            "Insurer Service API Version 1");
        doc.SupportedSubmitMethods(new[]
        {
            SubmitMethod.Get, SubmitMethod.Post,
            SubmitMethod.Put, SubmitMethod.Delete
        });

       
       
       
    });
  
    app.UseMiddlewareExtension();
    app.UseAuthentication();
   
   // app.UseAuthorization();

}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<InsurerDbContext>();
    context.Database.Migrate();

}
catch(Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error ocurred during migration"); 
    
}

app.Run();
