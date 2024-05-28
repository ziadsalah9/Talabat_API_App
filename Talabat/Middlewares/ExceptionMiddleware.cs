using System.Net;
using System.Text.Json;
using Talabat.Error;

namespace Talabat.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IWebHostEnvironment environment;

        public ExceptionMiddleware(RequestDelegate next ,ILogger<ExceptionMiddleware> logger , IWebHostEnvironment environment )
        {
            this.next = next;
            this.logger = logger;
            this.environment = environment;
        }



        public async Task Invoke(HttpContext context) {


            try
            {
                await next.Invoke(context);

            }
            catch (Exception ex)
            {

               
                    logger.LogError(ex, ex.Message);
              
                    // log in database or file 


                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var response = environment.IsDevelopment() ? 
                    new ApiExcptionResponse(StatusCodes.Status500InternalServerError, ex.Message, ex.StackTrace.ToString())
                    : new ApiExcptionResponse(StatusCodes.Status500InternalServerError);
                        ;

                var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                    var Json = JsonSerializer.Serialize(response,options);

                    await context.Response.WriteAsync(Json);
                
                
            }            

            


        }



    }
}
