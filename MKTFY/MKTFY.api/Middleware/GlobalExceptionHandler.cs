using Microsoft.EntityFrameworkCore;
using MKTFY.Shared.Exceptions;
using Npgsql;
using System.Net;
using System.Text.Json;

namespace MKTFY.api.Middleware
{
    /// <summary>
    /// Global exception Handler 
    /// </summary>
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Handeling exceptions for the listings
        /// </summary>
        /// <param name="next"></param>
        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>
        /// Handeling the exceptions through the pipeline steps 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            // call next when ready to contine to next pipeline step 
            // code befor _next call will be processed when the pipline is handeling the inital request 
            // code after _next call will be processed when the pipeline is handeling the response

            try
            {
                await _next(context);
            }
            catch (Exception err)
            {
                // get the response object so we can edit it. 
                var response = context.Response;
                response.ContentType = "application/json";
                string errorMessage;

                switch (err)
                {
                    case NotFoundException e: // handels all not found exceptions thrown by the system 
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        errorMessage = e.Message;
                        break;
                    case DbUpdateException: // handels all DBUpdate exceptionsand DB UPdate concurrency exceptions thrown by the system 
                    case PostgresException:// hanbdels general postgres databse connectio exceptions
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        errorMessage = "We are sorry, we were unable to complete your request, Please try again later";
                        break;
                    default: //Some Unknown error we want to prevent generic 500 errors from being returned
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        errorMessage = "We are sorry, your request could not be completed";
                        break;
                }

                // retun the response 
                var result = JsonSerializer.Serialize(new { message = errorMessage });
                await response.WriteAsync(result);
            }
        }
    }
}
