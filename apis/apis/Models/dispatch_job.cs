using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace apis.Models
{
    public class dispatch_job
    {
        public int id { get; set; }
        public string start_longitude{ get; set; }
        public string start_latitude { get; set; }
        public string end_longitude { get; set; }
        public string end_latitude { get; set; }
        public string start_address { get; set; }
        public string end_address { get; set; }
        public int status { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public string? note { get; set; }
        public string? cancell_reason { get; set; }

        public int customer_id { get; set; }
        public int dispatcher_id { get; set; }
        public int? driver_id { get; set; }
        public int? car_id { get; set; }

        public DateTime created_at { get; set; } = DateTime.UtcNow;

        [NotMapped]
        public IFormFile? UploadImage { get; set; }


        public customer? customer { get; set; }
        public dispatcher? dispatcher { get; set; }
        public driver? driver { get; set; }
        public car? car { get; set; }
    }
}
