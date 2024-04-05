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
        public int? OTP { get; set; }

        public DateTime created_at { get; set; } = DateTime.UtcNow;

        public ICollection<Dispatch_job>? dispatch_Jobs { get; set; }


    }
}
