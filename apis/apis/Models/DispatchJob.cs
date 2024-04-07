using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace apis.Models
{
    public class DispatchJob
    {
        public int id { get; set; }
        public required string start_longitude{ get; set; }
        public required string start_latitude { get; set; }
        public required string end_longitude { get; set; }
        public required string end_latitude { get; set; }
        public required string start_address { get; set; }
        public required string end_address { get; set; }
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


        public Customer? customer { get; set; }
        public Dispatcher? dispatcher { get; set; }
        public Driver? driver { get; set; }
        public Car? car { get; set; }
    }
}
