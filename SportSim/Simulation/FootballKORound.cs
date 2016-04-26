using System;
using System.Collections.Generic;
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

		private FootballTeamCollection _Teams;
		private EKORoundMode _RoundMode;

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
		/// <param name="teams">Teams der KO-Runde</param>
		public FootballKORound(params FootballTeam[] teams)
			: this(EKORoundMode.OneMatch, new FootballTeamCollection(teams))
		{ }

		/// <summary>
		/// Erstellt eine neue KO-Runde für Fußballspiele
		/// </summary>
		/// <param name="teams">Teams der KO-Runde</param>
		public FootballKORound(List<FootballTeam> teams)
			: this(EKORoundMode.OneMatch, new FootballTeamCollection(teams))
		{ }

		/// <summary>
		/// Erstellt eine neue KO-Runde für Fußballspiele
		/// </summary>
		/// <param name="teams">Teams der KO-Runde</param>
		public FootballKORound(FootballTeamCollection teams)
			: this(EKORoundMode.OneMatch, teams)
		{ }

		/// <summary>
		/// Erstellt eine neue KO-Runde für Fußballspiele
		/// </summary>
		/// <param name="roundMode">Rundenmodus der KO-Runde</param>
		/// <param name="teams">Teams der KO-Runde</param>
		public FootballKORound(EKORoundMode roundMode, params FootballTeam[] teams)
			: this(roundMode, new FootballTeamCollection(teams))
		{ }

		/// <summary>
		/// Erstellt eine neue KO-Runde für Fußballspiele
		/// </summary>
		/// <param name="roundMode">Rundenmodus der KO-Runde</param>
		/// <param name="teams">Teams der KO-Runde</param>
		public FootballKORound(EKORoundMode roundMode, List<FootballTeam> teams)
			: this(roundMode, new FootballTeamCollection(teams))
		{ }

		/// <summary>
		/// Erstellt eine neue KO-Runde für Fußballspiele
		/// </summary>
		/// <param name="roundMode">Rundenmodus der KO-Runde</param>
		/// <param name="teams">Teams der KO-Runde</param>
		public FootballKORound(EKORoundMode roundMode, FootballTeamCollection teams)
			: this(new Guid().GetHashCode(), String.Empty, roundMode, teams)
		{ }

		/// <summary>
		/// Erstellt eine neue KO-Runde für Fußballspiele
		/// </summary>
		/// <param name="id">ID der KO-Runde</param>
		/// <param name="name">Name der KO-Runde</param>
		/// <param name="roundMode">Rundenmodus der KO-Runde</param>
		/// <param name="teams">Teams der KO-Runde</param>
		public FootballKORound(int id, string name, EKORoundMode roundMode, FootballTeamCollection teams)
			: base(id, name)
		{
			RoundMode = roundMode;
			Teams = teams;

			SimpleLog.Log(String.Format("Create Football KO Round: {0}", ToString()));

			//Matches = new ObservableCollection<FootballMatch>();
			//CreateMatches();
			//CreateTable();

			SimpleLog.Log(String.Format("Football KO Round created with ID={0}", ID));
		}

		#endregion

		#region Properties

		/// <summary>
		/// Teams in der 1. Runde
		/// </summary>
		public FootballTeamCollection Teams
		{
			get { return _Teams; }
			set { _Teams = value; Notify(); }
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
		/// Anzahl der Teams
		/// </summary>
		public int TeamCount { get { return Teams.Count; } }

		#endregion

		#region Methods

		/// <summary>
		/// Gibt einen <see cref="String"/> zurück, der das Objekt darstellt.
		/// </summary>
		/// <returns>Objekt als String</returns>
		public override string ToString()
		{
			return String.Format("{0}, TeamCount={1}, RoundMode={2}", base.ToString(), TeamCount, RoundMode);
		}

		#endregion

	}
}
