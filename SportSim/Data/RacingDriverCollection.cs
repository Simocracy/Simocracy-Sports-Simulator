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
	[CollectionDataContract(Name = "RacingDrivers")]
	public class RacingDriverCollection : ObservableCollection<RacingDriver>, ICollection<RacingDriver>
	{
		#region Constructors

		/// <summary>
		/// Erstellt eine neue, leere <see cref="RacingDriverCollection"/>
		/// </summary>
		public RacingDriverCollection()
			: base()
		{ }

		/// <summary>
		/// Erstellt eine neue <see cref="RacingDriverCollection"/> mit Fahrern
		/// </summary>
		/// <param name="teamCollection">IEnumerable mit Fahrern</param>
		public RacingDriverCollection(IEnumerable<RacingDriver> teamCollection)
			: base(teamCollection)
		{ }

		/// <summary>
		/// Erstellt eine neue <see cref="RacingDriverCollection"/> mit Fahrern
		/// </summary>
		/// <param name="teamList">IEnumerable mit Fahrern</param>
		public RacingDriverCollection(List<RacingDriver> teamList)
			: base(teamList)
		{ }

		/// <summary>
		/// Erstellt eine neue <see cref="RacingDriverCollection"/> aus der angegeben <see cref="IList"/>
		/// </summary>
		/// <param name="list">Liste</param>
		public static RacingDriverCollection CreateCollection(IList list)
		{
			var col = new RacingDriverCollection();
			col.Add(list);
			return col;
		}

		#endregion

		#region Manage

		/// <summary>
		/// Fügt die <see cref="RacingDriver"/>-Objekte in der angegebenen <see cref="IList"/> der <see cref="RacingDriverCollection"/> hinzu
		/// </summary>
		/// <param name="list">Liste</param>
		public void Add(IList list)
		{
			foreach(var item in list)
			{
				var itemFT = item as RacingDriver;
				if(itemFT != null)
					Add(itemFT);
			}
		}

		/// <summary>
		/// Erstellt einen neues <see cref="RacingDriver"/>-Objekt und fügt es der Liste hinzu
		/// </summary>
		/// <param name="name">Name des Fahrers</param>
		public void Create(string name)
		{
			Add(new RacingDriver(GetNewID(), name));
		}

		/// <summary>
		/// Erstellt ein neues <see cref="RacingDriver"/>-Objekt und fügt es der Liste hinzu
		/// </summary>
		/// <param name="name">Name des Fahrers</param>
		/// <param name="state">Staat des Fahrers</param>
		public void Create(string name, State state)
		{
			Add(new RacingDriver(GetNewID(), name, state));
		}

		/// <summary>
		/// Erstellt ein neues <see cref="RacingDriver"/>-Objekt und fügt es der Liste hinzu
		/// </summary>
		/// <param name="name">Name des Farers</param>
		/// <param name="state">Staat des Fahrers</param>
		/// <param name="strengthStreet">Stärke des Fahrers auf Straßenkursen</param>
		/// <param name="strengthSpeedway">Stärke der Fahrers auf Speedways</param>
		/// <param name="strengthRally">Stärke des Fahrers auf Rallykursen</param>
		public void Create(string name, State state, int strengthStreet, int strengthSpeedway, int strengthRally)
		{
			Add(new RacingDriver(GetNewID(), name, state, strengthStreet, strengthSpeedway, strengthRally));
		}

		/// <summary>
		/// Gibt den <see cref="RacingDriver"/> mit dem angegebenen Namen zurück
		/// </summary>
		/// <param name="name">Name des Fahrers</param>
		/// <returns>Fahrer mit dem angegebenen Namen</returns>
		public RacingDriver Get(string name)
		{
			var fahrer = this.Where(x => x.Name == name);
			return (fahrer.Count() != 1) ? null : fahrer.First();
		}

		/// <summary>
		/// Gibt den <see cref="RacingDriver"/> mit der angegebenen ID zurück
		/// </summary>
		/// <param name="name">ID des Fahrers</param>
		/// <returns>Fahrer mit der angegebenen ID</returns>
		public RacingDriver Get(int id)
		{
			return this.Where(x => x.ID == id).FirstOrDefault();
		}

		#endregion

		#region Utilities

		/// <summary>
		/// Gibt die höchste bestehende ID eines Fahrers zurück, oder -1 wenn kein Fahrer vorhanden ist
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
		/// Gibt eine neue ID für einen Fahrer zurück
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
