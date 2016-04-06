using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Simulation einer Fußballliga bzw. Turniergruppe
	/// </summary>
	public class FootballLeague
	{
		#region Constructor

		/// <summary>
		/// Erstellt eine neue Fußballliga
		/// </summary>
		public FootballLeague()
			: this(LeagueRoundMode.DoubleRound)
		{ }

		/// <summary>
		/// Erstellt eine neue Fußballliga
		/// </summary>
		/// <param name="roundMode">Rundenmodus der Liga</param>
		public FootballLeague(LeagueRoundMode roundMode)
			: this(roundMode, new FootballTeamCollection())
		{ }

		/// <summary>
		/// Erstellt eine neue Fußballliga
		/// </summary>
		/// <param name="teams">Teams der Liga</param>
		public FootballLeague(params FootballTeam[] teams)
			: this(LeagueRoundMode.DoubleRound, new FootballTeamCollection(teams))
		{ }

		/// <summary>
		/// Erstellt eine neue Fußballliga
		/// </summary>
		/// <param name="teams">Teams der Liga</param>
		public FootballLeague(List<FootballTeam> teams)
			: this(LeagueRoundMode.DoubleRound, new FootballTeamCollection(teams))
		{ }

		/// <summary>
		/// Erstellt eine neue Fußballliga
		/// </summary>
		/// <param name="teams">Teams der Liga</param>
		public FootballLeague(FootballTeamCollection teams)
			: this(LeagueRoundMode.DoubleRound, teams)
		{ }

		/// <summary>
		/// Erstellt eine neue Fußballliga
		/// </summary>
		/// <param name="roundMode">Rundenmodus der Liga</param>
		/// <param name="teams">Teams der Liga</param>
		public FootballLeague(LeagueRoundMode roundMode, params FootballTeam[] teams)
			: this(roundMode, new FootballTeamCollection(teams))
		{ }

		/// <summary>
		/// Erstellt eine neue Fußballliga
		/// </summary>
		/// <param name="roundMode">Rundenmodus der Liga</param>
		/// <param name="teams">Teams der Liga</param>
		public FootballLeague(LeagueRoundMode roundMode, List<FootballTeam> teams)
			: this(roundMode, new FootballTeamCollection(teams))
		{ }

		/// <summary>
		/// Erstellt eine neue Fußballliga
		/// </summary>
		/// <param name="roundMode">Rundenmodus der Liga</param>
		/// <param name="teams">Teams der Liga</param>
		public FootballLeague(LeagueRoundMode roundMode, FootballTeamCollection teams)
		{
			RoundMode = roundMode;
			Teams = teams;

			Matches = new ObservableCollection<FootballMatch>();
			CreateMatches();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Teams der Liga
		/// </summary>
		public FootballTeamCollection Teams { get; set; }

		/// <summary>
		/// Spiele der Liga
		/// </summary>
		public ObservableCollection<FootballMatch> Matches { get; set; }

		/// <summary>
		/// Rundenmodus
		/// </summary>
		public LeagueRoundMode RoundMode { get; set; }

		/// <summary>
		/// Anzahl der Teams
		/// </summary>
		public int TeamCount { get { return Teams.Count; } }

		#endregion

		#region Simulation

		/// <summary>
		/// Erstellt den Spielplan der Liga
		/// </summary>
		public void CreateMatches()
		{
			switch(RoundMode)
			{
				case LeagueRoundMode.SingleRound:
					int id = 0;
					for(int i = 0; i < Teams.Count; i++)
					{
						for(int j = i + 1; j < Teams.Count; j++)
						{
							Matches.Add(new FootballMatch(id++, Teams[i], Teams[j]));
						}
					}
					break;

				case LeagueRoundMode.DoubleRound:
					foreach(var teamA in Teams)
					{
						foreach(var teamB in Teams)
						{
							if(teamA != teamB)
								Matches.Add(new FootballMatch(Matches.Count, teamA, teamB));
						}
					}
					break;

				case LeagueRoundMode.QuadrupleRound:
					foreach(var teamA in Teams)
					{
						foreach(var teamB in Teams)
						{
							if(teamA != teamB)
								Matches.Add(new FootballMatch(Matches.Count, teamA, teamB));
						}
					}
					foreach(var teamA in Teams)
					{
						foreach(var teamB in Teams)
						{
							if(teamA != teamB)
								Matches.Add(new FootballMatch(Matches.Count, teamA, teamB));
						}
					}
					break;
			}
		}

		#endregion
	}
}
