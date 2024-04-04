using System.Drawing;

namespace apis.Models
{
    public class car
    {

        public int id {  get; set; }
        public string number_plate{  get; set; }
        public string type{ get; set; }
        public string note{ get; set; }
        public string color{ get; set; }

        public int driver_id{ get; set; }

        public ICollection<dispatch_job>? dispatch_Jobs { get; set; }
        public driver? driver { get; set; }

        public DateTime created_at { get; set; } = DateTime.UtcNow;
    }
}
