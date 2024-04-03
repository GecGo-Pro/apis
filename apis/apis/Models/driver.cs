using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace apis.Models
{
    public class driver
    {

        public int  id { get; set; }
        public string phone_number{ get; set; }
        public string name { get; set; }
        public string? address { get; set; }
        public string? current_address { get; set; }
        public string? avatar { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public int is_active { get; set; }
        public int status { get; set; }

        [NotMapped]
        public IFormFile? UploadImage { get; set; }

        public ICollection<dispatch_job>? dispatch_Jobs { get; set; }
        public ICollection<car>? cars { get; set; }
    }
}