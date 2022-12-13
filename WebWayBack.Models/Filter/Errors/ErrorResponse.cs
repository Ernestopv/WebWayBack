namespace WebWayBack.Models.Filter.Errors
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }

        public List<ErrorResponseDetail> Details { get; set; } = new List<ErrorResponseDetail>();
    }
}
