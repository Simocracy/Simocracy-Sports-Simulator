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
        int start;

        public void reset()
        {
            score[0] = 0;
            score[1] = 0;
            teamA = null;
            teamB = null;
            ball = 0;
            minutes = 0;
            start = 0;
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
                if (i == 45)
                {
                    if (ball == 14) score[0]++;
                    if (ball == 24) score[1]++;
                    ball = start;
                }

                switch(ball)
                {
                    case 10:
                        ball = Turn(teamA.GoalkeeperStrength, teamB.ForwardStrength);
                        break;
                    case 11:
                        ball = Turn(teamA.DefenseStrength, teamB.MidfieldStrength);
                        break;
                    case 12:
                        ball = Turn(teamA.MidfieldStrength, teamB.DefenseStrength);
                        break;
                    case 13:
                        ball = Turn(teamA.DefenseStrength, teamB.GoalkeeperStrength + teamB.DefenseStrength/2);
                        break;
                    case 14:
                        score[0]++;
                        ball = 22;
                        break;
                    case 20:
                        ball = Turn(teamB.GoalkeeperStrength, teamA.ForwardStrength);
                        break;
                    case 21:
                        ball = Turn(teamB.DefenseStrength, teamA.MidfieldStrength);
                        break;
                    case 22:
                        ball = Turn(teamB.MidfieldStrength, teamA.DefenseStrength);
                        break;
                    case 23:
                        ball = Turn(teamB.DefenseStrength, teamA.GoalkeeperStrength + teamA.DefenseStrength / 2);
                        break;
                    case 24:
                        score[1]++;
                        ball = 12;
                        break;
                }
            }
        }

        private int Turn (int strength1, int strength2)
        {
            int random = rand.Next(strength1 + strength2);
            if (random < strength1) ball++;
            else switch (ball)
                {
                    case 10:
                        return 23;
                    case 11:
                        return 22;
                    case 12:
                        return 21;
                    case 13:
                        return 20;
                    case 20:
                        return 13;
                    case 21:
                        return 12;
                    case 22:
                        return 11;
                    case 23:
                        return 10;
                }
        }

        private int Kickoff()
        {
            int random = rand.Next(2);
            if (random == 0) { start = 22; return 12; }
            if (random == 1) { start = 12; return 22; }
            else return 0;
        }

        public Tuple<int, int> GetScore()
        {
            return Tuple.Create(score[0], score[1]);
        }
       
    }
}
