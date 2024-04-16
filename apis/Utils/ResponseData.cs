namespace apis.Utils
{
    public class ResponseData<T>
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public ResponseData(int status200OK, Exception ex) { }

        public ResponseData(int status, string message, T? data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
