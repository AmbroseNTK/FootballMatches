using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLib.Rounds
{
    public class PreRound : Round
    {
        public override List<Team> Play()
        {
            Random rand = new Random();
            List<Team> result = new List<Team>();
            Array arr = Enum.GetValues(typeof(Area));
            foreach(Area area in arr)
            {
                List<Team> countryInContinent = InputTeams.Where((team) => team.Area == area).ToList();
                bool isFloor = rand.Next(0, 1) == 0 ? true : false;
                double rate = AreaUtil.GetRateFromArea(area);
                int max = 0;
                if (isFloor)
                {
                    max = Convert.ToInt32(Math.Round((decimal)rate,1));
                }
                else
                {
                    max = (int)rate;
                }
                while (max > 0 && result.Count<32 && countryInContinent.Count>0)
                {
                    int selectionId = rand.Next(0, countryInContinent.Count-1);
                    result.Add(countryInContinent[selectionId]);
                    countryInContinent.RemoveAt(selectionId);
                    max--;
                }
            }
            return result;
        }
    }
}
