using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Wiki-Vorlage einer Gruppenvorlage
	/// </summary>
	[DataContract]
	[DebuggerDisplay("LeagueWikiTemplate, Name={Name}")]
	public class LeagueWikiTemplate : WikiTemplate
	{

		#region Members

		private static LeagueWikiTemplate _NoneTemplate = new LeagueWikiTemplate(-1, String.Empty, String.Empty, 0, false, false);

		#endregion

		#region Constructor

		/// <summary>
		/// Definiert eine neue Gruppenvorlage
		/// </summary>
		/// <param name="id">ID</param>
		/// <param name="name">Vorlagenname</param>
		public LeagueWikiTemplate(int id, string name)
			: this(id, name, String.Empty, 0)
		{ }

		/// <summary>
		/// Definiert eine neue Gruppenvorlage
		/// </summary>
		/// <param name="id">ID</param>
		/// <param name="name">Vorlagenname</param>
		/// <param name="templateCode">Einbindungscode der Vorlage</param>
		/// <param name="leagueSize">Gruppengröße</param>
		public LeagueWikiTemplate(int id, string name, string templateCode, int leagueSize)
			: this(id, name, templateCode, 0, false, false)
		{ }

		/// <summary>
		/// Definiert eine neue Gruppenvorlage
		/// </summary>
		/// <param name="id">ID</param>
		/// <param name="name">Vorlagenname</param>
		/// <param name="templateCode">Einbindungscode der Vorlage</param>
		/// <param name="leagueSize">Gruppengröße</param>
		/// <param name="isDate">Angabe ob Datum enthalten ist</param>
		/// <param name="isLocation">Angabe ob Ort enthalten ist</param>
		public LeagueWikiTemplate(int id, string name, string templateCode, int leagueSize, bool isDate, bool isLocation)
			: base(id, name, templateCode)
		{
			LeagueSize = leagueSize;
			IsDate = isDate;
			IsLocation = isLocation;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Leere Vorlage
		/// </summary>
		[IgnoreDataMember]
		public static LeagueWikiTemplate NoneTemplate
		{
			get { return _NoneTemplate; }
		}

		/// <summary>
		/// Gruppengröße
		/// </summary>
		[DataMember(Order = 1000)]
		public int LeagueSize
		{ get; set; }

		/// <summary>
		/// Ist Datumsangabe enthalten
		/// </summary>
		[DataMember(Order = 1010)]
		public bool IsDate
		{ get; set; }

		/// <summary>
		/// Ist Ortsangabe Enthalten
		/// </summary>
		[DataMember(Order = 1020)]
		public bool IsLocation
		{ get; set; }

		#endregion
	}
}
