using System.ComponentModel.DataAnnotations.Schema;

namespace apis.Models
{
    public class Dispatcher
    {
        public int id { get; set; }
        public required string phone_number { get; set; }
        public required string email { get; set; }
        public required string name { get; set; }
        public string? avatar { get; set; }
        public int? OTP { get; set; }

        public DateTime created_at { get; set; }= DateTime.UtcNow;

        [NotMapped]
        public IFormFile? upload_image { get; set; }

        public ICollection<Dispatch_job>? dispatch_jobs { get; set; }
    }
}
