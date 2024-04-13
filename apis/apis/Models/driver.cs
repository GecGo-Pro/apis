using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace apis.Models
{
    public class Driver
    {

        public int  id { get; set; }
        public required string phone_number{ get; set; }
        public required string name { get; set; }
        public required string password { get; set; }
        public required string? address { get; set; }
        public string? current_address { get; set; }
        public string? avatar { get; set; }
        public required string longitude { get; set; }
        public required string latitude { get; set; }
        public int is_active { get; set; }
        public int status { get; set; }
        public int? deleted { get; set; } = 0;

        public DateTime created_at { get; set; } = DateTime.UtcNow;

        [NotMapped]
        public IFormFile? upload_image { get; set; }

        public ICollection<DispatchJob>? dispatch_jobs { get; set; }
        public ICollection<Car>? cars { get; set; }
    }
}