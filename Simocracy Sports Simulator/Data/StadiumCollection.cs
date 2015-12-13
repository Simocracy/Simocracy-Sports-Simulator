using System;
using System.Collections.Generic;
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
	public class StadiumCollection : List<Stadium>, IExtensibleDataObject
	{
		#region Manage States

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

		#region IExtensibleDataObject

		/// <summary>
		/// Erweiterungsdaten
		/// </summary>
		public ExtensionDataObject ExtensionData { get; set; }

		#endregion
	}
}
