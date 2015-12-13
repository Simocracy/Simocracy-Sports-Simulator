using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Statische Einstellungsklasse des ganzen SportSim
	/// </summary>
	public static class Settings
	{

		#region Lists

		/// <summary>
		/// Liste aller Fussballteams
		/// </summary>
		public static FootballTeamCollection FootballTeams { get; set; }

		/// <summary>
		/// Liste aller Staaten
		/// </summary>
		public static StateCollection States { get; set; }

		/// <summary>
		/// Liste aller Stadien
		/// </summary>
		public static StadiumCollection Stadiums { get; set; }

		#endregion

	}
}
