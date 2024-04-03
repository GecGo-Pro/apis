using System.ComponentModel.DataAnnotations.Schema;

namespace apis.Models
{
    public class dispatcher
    {
        public int id { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string? avatar { get; set; }
        public string password { get; set; }

        [NotMapped]
        public IFormFile? UploadImage { get; set; }

        public ICollection<dispatch_job>? dispatch_jobs { get; set; }
    }
}
