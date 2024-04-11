namespace apis.Models
{
    public class HtttpException : Exception
    {
        public int StatusCode { get; set; }
        public string Detail { get; set; }

        public HtttpException(int statusCode, string message, string detail) : base(message)
        {
            StatusCode = statusCode;
            Detail= detail;
        }
    }
}
