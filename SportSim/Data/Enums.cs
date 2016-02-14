using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Stadiontyp
	/// </summary>
	public enum EStadiumType
	{
		/// <summary>
		/// Generisches Stadion für Platzhalter
		/// </summary>
		GenericStadium = 0,

		/// <summary>
		/// Unbekannter Stadiontyp
		/// </summary>
		UnknownStadium = 1,

		/// <summary>
		/// Reines Fussballstadion
		/// </summary>
		FootballStadium = 2,

		/// <summary>
		/// Stadion mit Laufbahn und Leichtathletikanlagen
		/// </summary>
		AthleticStadium = 3
	}

	/// <summary>
	/// Kontinent
	/// </summary>
	public enum Continent
	{
		/// <summary>
		/// Unbekannter Kontinent
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// Amerika
		/// </summary>
		America = 1,

		/// <summary>
		/// Europa
		/// </summary>
		Europe = 2,

		/// <summary>
		/// Afrika
		/// </summary>
		Africa = 3,

		/// <summary>
		/// Asien
		/// </summary>
		Asia = 4,

		/// <summary>
		/// Ozeanien
		/// </summary>
		Oceania = 5
	}
}
