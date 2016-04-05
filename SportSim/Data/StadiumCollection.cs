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
	/// Stellt verschiedene Methoden zum Verwalten von Stadien zur Verfügung
	/// </summary>
	[CollectionDataContract(Name = "Stadiums")]
	public class StadiumCollection : ObservableCollection<Stadium>, ICollection<Stadium>
	{
		#region Manage Stadiums

		/// <summary>
		/// Erstellt ein neues Stadion und fügt es der Liste hinzu
		/// </summary>
		/// <param name="name">Name des Stadions</param>
		public void Create(string name)
		{
			Add(new Stadium(GetNewID(), name));
		}

		/// <summary>
		/// Erstellt ein neues Stadion und fügt es der Liste hinzu
		/// </summary>
		/// <param name="name">Name des Stadions</param>
		/// <param name="state">Staat in dem das Stadion liegt</param>
		/// <param name="city">Stadt in dem das Stadion liegt</param>
		/// <param name="capacity">Kapazität des Stadions</param>
		/// <param name="stadiumType">Typ des Stadions</param>
		public void Create(string name, State state, string city, int capacity, EStadiumType stadiumType)
		{
			Add(new Stadium(GetNewID(), name, state, city, capacity, stadiumType));
		}

		/// <summary>
		/// Erstellt ein neues Stadion und fügt es der Liste hinzu
		/// </summary>
		/// <param name="name">Name des Stadions</param>
		/// <param name="state">Staat in dem das Stadion liegt</param>
		/// <param name="city">Stadt in dem das Stadion liegt</param>
		/// <param name="capacityInt">Internationale Kapazität des Stadions</param>
		/// <param name="capacityNat">Nationale Kapazität des Stadions</param>
		/// <param name="stadiumType">Typ des Stadions</param>
		public void Create(string name, State state, string city, int capacityInt, int capacityNat, EStadiumType stadiumType)
		{
			Add(new Stadium(GetNewID(), name, state, city, capacityInt, capacityNat, stadiumType));
		}

		/// <summary>
		/// Gibt das Stadion mit dem angegebenen Namen zurück
		/// </summary>
		/// <param name="name">Name des Stadions</param>
		/// <returns>Stadion mit dem angegebenen Namen</returns>
		public Stadium Get(string name)
		{
			var stadiums = this.Where(x => x.Name == name);
			return (stadiums.Count() != 1) ? null : stadiums.First();
		}

		/// <summary>
		/// Gibt das Stadion mit der angegebenen ID zurück
		/// </summary>
		/// <param name="id">ID des Stadions</param>
		/// <returns>Stadion mit der angegebenen ID</returns>
		public Stadium Get(int id)
		{
			var stadiums = this.Where(x => x.ID == id);
			return (stadiums.Count() != 1) ? null : stadiums.First();
		}

		#endregion

		#region Utilities

		/// <summary>
		/// Gibt die höchste bestehende ID eines Teams zurück
		/// </summary>
		/// <returns>Höchste ID</returns>
		public int GetMaxID()
		{
			return this.Max(x => x.ID);
		}

		/// <summary>
		/// Gibt eine neue ID für ein Team zurück
		/// </summary>
		/// <returns>Neue ID</returns>
		public int GetNewID()
		{
			return GetMaxID() + 1;
		}

		#endregion

		#region IExtensibleDataObject

		/// <summary>
		/// Erweiterungsdaten
		/// </summary>
		public ExtensionDataObject ExtensionData { get; set; }

		#endregion
	}
}
