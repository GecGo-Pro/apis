namespace apis.Models
{
    public class customer
    {
        public int id { get; set; }
        public string phone_number { get; set; }
        public string name { get; set; }
        public string? avatar { get; set; } 
        public string longitude { get; set; }
        public string latitude { get; set; }
        public int? OTP { get; set; }

        public DateTime created_at { get; set; } = DateTime.UtcNow;

        public ICollection<dispatch_job>? dispatch_Jobs { get; set; }


    }
}
