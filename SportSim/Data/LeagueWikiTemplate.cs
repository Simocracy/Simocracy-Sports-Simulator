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
		private int _LeagueSize;
		private bool _IsDate;
		private bool _IsLocation;

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
		{
			get { return _LeagueSize; }
			set { _LeagueSize = value; Notify(); }
		}

		/// <summary>
		/// Ist Datumsangabe enthalten
		/// </summary>
		[DataMember(Order = 1010)]
		public bool IsDate
		{
			get { return _IsDate; }
			set { _IsDate = value; Notify(); }
		}

		/// <summary>
		/// Ist Ortsangabe Enthalten
		/// </summary>
		[DataMember(Order = 1020)]
		public bool IsLocation
		{
			get { return _IsLocation; }
			set { _IsLocation = value; Notify(); }
		}

		#endregion

		#region Overrided Methods

		/// <summary>
		/// Gibt einen <see cref="String"/> zurück, der das Objekt darstellt.
		/// </summary>
		/// <returns>Objekt als String</returns>
		public override string ToString()
		{
			return String.Format("{0} LeagueSize={1} IsDate={2} IsLocation={3}", base.ToString(), LeagueSize, IsDate, IsLocation);
		}

		#endregion
	}
}
