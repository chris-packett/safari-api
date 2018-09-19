using System;

namespace safari_api.Models 
{
    public class Animal 
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public int CountOfTimesSeen { get; set; } = 1;
        public string LocationOfLastSeen { get; set; }
        public DateTime LastSeenTime { get; set; } = DateTime.Now;
    }
}