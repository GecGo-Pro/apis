using System.ComponentModel.DataAnnotations.Schema;

namespace apis.Models
{
    public class Customer
    {
        public int id { get; set; }
        public required string phone_number { get; set; }
        public required string name { get; set; }
        public string? avatar { get; set; }
        public required string longitude { get; set; }
        public required string latitude { get; set; }
        public int? otp { get; set; }
        public int? deleted { get; set; } = 0;
        public DateTime otp_life { get; set; }
        public DateTime created_at { get; set; } = DateTime.UtcNow;

        [NotMapped]
        public IFormFile? upload_image { get; set; }

        public ICollection<DispatchJob>? dispatch_Jobs { get; set; }


    }
}
