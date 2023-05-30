namespace API.Errors
{
    public class ApiException : ApiResponse
    {
        public string Details { get; set; }

        public ApiException(int stausCode, string message = null, string details = null)
            : base(stausCode, message)
        {
            Details = details;
        }
    }
}
