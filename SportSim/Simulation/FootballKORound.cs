using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{
	/// <summary>
	/// KO-Runde für Fußballturniere.
	/// </summary>
	public class FootballKORound : SSSDataObject
	{

		#region Members

		private FootballTeamCollection _OriginalTeams;
		private FootballTeamCollection _CurrentTeams;
		private EKORoundMode _RoundMode;
		private EKORound _CurrentRound;
		private ObservableCollection<FootballMatch> _Matches128;
		private ObservableCollection<FootballMatch> _Matches64;
		private ObservableCollection<FootballMatch> _Matches32;
		private ObservableCollection<FootballMatch> _Matches16;
		private ObservableCollection<FootballMatch> _MatchesQuarterFinal;
		private ObservableCollection<FootballMatch> _MatchesSemiFinal;
		private ObservableCollection<FootballMatch> _MatchesFinal;

		#endregion

		#region Constructor

		/// <summary>
		/// Erstellt eine neue KO-Runde für Fußballspiele
		/// </summary>
		public FootballKORound()
			: this(EKORoundMode.OneMatch)
		{ }

		/// <summary>
		/// Erstellt eine neue KO-Runde für Fußballspiele
		/// </summary>
		/// <param name="roundMode">Rundenmodus der KO-Runde</param>
		public FootballKORound(EKORoundMode roundMode)
			: this(roundMode, new FootballTeamCollection())
		{ }

		/// <summary>
		/// Erstellt eine neue KO-Runde für Fußballspiele
		/// </summary>
		/// <param name="teams">Teams der KO-Runde. Zwei direkt aufeinanderfolgende Teams spielen gegeneinander.</param>
		public FootballKORound(params FootballTeam[] teams)
			: this(EKORoundMode.OneMatch, new FootballTeamCollection(teams))
		{ }

		/// <summary>
		/// Erstellt eine neue KO-Runde für Fußballspiele
		/// </summary>
		/// <param name="teams">Teams der KO-Runde. Zwei direkt aufeinanderfolgende Teams spielen gegeneinander.</param>
		public FootballKORound(List<FootballTeam> teams)
			: this(EKORoundMode.OneMatch, new FootballTeamCollection(teams))
		{ }

		/// <summary>
		/// Erstellt eine neue KO-Runde für Fußballspiele
		/// </summary>
		/// <param name="teams">Teams der KO-Runde. Zwei direkt aufeinanderfolgende Teams spielen gegeneinander.</param>
		public FootballKORound(FootballTeamCollection teams)
			: this(EKORoundMode.OneMatch, teams)
		{ }

		/// <summary>
		/// Erstellt eine neue KO-Runde für Fußballspiele
		/// </summary>
		/// <param name="roundMode">Rundenmodus der KO-Runde</param>
		/// <param name="teams">Teams der KO-Runde. Zwei direkt aufeinanderfolgende Teams spielen gegeneinander.</param>
		public FootballKORound(EKORoundMode roundMode, params FootballTeam[] teams)
			: this(roundMode, new FootballTeamCollection(teams))
		{ }

		/// <summary>
		/// Erstellt eine neue KO-Runde für Fußballspiele
		/// </summary>
		/// <param name="roundMode">Rundenmodus der KO-Runde</param>
		/// <param name="teams">Teams der KO-Runde. Zwei direkt aufeinanderfolgende Teams spielen gegeneinander.</param>
		public FootballKORound(EKORoundMode roundMode, List<FootballTeam> teams)
			: this(roundMode, new FootballTeamCollection(teams))
		{ }

		/// <summary>
		/// Erstellt eine neue KO-Runde für Fußballspiele
		/// </summary>
		/// <param name="roundMode">Rundenmodus der KO-Runde</param>
		/// <param name="teams">Teams der KO-Runde. Zwei direkt aufeinanderfolgende Teams spielen gegeneinander.</param>
		public FootballKORound(EKORoundMode roundMode, FootballTeamCollection teams)
			: this(new Guid().GetHashCode(), String.Empty, roundMode, teams)
		{ }

		/// <summary>
		/// Erstellt eine neue KO-Runde für Fußballspiele
		/// </summary>
		/// <param name="id">ID der KO-Runde</param>
		/// <param name="name">Name der KO-Runde</param>
		/// <param name="roundMode">Rundenmodus der KO-Runde</param>
		/// <param name="teams">Teams der KO-Runde. Zwei direkt aufeinanderfolgende Teams spielen gegeneinander.</param>
		public FootballKORound(int id, string name, EKORoundMode roundMode, FootballTeamCollection teams)
			: base(id, name)
		{
			RoundMode = roundMode;
			OriginalTeams = teams;
			

			SimpleLog.Log(String.Format("Create Football KO Round: {0}", ToString()));

			Reset();

			//Matches = new ObservableCollection<FootballMatch>();
			//CreateMatches();
			//CreateTable();

			SimpleLog.Log(String.Format("Football KO Round created with ID={0}", ID));
		}

		#endregion

		#region Properties

		/// <summary>
		/// Zufallsgenerator
		/// </summary>
		private Random Randomizer { get; set; }

		/// <summary>
		/// Teams in der 1. Runde
		/// </summary>
		public FootballTeamCollection OriginalTeams
		{
			get { return _OriginalTeams; }
			set { _OriginalTeams = value; Notify(); }
		}

		/// <summary>
		/// Teams der aktuellen Runde
		/// </summary>
		public FootballTeamCollection CurrentTeams
		{
			get { return _CurrentTeams; }
			private set { _CurrentTeams = value; Notify(); }
		}

		/// <summary>
		/// Spiele in der Runde der 128
		/// </summary>
		public ObservableCollection<FootballMatch> Matches128
		{
			get { return _Matches128; }
			private set { _Matches128 = value; Notify(); }
		}

		/// <summary>
		/// Spiele in der Runde der 64
		/// </summary>
		public ObservableCollection<FootballMatch> Matches64
		{
			get { return _Matches64; }
			private set { _Matches64 = value; Notify(); }
		}

		/// <summary>
		/// Spiele in der Runde der 32
		/// </summary>
		public ObservableCollection<FootballMatch> Matches32
		{
			get { return _Matches32; }
			private set { _Matches32 = value; Notify(); }
		}

		/// <summary>
		/// Spiele in der Runde der 16
		/// </summary>
		public ObservableCollection<FootballMatch> Matches16
		{
			get { return _Matches16; }
			private set { _Matches16 = value; Notify(); }
		}

		/// <summary>
		/// Spiele im Viertelfinale
		/// </summary>
		public ObservableCollection<FootballMatch> MatchesQuarterFinal
		{
			get { return _MatchesQuarterFinal; }
			private set { _MatchesQuarterFinal = value; Notify(); }
		}

		/// <summary>
		/// Spiele im Halbfinale
		/// </summary>
		public ObservableCollection<FootballMatch> MatchesSemiFinal
		{
			get { return _MatchesSemiFinal; }
			private set { _MatchesSemiFinal = value; Notify(); }
		}

		/// <summary>
		/// Spiele im Finale
		/// </summary>
		public ObservableCollection<FootballMatch> MatchesFinal
		{
			get { return _MatchesFinal; }
			private set { _MatchesFinal = value; Notify(); }
		}

		/// <summary>
		/// Erste Runde
		/// </summary>
		public EKORound StartRound
		{
			get
			{
				switch(OriginalTeamsCount)
				{
					case 128:
						return EKORound.RoundOf128;
					case 64:
						return EKORound.RoundOf64;
					case 32:
						return EKORound.RoundOf32;
					case 16:
						return EKORound.RoundOf16;
					case 8:
						return EKORound.QuarterFinal;
					case 4:
						return EKORound.SemiFinal;
					case 2:
						return EKORound.Final;
					default:
						return EKORound.Unknown;
				}
			}
		}

		/// <summary>
		/// Aktuelle Runde
		/// </summary>
		public EKORound CurrentRound
		{
			get
			{
				switch(CurrentTeamsCount)
				{
					case 128:
						return EKORound.RoundOf128;
					case 64:
						return EKORound.RoundOf64;
					case 32:
						return EKORound.RoundOf32;
					case 16:
						return EKORound.RoundOf16;
					case 8:
						return EKORound.QuarterFinal;
					case 4:
						return EKORound.SemiFinal;
					case 2:
						return EKORound.Final;
					default:
						return EKORound.Unknown;
				}
			}
		}

		/// <summary>
		/// Anzahl der Spiele
		/// </summary>
		public EKORoundMode RoundMode
		{
			get { return _RoundMode; }
			set { _RoundMode = value; Notify(); }
		}

		/// <summary>
		/// Anzahl der Teams der 1. Runde
		/// </summary>
		public int OriginalTeamsCount { get { return OriginalTeams.Count; } }

		/// <summary>
		/// Anzahl der Teams der aktuellen Runde
		/// </summary>
		public int CurrentTeamsCount { get { return CurrentTeams.Count; } }

		#endregion

		#region Methods

		/// <summary>
		/// Setzt die KO-Runde zurück
		/// </summary>
		public void Reset()
		{
			CurrentTeams = new FootballTeamCollection(OriginalTeams);
			Matches128 = new ObservableCollection<FootballMatch>();
			Matches64 = new ObservableCollection<FootballMatch>();
			Matches32 = new ObservableCollection<FootballMatch>();
			Matches16 = new ObservableCollection<FootballMatch>();
			MatchesQuarterFinal = new ObservableCollection<FootballMatch>();
			MatchesSemiFinal = new ObservableCollection<FootballMatch>();
			MatchesFinal = new ObservableCollection<FootballMatch>();
			Randomizer = new Random();
		}

		/// <summary>
		/// Lost die aktuelle Runde ohne Einschränkungen aus.
		/// </summary>
		public void Draw()
		{
			CurrentTeams.OrderBy(x => Randomizer.Next());
		}

		/// <summary>
		/// Erstellt die Runde der letzten 128 Mannschaften. Die jeweils aufeinanderfolgenden Teams in <see cref="CurrentTeams"/> spielen gegeneinander.
		/// </summary>
		public void CreateRoundOf128()
		{

		}

		/// <summary>
		/// Erstellt die Runde der letzten 64  Mannschaften. Die jeweils aufeinanderfolgenden Teams in <see cref="CurrentTeams"/> spielen gegeneinander.
		/// </summary>
		public void CreateRoundOf64()
		{

		}

		/// <summary>
		/// Erstellt die Runde der letzten 32 Mannschaften. Die jeweils aufeinanderfolgenden Teams in <see cref="CurrentTeams"/> spielen gegeneinander.
		/// </summary>
		public void CreateRoundOf32()
		{

		}

		/// <summary>
		/// Erstellt das Achtelfinale. Die jeweils aufeinanderfolgenden Teams in <see cref="CurrentTeams"/> spielen gegeneinander.
		/// </summary>
		public void CreateRoundOf16()
		{

		}

		/// <summary>
		/// Erstellt das Viertelfinale. Die jeweils aufeinanderfolgenden Teams in <see cref="CurrentTeams"/> spielen gegeneinander.
		/// </summary>
		public void CreateQuarterFinal()
		{

		}

		/// <summary>
		/// Erstellt das Halbfinale. Die jeweils aufeinanderfolgenden Teams in <see cref="CurrentTeams"/> spielen gegeneinander.
		/// </summary>
		public void CreateSemiFinal()
		{

		}

		/// <summary>
		/// Erstellt das Finale. Die jeweils aufeinanderfolgenden Teams in <see cref="CurrentTeams"/> spielen gegeneinander.
		/// </summary>
		public void CreateFinal()
		{

		}

		/// <summary>
		/// Gibt einen <see cref="String"/> zurück, der das Objekt darstellt.
		/// </summary>
		/// <returns>Objekt als String</returns>
		public override string ToString()
		{
			return String.Format("{0}, TeamCount={1}, RoundMode={2}", base.ToString(), OriginalTeamsCount, RoundMode);
		}

		#endregion

	}
}
