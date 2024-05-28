namespace Talabat.Error
{
    public class ApiExcptionResponse : ApiResponse
    {
        public string Details { get; set; }

        public ApiExcptionResponse(int statuscode, string? message = null, string? Details = null ) : base( statuscode, message )
        {
            this.Details = Details;
        }


    }
}
