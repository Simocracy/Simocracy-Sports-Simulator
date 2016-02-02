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

        FootballTeam teamA, teamB;

        public void New(int idA, int idB)
        {
            teamA = Settings.FootballTeams.Get(idA);
            teamB = Settings.FootballTeams.Get(idB);
        }
       
    }
}
