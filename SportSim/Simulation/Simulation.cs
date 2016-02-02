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
        int[] score = new int[2];
        int ball;
        int minutes;
        Random rand = new Random();

        public void reset()
        {
            score[0] = 0;
            score[1] = 0;
            teamA = null;
            teamB = null;
            ball = 0;
            minutes = 0;
        }

        public void New(int idA, int idB, int minutes)
        {
            teamA = Settings.FootballTeams.Get(idA);
            teamB = Settings.FootballTeams.Get(idB);
            this.minutes = minutes;
        }

        public void Calculation()
        {
            ball = Kickoff();
            for(int i = 1; i <= minutes; i++)
            {
                switch(ball)
                {
                    case 10:
                        ball = Turn(teamA.DefenseStrength, teamB.ForwardStrength);
                }
            }
        }

        private int Turn (int strength1, int strength2)
        {
            int random = rand.Next();
        }

        private int Kickoff()
        {
            int random = rand.Next(2);
            if (random == 0) return 12;
            if (random == 1) return 22;
            else return 0;
        }

        public Tuple<int, int> GetScore()
        {
            return Tuple.Create(score[0], score[1]);
        }
       
    }
}
