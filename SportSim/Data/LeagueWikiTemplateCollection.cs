using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Stellt verschiedene Methoden zum Verwalten von Fußballteams zur Verfügung
	/// </summary>
	[CollectionDataContract(Name = "LeagueWikiTemplates")]
	public class LeagueWikiTemplateCollection : ObservableCollection<LeagueWikiTemplate>, ICollection<LeagueWikiTemplate>
	{

		#region Constructors

		/// <summary>
		/// Erstellt eine neue, leere <see cref="LeagueWikiTemplateCollection"/>
		/// </summary>
		public LeagueWikiTemplateCollection()
			: base()
		{ }

		/// <summary>
		/// Erstellt eine neue <see cref="LeagueWikiTemplateCollection"/> mit Vorlagen
		/// </summary>
		/// <param name="teamCollection"><see cref="IEnumerable{T}"/> mit Vorlagen</param>
		public LeagueWikiTemplateCollection(IEnumerable<LeagueWikiTemplate> teamCollection)
			: base(teamCollection)
		{ }

		/// <summary>
		/// Erstellt eine neue <see cref="LeagueWikiTemplateCollection"/> mit Vorlagen
		/// </summary>
		/// <param name="teamList"><see cref="List{T}"/> mit Vorlagen</param>
		public LeagueWikiTemplateCollection(List<LeagueWikiTemplate> teamList)
			: base(teamList)
		{ }

		#endregion

		#region Manage Templates

		/// <summary>
		/// Erstellt eine neues <see cref="LeagueWikiTemplate"/> und fügt es der Liste hinzu
		/// </summary>
		/// <param name="name">Name des <see cref="LeagueWikiTemplate"/></param>
		public void Create(string name)
		{
			Add(new LeagueWikiTemplate(GetNewID(), name));
		}

		/// <summary>
		/// Erstellt eine neues <see cref="LeagueWikiTemplate"/> und fügt es der Liste hinzu
		/// </summary>
		/// <param name="name">Name des <see cref="LeagueWikiTemplate"/></param>
		/// <param name="templateCode">Einbindungscode des <see cref="LeagueWikiTemplate"/></param>
		/// <param name="leagueSize">Gruppengröße</param>
		public void Create(string name, string templateCode, int leagueSize)
		{
			Add(new LeagueWikiTemplate(GetNewID(), name, templateCode, leagueSize));
		}

		/// <summary>
		/// Gibt das <see cref="LeagueWikiTemplate"/> mit dem angegebenen Namen zurück
		/// </summary>
		/// <param name="name">Name des <see cref="LeagueWikiTemplate"/></param>
		/// <returns><see cref="LeagueWikiTemplate"/> mit dem angegebenen Namen</returns>
		public LeagueWikiTemplate Get(string name)
		{
			var teams = this.Where(x => x.Name == name);
			return (teams.Count() != 1) ? null : teams.First();
		}

		/// <summary>
		/// Gibt das <see cref="LeagueWikiTemplate"/> mit der angegebenen ID zurück
		/// </summary>
		/// <param name="name">ID der <see cref="LeagueWikiTemplate"/></param>
		/// <returns><see cref="LeagueWikiTemplate"/> mit der angegebenen ID</returns>
		public LeagueWikiTemplate Get(int id)
		{
			var teams = this.Where(x => x.ID == id);
			return (teams.Count() != 1) ? null : teams.First();
		}

		#endregion

		#region Utilities

		/// <summary>
		/// Gibt die höchste bestehende ID einer <see cref="LeagueWikiTemplate"/> zurück
		/// </summary>
		/// <returns>Höchste ID</returns>
		public int GetMaxID()
		{
			if(Count > 0)
				return this.Max(x => x.ID);
			else
				return 0;
		}

		/// <summary>
		/// Gibt eine neue ID für eine <see cref="LeagueWikiTemplate"/> zurück
		/// </summary>
		/// <returns>Neue ID</returns>
		public int GetNewID()
		{
			return GetMaxID() + 1;
		}

		#endregion

		#region Extension Data

		/// <summary>
		/// Erweiterungsdaten
		/// </summary>
		public ExtensionDataObject ExtensionData { get; set; }

		#endregion
	}
}
