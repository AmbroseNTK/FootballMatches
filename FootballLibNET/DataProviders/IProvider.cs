using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLib.DataProviders
{
    public interface IProvider
    {
        List<Team> TeamProvide();
    }
}
