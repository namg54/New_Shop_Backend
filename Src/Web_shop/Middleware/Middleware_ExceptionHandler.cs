using Domain.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;


namespace Web_shop.Middleware
{
    public class Middleware_ExceptionHandler
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILoggerFactory _logger;
        private readonly RequestDelegate _next;
        //private readonly WebApplicationBuilder _builder;


        public Middleware_ExceptionHandler(IWebHostEnvironment env, ILoggerFactory logger, RequestDelegate next)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

                if (context.Response.StatusCode != 200 && context.Response.StatusCode!=301)
                {
                    throw new Exception(context.Response.StatusCode.ToString());
                }
            }
            catch (Exception e)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                string result = HandleServerError(context, e, options);

                result = HandleRequestResult(context, e, result, options);


                await context.Response.WriteAsync(result);
            }
        }

        private static string HandleServerError(HttpContext context, Exception e, JsonSerializerOptions options)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonSerializer.Serialize(new ApiToReturn(500, e.Message), options);
            return result;
        }

        private string HandleRequestResult(HttpContext context, Exception e, string result, JsonSerializerOptions options)
        {
            switch (e.Message)
            {
                case "404":
                case "204":
                    var notFoundException = new NotFoundException();
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(
                        new ApiToReturn(404, notFoundException.Message, notFoundException.Messages, e.Message), options);
                    break;
                case "400":
                    var badRequestException = new BadRequestException();
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(
                        new ApiToReturn(400, badRequestException.Message, badRequestException.Messages, e.Message), options);
                    break;
                    //case "400":
                    //    var validationEntityException = new ValidationEntityException();
                    //    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //    result=JsonSerializer.Serialize(
                    //        new ApiToReturn(400,validationEntityException.Message,validationEntityException.Messages, e.Message), options);
                    //    break;
            }
            return result;

        }
    }
}
