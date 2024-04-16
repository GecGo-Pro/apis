using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace apis.Models
{
    public class Car
    {

        public int id {  get; set; }
        public required string number_plate { get; set; }
        public required string type{ get; set; }
        public string? note{ get; set; }
        public string? color{ get; set; }
        public int? deleted { get; set; } = 0;

        [ForeignKey("driver")]
        public required int driver_id{ get; set; }

        public ICollection<DispatchJob>? dispatch_jobs { get; set; }
        public Driver? driver { get; set; }

        public DateTime created_at { get; set; } = DateTime.UtcNow;
    }
}
