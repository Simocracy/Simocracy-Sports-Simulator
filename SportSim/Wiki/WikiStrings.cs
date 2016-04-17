using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Basisstrings für die Wikicode-Generierung
	/// </summary>
	[DataContract]
	public class WikiStrings
	{

		#region Basics

		/// <summary>
		/// Tabellenende
		/// </summary>
		[DataMember]
		public readonly string TableEnd;

		/// <summary>
		/// Nur CSS-Klasse Qual1
		/// </summary>
		[DataMember]
		public readonly string ClassQual1;

		/// <summary>
		/// Nur CSS-Klasse Qual2
		/// </summary>
		[DataMember]
		public readonly string ClassQual2;

		#endregion

		#region Football

		/// <summary>
		/// Tabellenheader für Fußballtabellen
		/// </summary>
		[DataMember]
		public readonly string FootballLeagueTableHeader;

		/// <summary>
		/// Tabellenelemente für Fußballtabellen.
		/// Format: Klasse, Platz, Team, S, U, N, Tore, Punkte
		/// </summary>
		[DataMember]
		public readonly string FootballLeagueTableElememt;

		#endregion

		#region Results

		/// <summary>
		/// Tabellenheader für Ergebnistabellen für Einzelrunden.
		/// Format: Breite
		/// </summary>
		[DataMember]
		public readonly string ResultsSingleRoundTableHeader;

		/// <summary>
		/// Tabellenheader für Ergebnistabellen für Doppelrunden.
		/// Format: Breite, Seite
		/// </summary>
		[DataMember]
		public readonly string ResultsDoubleRoundTableHeader;

		#endregion
	}
}
