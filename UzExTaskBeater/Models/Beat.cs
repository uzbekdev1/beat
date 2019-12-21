using System;

namespace UzExTaskBeater.Models
{
    public class Beat
    {
        public string Id { get; set; }
        public string BeaterId { get; set; }
        public decimal Price { get; set; }
        public DateTime BeatTime { get; set; }
    }
}