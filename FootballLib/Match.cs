using System;

namespace FootballLib
{
    public class Match
    {
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public DateTime date { get; set; }
        public Location location { get; set; }
    }
}