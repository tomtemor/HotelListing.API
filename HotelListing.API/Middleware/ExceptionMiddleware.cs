﻿using HotelListing.API.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace HotelListing.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong with {context.Request.Path}");

                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            HttpStatusCode statuscode = HttpStatusCode.InternalServerError;

            var errorDetails = new ErrDetails
            {
                ErrorType = "Failure",
                ErrorMessage = ex.Message,
            };

            switch(ex)
            {
                case NotFoundException notFoundException:
                    statuscode = HttpStatusCode.NotFound;
                    errorDetails.ErrorType = "Not Found";
                    break;
                    default:
                    break;
            }

            //string response = JsonConvert.SerializeObject(errorDetails);
            context.Response.StatusCode = (int)statuscode;
            //return context.Response.WriteAsync(response);
            return context.Response.WriteAsJsonAsync(errorDetails);
            // **>CK with WriteAsJsonAsync there is no need to first serialize the object.
        }
    }

    public class ErrDetails
    {
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }    
    }
}
