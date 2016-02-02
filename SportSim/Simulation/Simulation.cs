using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Simocracy.SportSim
{
    /// <summary>
    /// Simulation
    /// </summary>
    
    public class Simulation
    {

        var teamA, teamB;

        public New(int idA, int idB)
        {
            teamA = Settings.FootballTeams.get(idA);
            teamB = Settings.FootballTeams.get(idB);
        }
       
    }
}
