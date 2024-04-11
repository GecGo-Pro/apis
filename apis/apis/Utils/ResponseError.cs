namespace apis.Utils
{
    public class ResponseError<T>
    {
        public int Status { get; set; }
        public string? Error { get; set; }
        public string? Detail { get; set; }
        public ResponseError(int status400BadRequest, Exception ex) { }

        public ResponseError(int status, string error, string detail)
        {
            Status = status;
            Error = error;
            Detail = detail;
        }
    }
}
