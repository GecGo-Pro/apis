using apis.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace apis.Models
{
    public class HttpException : Exception
    {
        public int StatusCode { get; set; }
        public string Detail { get; set; }
        public string Error {  get; set; }

        public HttpException(int statusCode, string detail) 
        {
            StatusCode = statusCode;
            Detail= detail;

            switch (StatusCode)
            {
                case 400:
                    Error = "Input Data Error!!"; break;
                case 401:
                    Error = "Authentication Error!!"; break;
                case 403:
                    Error = "Permission Denied!!"; break;
                case 404:
                    Error = "Not Found!!"; break;
                case 409:
                    Error = "Data Conflict!!"; break;
                case 500:
                    Error = "Server Error!!"; break;
                default:
                    Error = base.ToString(); break;
            }
        }
    }


}
