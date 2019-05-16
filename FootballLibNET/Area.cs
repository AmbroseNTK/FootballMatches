using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLib
{
    public enum Area
    {
        Asia,
        Europe,
        Africa,
        NorthAmerica,
        SouthAmerica,
        Oceania
    }
    public class AreaUtil
    {
      
        public static Area GetAreaFromString(string areaName)
        {
            return (Area)(Enum.Parse(typeof(Area), areaName));
        }
        public static double GetRateFromArea(Area area)
        {
            switch (area)
            {
                case Area.Asia:
                    return 5.5d;
                case Area.Africa:
                    return 5d;
                case Area.Europe:
                    return 13d;
                case Area.NorthAmerica:
                    return 3.5d;
                case Area.SouthAmerica:
                    return 3.5d;
                case Area.Oceania:
                    return 0.5d;
            }
            return -1;
        }
    }
}
