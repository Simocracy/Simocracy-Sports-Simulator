using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{

	#region EStadiumType

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

	#endregion

	#region EContinent

	/// <summary>
	/// Kontinent
	/// </summary>
	public enum EContinent
	{
		/// <summary>
		/// Unbekannter Kontinent
		/// </summary>
		[Browsable(false)]
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

	#endregion

	#region ELeagueRoundMode

	/// <summary>
	/// Rundenmodus einer Liga
	/// </summary>
	public enum ELeagueRoundMode
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

	#endregion

	#region EKORoundMode

	/// <summary>
	/// Spielmodus einer KO-Runde
	/// </summary>
	public enum EKORoundMode
	{
		/// <summary>
		/// Ein Spiel
		/// </summary>
		[Description("Ein Spiel")]
		OneMatch = 0,

		/// <summary>
		/// 2 Spiele, Hin- und Rückspiel
		/// </summary>
		[Description("Zwei Spiele")]
		TwoMatches = 1,

		/// <summary>
		/// Sieger aus 3 Spielen
		/// </summary>
		[Description("Best of 3")]
		BestOf3 = 2,

		/// <summary>
		/// Sieger aus 5 Spielen
		/// </summary>
		[Description("Best of 5")]
		BestOf5 = 3,

		/// <summary>
		/// Sieger aus 7 Spielen
		/// </summary>
		[Description("Best of 7")]
		BestOf7 = 4

	}

	#endregion

	#region EKORoundMode

	/// <summary>
	/// Runde innerhalb der KO-Runde
	/// </summary>
	public enum EKORound
	{
		/// <summary>
		/// Unbekannt
		/// </summary>
		[Description("Unbekannt")]
		Unknown = 0,

		/// <summary>
		/// Runde der 128
		/// </summary>
		[Description("Runde der 128")]
		RoundOf128 = 1,

		/// <summary>
		/// Runde der 64
		/// </summary>
		[Description("Runde der 64")]
		RoundOf64 = 2,

		/// <summary>
		/// Runde der 32
		/// </summary>
		[Description("Runde der 32")]
		RoundOf32 = 3,

		/// <summary>
		/// Achtelfinale
		/// </summary>
		[Description("Achtelfinale")]
		RoundOf16 = 4,

		/// <summary>
		/// Viertelfinale
		/// </summary>
		[Description("Viertelfinale")]
		QuarterFinal = 5,

		/// <summary>
		/// Halbfinale
		/// </summary>
		[Description("Halbfinale")]
		SemiFinal = 6,

		/// <summary>
		/// Finale
		/// </summary>
		[Description("Finale")]
		Final = 7

	}

	#endregion

	#region ERacingSeries

	/// <summary>
	/// Rennserien
	/// </summary>
	public enum ERacingSeries
	{

		/// <summary>
		/// Unbekannte Rennserie
		/// </summary>
		[Browsable(false)]
		[Description("Unbekannt")]
		Unknwon = 0,

		/// <summary>
		/// VALMOL
		/// </summary>
		[Description("VALMOL")]
		VALMOL = 1
	}

	#endregion

	#region ERaceTrackType

	/// <summary>
	/// Streckentyp einer Rennstrecke
	/// </summary>
	public enum ERaceTrackType
	{

		/// <summary>
		/// Generische Strecke
		/// </summary>
		[Browsable(false)]
		[Description("Generische Strecke")]
		GenericTrack = 0,

		/// <summary>
		/// Unbekannte Strecke
		/// </summary>
		[Description("Unbekannte Strecke")]
		UnknownTrack = 1,

		/// <summary>
		/// Straßenkurs
		/// </summary>
		[Description("Straßenkurs")]
		StreetTrack = 2,

		/// <summary>
		/// Speedway
		/// </summary>
		[Description("Speedway")]
		SpeedwayTrack = 3,

		/// <summary>
		/// Rallystrecke
		/// </summary>
		[Description("Rallystrecke")]
		RallyTrack = 4
	}

	#endregion
}
