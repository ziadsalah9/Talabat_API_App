using Microsoft.AspNetCore.Mvc;

namespace Talabat.Error
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int statuscode,string? message =null )
        {
            StatusCode = statuscode;
            Message = message ?? GetDefaultMessageForStatusCode(statuscode);


        }

        private string? GetDefaultMessageForStatusCode(int statuscode)
        {
            return statuscode switch
            {
                400 => "A Bad Request, you have made",
                401 => "authorized, you have not",
                404 => "Resource Was Not Found ,",
                500 => "Error are the path to the dark side",
                _ => null
            };


        }
    }
}
