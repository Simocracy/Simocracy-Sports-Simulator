using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{

	/// <summary>
	/// Stellt verschiedene Methoden zum Verwalten von Rennfahrern zur Verfügung
	/// </summary>
	[CollectionDataContract(Name = "RacingTeams")]
	public class RacingTeamCollection : ObservableCollection<RacingTeam>, ICollection<RacingTeam>
	{
		#region Constructors

		/// <summary>
		/// Erstellt eine neue, leere <see cref="RacingTeamCollection"/>
		/// </summary>
		public RacingTeamCollection()
			: base()
		{ }

		/// <summary>
		/// Erstellt eine neue <see cref="RacingTeamCollection"/> mit Teams
		/// </summary>
		/// <param name="teamCollection">IEnumerable mit Teams</param>
		public RacingTeamCollection(IEnumerable<RacingTeam> teamCollection)
			: base(teamCollection)
		{ }

		/// <summary>
		/// Erstellt eine neue <see cref="RacingTeamCollection"/> mit Teams
		/// </summary>
		/// <param name="teamList">IEnumerable mit Teams</param>
		public RacingTeamCollection(List<RacingTeam> teamList)
			: base(teamList)
		{ }

		/// <summary>
		/// Erstellt eine neue <see cref="RacingTeamCollection"/> aus der angegeben <see cref="IList"/>
		/// </summary>
		/// <param name="list">Liste</param>
		public static RacingTeamCollection CreateCollection(IList list)
		{
			var col = new RacingTeamCollection();
			col.Add(list);
			return col;
		}

		#endregion

		#region Manage

		/// <summary>
		/// Fügt die <see cref="RacingTeam"/>-Objekte in der angegebenen <see cref="IList"/> der <see cref="RacingTeamCollection"/> hinzu
		/// </summary>
		/// <param name="list">Liste</param>
		public void Add(IList list)
		{
			foreach(var item in list)
			{
				var itemFT = item as RacingTeam;
				if(itemFT != null)
					Add(itemFT);
			}
		}

		/// <summary>
		/// Erstellt einen neues <see cref="RacingTeam"/>-Objekt und fügt es der Liste hinzu
		/// </summary>
		/// <param name="name">Name des Teams</param>
		public void Create(string name)
		{
			Add(new RacingTeam(GetNewID(), name));
		}

		/// <summary>
		/// Erstellt ein neues <see cref="RacingTeam"/>-Objekt und fügt es der Liste hinzu
		/// </summary>
		/// <param name="name">Name des Teams</param>
		/// <param name="state">Staat des Teams</param>
		/// <param name="strength">Stärke des Teams</param>
		/// <param name="racingSeries">Rennserie, in der das Team startet</param>
		public void Create(string name, State state, int strength, ERacingSeries racingSeries)
		{
			Add(new RacingTeam(GetNewID(), name, state, strength, racingSeries));
		}

		/// <summary>
		/// Gibt das <see cref="RacingTeam"/> mit dem angegebenen Namen zurück
		/// </summary>
		/// <param name="name">Name des Teams</param>
		/// <returns>Team mit dem angegebenen Namen.
		/// null wenn keins verfügbar oder mehrere mit dem gleichen Namen vorhanden</returns>
		public RacingTeam Get(string name)
		{
			var fahrer = this.Where(x => x.Name == name);
			return (fahrer.Count() != 1) ? null : fahrer.First();
		}

		/// <summary>
		/// Gibt den <see cref="RacingTeam"/> mit der angegebenen ID zurück
		/// </summary>
		/// <param name="name">ID des Teams</param>
		/// <returns>Team mit der angegebenen ID</returns>
		public RacingTeam Get(int id)
		{
			return this.Where(x => x.ID == id).FirstOrDefault();
		}

		#endregion

		#region Utilities

		/// <summary>
		/// Gibt die höchste bestehende ID zurück, oder -1 nichts vorhanden ist
		/// </summary>
		/// <returns>Höchste ID</returns>
		public int GetMaxID()
		{
			if(Count > 0)
				return this.Max(x => x.ID);
			else
				return -1;
		}

		/// <summary>
		/// Gibt eine neue ID zurück
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
