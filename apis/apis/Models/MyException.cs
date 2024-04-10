namespace apis.Models
{
    public class MyException : Exception
    {
        public int StatusCode { get; set; }

        public MyException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
