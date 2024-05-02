using System.ComponentModel.DataAnnotations.Schema;

namespace apis.Models
{
    public class LoginDTO
    {
        public required string Phone { get; set; }
    }

    public class VerifyOtpDTO
    {
        public required string Phone { get; set; }
        public required string Otp { get; set; }
    }
    public class VerifyPasswordDTO
    {
        public required string Phone { get; set; }
        public required string Password { get; set; }
    }
    public class DispatcherDTO
    {
        public required string phone_number { get; set; }
        public string? email { get; set; }
        public required string name { get; set; }
        [NotMapped]
        public IFormFile? upload_image { get; set; }

    }
    public class DriverDTO
    {
        public required string phone_number { get; set; }
        public required string name { get; set; }
        public required string password { get; set; }
        public required string address { get; set; }
        public string? current_address { get; set; }
        public required string longitude { get; set; }
        public required string latitude { get; set; }

        [NotMapped]
        public IFormFile? upload_image { get; set; }

    }

    public  class DispatchJobDTO{
        public required string start_longitude{ get; set; }
        public required string start_latitude { get; set; }
        public required string end_longitude { get; set; }
        public required string end_latitude { get; set; }
        public required string start_address { get; set; }
        public required string end_address { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public string? note { get; set; }
        public string? cancell_reason { get; set; }

        public int customer_id { get; set; } =0;
        public int dispatcher_id { get; set;} =0;
        public int? driver_id { get; set; } =0;
        public int? car_id { get; set; } =0;

    }
}
