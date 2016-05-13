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
		private int _Start;
		
		private FootballTeam _TeamA;
		private FootballTeam _TeamB;
		private int _ResultA;
		private int _ResultB;
		private DateTime _Date;

        private const int TORWART_A = 10;
        private const int TORWART_B = 20;
        private const int ABWEHR_A = 11;
        private const int ABWEHR_B = 21;
        private const int MITTELFELD_A = 12;
        private const int MITTELFELD_B = 22;
        private const int STURM_A = 13;
        private const int STURM_B = 23;
        private const int TOR_A = 14;
        private const int TOR_B = 24;

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

            Reset(90);

			_Ball = Kickoff();
			for(int i = 1; i <= _Minutes; i++)
			{
				if(i == 45)
				{
					if(_Ball == TOR_A)
						resA++;
					else if(_Ball == TOR_B)
						resB++;
					_Ball = _Start;
				}

				switch(_Ball)
				{
					case TORWART_A:
						_Ball = Turn(TeamA.GoalkeeperStrength, TeamB.ForwardStrength);
						break;
					case ABWEHR_A:
						_Ball = Turn(TeamA.DefenseStrength, TeamB.MidfieldStrength);
						break;
					case MITTELFELD_A:
						_Ball = Turn(TeamA.MidfieldStrength, TeamB.DefenseStrength);
						break;
					case STURM_A:
						_Ball = Turn(TeamA.ForwardStrength, TeamB.GoalkeeperStrength + TeamB.DefenseStrength / 2);
						break;
					case TOR_A:
						resA++;
						_Ball = MITTELFELD_B;
						break;
					case TORWART_B:
						_Ball = Turn(TeamB.GoalkeeperStrength, TeamA.ForwardStrength);
						break;
					case ABWEHR_B:
						_Ball = Turn(TeamB.DefenseStrength, TeamA.MidfieldStrength);
						break;
					case MITTELFELD_B:
						_Ball = Turn(TeamB.MidfieldStrength, TeamA.DefenseStrength);
						break;
					case STURM_B:
						_Ball = Turn(TeamB.ForwardStrength, TeamA.GoalkeeperStrength + TeamA.DefenseStrength / 2);
						break;
					case TOR_B:
						resB++;
						_Ball = MITTELFELD_A;
						break;
				}
			}

			ResultA = resA;
			ResultB = resB;
		}

		/// <summary>
		/// Setzt die Simulation und das Spielergebnis zurück
		/// </summary>
		private void Reset()
		{
			ResultA = 0;
			ResultB = 0;
			_Ball = 0;
			_Minutes = 0;
			_Start = 0;
		}

        private void Reset(int zeit)
        {
            Reset();
            _Minutes = zeit;
        }

		private int Turn(int strength1, int strength2)
		{
			int random = Settings.Random.Next(strength1 + strength2);
			if(random < strength1)
				return ++_Ball;
			else
				switch(_Ball)
				{
					case TORWART_A:
						return STURM_B;
					case ABWEHR_A:
						return MITTELFELD_B;
					case MITTELFELD_A:
						return ABWEHR_B;
					case STURM_A:
						return TORWART_B;
					case TORWART_B:
						return STURM_A;
					case ABWEHR_B:
						return MITTELFELD_A;
					case MITTELFELD_B:
						return ABWEHR_A;
					case STURM_B:
						return TORWART_A;
				}

			return 0;
		}

		private int Kickoff()
		{
			int random = Settings.Random.Next(2);
			if(random == 0)
			{ _Start = MITTELFELD_B; return MITTELFELD_A; }
			if(random == 1)
			{ _Start = MITTELFELD_A; return MITTELFELD_B; }
			else
				return 0;
		}

		#endregion

	}
}
