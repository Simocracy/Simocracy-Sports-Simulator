using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{

	/// <summary>
	/// Fußballspiel
	/// </summary>
	[DebuggerDisplay("Match {ID}: {TeamA.Name} - {TeamB.Name}")]
	public class FootballMatch : SSSDataObject, INotifyPropertyChanged
	{
		#region Members

		private int _Ball;
		private int _Minutes;
		private Random _Rand;
		private int _Start;
		
		private FootballTeam _TeamA;
		private FootballTeam _TeamB;
		private int _ResultA;
		private int _ResultB;
		private DateTime _Date;

		#endregion

		#region Constructors

		/// <summary>
		/// Initiiert ein neues Fußballspiel
		/// </summary>
		/// <param name="matchID">ID des Spiels</param>
		/// <param name="idA">ID des Heimteams</param>
		/// <param name="idB">ID des Auswärtsteams</param>
		public FootballMatch(int matchID, int idA, int idB)
			: this(matchID, Settings.FootballTeams.Get(idA), Settings.FootballTeams.Get(idB))
		{ }

		/// <summary>
		/// Initiiert ein neues Fußballspiel
		/// </summary>
		/// <param name="matchID">ID des Spiels</param>
		/// <param name="idA">ID des Heimteams</param>
		/// <param name="idB">ID des Auswärtsteams</param>
		/// <param name="date">Spieldatum</param>
		public FootballMatch(int matchID, int idA, int idB, DateTime date)
			: this(matchID, Settings.FootballTeams.Get(idA), Settings.FootballTeams.Get(idB), date)
		{ }

		/// <summary>
		/// Initiiert ein neues Fußballspiel
		/// </summary>
		/// <param name="matchID">ID des Spiels</param>
		/// <param name="idA">ID des Heimteams</param>
		/// <param name="idB">ID des Auswärtsteams</param>
		/// <param name="minutes">Anzahl Spielminuten</param>
		public FootballMatch(int matchID, int idA, int idB, int minutes)
			: this(matchID, Settings.FootballTeams.Get(idA), Settings.FootballTeams.Get(idB), minutes)
		{ }

		/// <summary>
		/// Initiiert ein neues Fußballspiel
		/// </summary>
		/// <param name="matchID">ID des Spiels</param>
		/// <param name="idA">ID des Heimteams</param>
		/// <param name="idB">ID des Auswärtsteams</param>
		/// <param name="date">Spieldatum</param>
		/// <param name="minutes">Anzahl Spielminuten</param>
		public FootballMatch(int matchID, int idA, int idB, DateTime date, int minutes)
			: this(matchID, Settings.FootballTeams.Get(idA), Settings.FootballTeams.Get(idB), date, minutes)
		{ }

		/// <summary>
		/// Initiiert ein neues Fußballspiel
		/// </summary>
		/// <param name="matchID">ID des Spiels</param>
		/// <param name="teamA">Heimteam</param>
		/// <param name="teamB">Auswärtsteam</param>
		public FootballMatch(int matchID, FootballTeam teamA, FootballTeam teamB)
			: this(matchID, teamA, teamB, 90)
		{ }

		/// <summary>
		/// Initiiert ein neues Fußballspiel
		/// </summary>
		/// <param name="matchID">ID des Spiels</param>
		/// <param name="teamA">Heimteam</param>
		/// <param name="teamB">Auswärtsteam</param>
		/// <param name="date">Spieldatum</param>
		public FootballMatch(int matchID, FootballTeam teamA, FootballTeam teamB, DateTime date)
			: this(matchID, teamA, teamB, date, 90)
		{ }

		/// <summary>
		/// Initiiert ein neues Fußballspiel
		/// </summary>
		/// <param name="matchID">ID des Spiels</param>
		/// <param name="teamA">Heimteam</param>
		/// <param name="teamB">Auswärtsteam</param>
		/// <param name="minutes">Anzahl Spielminuten</param>
		public FootballMatch(int matchID, FootballTeam teamA, FootballTeam teamB, int minutes)
			: this(matchID, teamA, teamB, Datumsrechner.Now, minutes)
		{ }

		/// <summary>
		/// Initiiert ein neues Fußballspiel
		/// </summary>
		/// <param name="matchID">ID des Spiels</param>
		/// <param name="teamA">Heimteam</param>
		/// <param name="teamB">Auswärtsteam</param>
		/// <param name="date">Spieldatum</param>
		/// <param name="minutes">Anzahl Spielminuten</param>
		public FootballMatch(int matchID, FootballTeam teamA, FootballTeam teamB, DateTime date, int minutes)
			:base (matchID, String.Format("{0}-{1}", teamA.Name, teamB.Name))
		{
			TeamA = teamA;
			TeamB = teamB;
			_Minutes = minutes;
			Date = date;

			Reset();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Heimteam
		/// </summary>
		public FootballTeam TeamA
		{
			get { return _TeamA; }
			set
			{
				_TeamA = value;
				Notify("TeamA");
			}
		}

		/// <summary>
		/// Auswärtsteam
		/// </summary>
		public FootballTeam TeamB
		{
			get { return _TeamB; }
			set
			{
				_TeamB = value;
				Notify("TeamB");
			}
		}

		/// <summary>
		/// Tore Heimteam
		/// </summary>
		public int ResultA
		{
			get { return _ResultA; }
			set
			{
				_ResultA = value;
				Notify("ResultA");
			}
		}

		/// <summary>
		/// Tore Auswärtsteam
		/// </summary>
		public int ResultB
		{
			get { return _ResultB; }
			set
			{
				_ResultB = value;
				Notify("ResultB");
			}
		}

		/// <summary>
		/// Spieldatum
		/// </summary>
		public DateTime Date
		{
			get { return _Date; }
			set
			{
				_Date = value;
				Notify("Date");
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Tauscht die beiden Teams
		/// </summary>
		public void SwapTeams()
		{
			var oldTeamA = TeamA;
			var oldResultA = ResultA;
			TeamA = TeamB;
			ResultA = ResultB;
			TeamB = oldTeamA;
			ResultB = oldResultA;
			Name = String.Format("{0}-{1}", TeamA, TeamB);
		}

		/// <summary>
		/// Gibt einen <see cref="String"/> zurück, der das Objekt darstellt.
		/// </summary>
		/// <returns>Objekt als String</returns>
		public override string ToString()
		{
			return String.Format("{0}, TeamA={1}, TeamB={2}, ResultA={3}, ResultB={4}, Date={5}",
				base.ToString(), TeamA, TeamB, ResultA, ResultB, Date.ToShortDateString());
		}

		#endregion

		#region Simulation

		/// <summary>
		/// Simuliert ein Fußballspiel
		/// </summary>
		public void Simulate()
		{
			SimpleLog.Info(String.Format("Simulate Match: TeamA={0}, TeamB={1}", TeamA, TeamB));

			int resA = 0;
			int resB = 0;

			_Ball = Kickoff();
			for(int i = 1; i <= _Minutes; i++)
			{
				if(i == 45)
				{
					if(_Ball == 14)
						resA++;
					if(_Ball == 24)
						resB++;
					_Ball = _Start;
				}

				switch(_Ball)
				{
					case 10:
						_Ball = Turn(TeamA.GoalkeeperStrength, TeamB.ForwardStrength);
						break;
					case 11:
						_Ball = Turn(TeamA.DefenseStrength, TeamB.MidfieldStrength);
						break;
					case 12:
						_Ball = Turn(TeamA.MidfieldStrength, TeamB.DefenseStrength);
						break;
					case 13:
						_Ball = Turn(TeamA.ForwardStrength, TeamB.GoalkeeperStrength + TeamB.DefenseStrength / 2);
						break;
					case 14:
						resA++;
						_Ball = 22;
						break;
					case 20:
						_Ball = Turn(TeamB.GoalkeeperStrength, TeamA.ForwardStrength);
						break;
					case 21:
						_Ball = Turn(TeamB.DefenseStrength, TeamA.MidfieldStrength);
						break;
					case 22:
						_Ball = Turn(TeamB.MidfieldStrength, TeamA.DefenseStrength);
						break;
					case 23:
						_Ball = Turn(TeamB.ForwardStrength, TeamA.GoalkeeperStrength + TeamA.DefenseStrength / 2);
						break;
					case 24:
						resB++;
						_Ball = 12;
						break;
				}
			}

			ResultA = resA;
			ResultB = resB;
		}

		/// <summary>
		/// Setzt die Simulation und das Spielergebnis zurück
		/// </summary>
		public void Reset()
		{
			ResultA = 0;
			ResultB = 0;
			_Rand = new Random();
			_Ball = 0;
			_Minutes = 0;
			_Start = 0;
		}

		private int Turn(int strength1, int strength2)
		{
			int random = _Rand.Next(strength1 + strength2);
			if(random < strength1)
				_Ball++;
			else
				switch(_Ball)
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

			return 0;
		}

		private int Kickoff()
		{
			int random = _Rand.Next(2);
			if(random == 0)
			{ _Start = 22; return 12; }
			if(random == 1)
			{ _Start = 12; return 22; }
			else
				return 0;
		}

		#endregion

	}
}
