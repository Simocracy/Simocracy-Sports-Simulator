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

		#region Constructor

		/// <summary>
		/// Definiert eine neue Gruppenvorlage
		/// </summary>
		/// <param name="id">ID</param>
		/// <param name="name">Vorlagenname</param>
		public LeagueWikiTemplate(int id, string name)
			: base(id, name)
		{ }

		/// <summary>
		/// Definiert eine neue Gruppenvorlage
		/// </summary>
		/// <param name="id">ID</param>
		/// <param name="name">Vorlagenname</param>
		/// <param name="templateCode">Einbindungscode der Vorlage</param>
		/// <param name="leagueSize">Gruppengröße</param>
		public LeagueWikiTemplate(int id, string name, string templateCode, int leagueSize)
			: base(id, name, templateCode)
		{
			LeagueSize = leagueSize;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gruppengröße
		/// </summary>
		[DataMember(Order = 1000)]
		public int LeagueSize
		{ get; set; }

		#endregion
	}
}
