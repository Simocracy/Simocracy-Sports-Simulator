using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Stellt verschiedene Methoden zum Verwalten von Staaten zur Verfügung
	/// </summary>
	[CollectionDataContract(Name = "States")]
	public class StateCollection : List<State>, IExtensibleDataObject
	{
		#region Manage States

		/// <summary>
		/// Gibt den Staat mit der angegebenen ID zurück
		/// </summary>
		/// <param name="id">ID des Staates</param>
		/// <returns>Staat mit der angegebenen ID</returns>
		public State Get(int id)
		{
			var states = this.Where(x => x.ID == id);
			return (states.Count() != 1) ? null : states.First();
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
