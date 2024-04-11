﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace apis.Models
{
    public class Dispatcher
    {
        public int id { get; set; }
        public required string phone_number { get; set; }
        public string? email { get; set; }
        public required string name { get; set; }
        public string? avatar { get; set; }
        public int? otp { get; set; }
        [AllowNull]
        public DateTime created_at { get; set; }= DateTime.UtcNow;

        [NotMapped]
        public IFormFile? upload_image { get; set; }
        [AllowNull]
        public ICollection<DispatchJob>? dispatch_jobs { get; set; }
    }
}
