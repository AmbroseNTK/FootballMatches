using System;

namespace FootballLib
{
    public class Match
    {
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public DateTime Date { get; set; }
        public Location Location { get; set; }
        public string Tag { get; set; }
        
    }
}