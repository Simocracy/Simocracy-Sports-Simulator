using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Interface für Collections
	/// </summary>
	public interface ICollection<T> : IExtensibleDataObject
	{

		/// <summary>
		/// Erstellt ein neues Objekt und fügt es der Liste hinzu
		/// </summary>
		/// <param name="name">Name</param>
		void Add(string name);

		/// <summary>
		/// Gibt das Objekt mit dem angegebenen Namen zurück
		/// </summary>
		/// <param name="name">Name</param>
		/// <returns>Objekt mit dem angegebenen Namen</returns>
		T Get(string name);

		/// <summary>
		/// Gibt das Objekt mit der angegebenen ID zurück
		/// </summary>
		/// <param name="name">ID</param>
		/// <returns>TeamObjekt mit der angegebenen ID</returns>
		T Get(int id);

		/// <summary>
		/// Gibt die höchste bestehende ID der Collection zurück
		/// </summary>
		/// <returns>Höchste ID</returns>
		int GetMaxID();
		
		/// <summary>
		/// Gibt eine neue ID zurück
		/// </summary>
		/// <returns>Neue ID</returns>
		int GetNewID();

	}
}
