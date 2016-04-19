using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Strings für das Parsen und Generieren von Wikicode
	/// </summary>
	[DataContract]
	public class WikiStrings
	{

		#region Basics

		/// <summary>
		/// Tabellenende
		/// </summary>
		[IgnoreDataMember]
		public const string TableEnd = "|}";

		/// <summary>
		/// Vorlagenstart
		/// </summary>
		[IgnoreDataMember]
		public const string TemplateStart = "{{";

		/// <summary>
		/// Vorlagenende
		/// </summary>
		[IgnoreDataMember]
		public const string TemplateEnd = "}}";

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

		#region Templates

		/// <summary>
		/// Allgemeine <see cref="System.Text.RegularExpressions.Regex"/>-Expression für Variablen in einer <see cref="WikiTemplate"/>
		/// </summary>
		[DataMember]
		public const string TemplateRegexString = @"\|\s*([^=]*)\s*=";

		/// <summary>
		/// Allgemeine <see cref="System.Text.RegularExpressions.Regex"/>-Expression Vorlagennamen in einer <see cref="WikiTemplate"/>
		/// </summary>
		[DataMember]
		public const string TemplateNameRegexString = @"([^\\{])([^\\|]*)";

		/// <summary>
		/// Allgemeine <see cref="System.Text.RegularExpressions.Regex"/>-Expression für den Beginn einer Variablen in einer <see cref="WikiTemplate"/>
		/// </summary>
		[DataMember]
		public const string TemplateVariableStartRegexString = "|";

		/// <summary>
		/// <see cref="System.Text.RegularExpressions.Regex"/>-Expression für Teamnamen in einer <see cref="WikiTemplate"/>
		/// </summary>
		[DataMember]
		public readonly string TemplateLeagueTeamRegexString;

		/// <summary>
		/// <see cref="System.Text.RegularExpressions.Regex"/>-Expression für Datumsangaben in einer <see cref="WikiTemplate"/>
		/// </summary>
		[DataMember]
		public readonly string TemplateLeagueDateRegexString;

		/// <summary>
		/// <see cref="System.Text.RegularExpressions.Regex"/>-Expression für Ortsangaben in einer <see cref="WikiTemplate"/>
		/// </summary>
		[DataMember]
		public readonly string TemplateLeagueLocationRegexString;

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
