namespace apis.Models
{
    public class MyException : Exception
    {
        public int StatusCode { get; set; }
        public string Detail { get; set; }

        public MyException(int statusCode, string message, string detail) : base(message)
        {
            StatusCode = statusCode;
            Detail= detail;
        }
    }
}
