using System;
using System.Collections.Generic;

namespace receivePixel.Models
{
    public class Pixel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public IDictionary<string, string> Headers { get; set; }
        public string QueryString { get; set; }
        public IDictionary<string, string> Query { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}