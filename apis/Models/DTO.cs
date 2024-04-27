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
    public class OptionsAsDesiredByPhone
    {
        public int? limit { get; set; }
        public int? page { get; set; }
        public string? sort_by { get; set; }
    }

    public class CustomerDTO
    {
        public int id { get; set; }
        public required string phone_number { get; set; }
        public required string name { get; set; }
        public string? avatar { get; set; }
        public required string longitude { get; set; }
        public required string latitude { get; set; }
        public DateTime created_at { get; set; } = DateTime.UtcNow;


        public ICollection<DispatchJob>? dispatch_jobs { get; set; }

        public int? page { get; set; }
        public int? limit { get; set; }
        public string? sort { get; set; }

        public CustomerDTO(int id, string phone_number, string name, string? avatar, string longitude, string latitude, DateTime created_at, ICollection<DispatchJob>? dispatch_jobs, int? page, int? limit, string? sort)
        {
            this.id = id;
            this.phone_number = phone_number;
            this.name = name;
            this.avatar = avatar;
            this.longitude = longitude;
            this.latitude = latitude;
            this.created_at = created_at;
            this.dispatch_jobs = dispatch_jobs;
            this.page = page;
            this.limit = limit;
            this.sort = sort;
        }

        public CustomerDTO()
        {
        }
    }
}
