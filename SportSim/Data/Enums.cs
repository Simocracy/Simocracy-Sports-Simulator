using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		[Browsable(false)]
		[Description("Generisches Stadion")]
		GenericStadium = 0,

		/// <summary>
		/// Unbekannter Stadiontyp
		/// </summary>
		[Description("Unbekanntes Stadion")]
		UnknownStadium = 1,

		/// <summary>
		/// Reines Fussballstadion
		/// </summary>
		[Description("Reines Fußballstadion")]
		FootballStadium = 2,

		/// <summary>
		/// Stadion mit Laufbahn und Leichtathletikanlagen
		/// </summary>
		[Description("Stadion mit Leichtathletikanlage")]
		AthleticStadium = 3,

		/// <summary>
		/// Multifunktionsarena
		/// </summary>
		[Description("Multifunktionsarena")]
		MultiPurposeStadium = 4
	}

	/// <summary>
	/// Kontinent
	/// </summary>
	public enum Continent
	{
		/// <summary>
		/// Unbekannter Kontinent
		/// </summary>
		[Description("Unbekannt")]
		Unknown = 0,

		/// <summary>
		/// Amerika
		/// </summary>
		[Description("Amerika")]
		America = 1,

		/// <summary>
		/// Europa
		/// </summary>
		[Description("Europa")]
		Europe = 2,

		/// <summary>
		/// Afrika
		/// </summary>
		[Description("Afrika")]
		Africa = 3,

		/// <summary>
		/// Asien
		/// </summary>
		[Description("Asien")]
		Asia = 4,

		/// <summary>
		/// Ozeanien
		/// </summary>
		[Description("Ozeanien")]
		Oceania = 5
	}

	/// <summary>
	/// Rundenmodus einer Liga
	/// </summary>
	public enum LeagueRoundMode
	{
		/// <summary>
		/// Einfache Runde, nur Hinspiele
		/// </summary>
		[Description("Einzelrunde")]
		SingleRound = 0,

		/// <summary>
		/// Doppelrunde, Hin- und Rückspiele
		/// </summary>
		[Description("Doppelrunde")]
		DoubleRound = 1,

		/// <summary>
		/// Vierfachrunde, Je 2 Hin- und Rückspiele
		/// </summary>
		[Description("Vierfachrunde")]
		QuadrupleRound = 2

	}
}
