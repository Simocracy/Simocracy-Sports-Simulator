using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Simocracy.SportSim.Data
{
	/// <summary>
	/// Interface für TeamCollections
	/// </summary>
	public interface ITeamCollection<T>
	{

		/// <summary>
		/// Gibt das Team mit dem angegebenen Namen zurück
		/// </summary>
		/// <param name="name">Name des Teams</param>
		/// <returns>Team mit dem angegebenen Namen</returns>
		T Get(string name);

		/// <summary>
		/// Gibt das Team mit der größten Stärke zurück
		/// </summary>
		/// <returns>Team mit der größten Stärke</returns>
		T GetBestTeam();

	}
}
