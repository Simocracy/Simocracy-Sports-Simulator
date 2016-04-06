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
	/// Basisklasse für speicherbare und auflistbare Objekte
	/// </summary>
	[DataContract]
	public abstract class SSSDataObject : IExtensibleDataObject
	{

		#region Constructors

		/// <summary>
		/// Erstellt ein neues Objekt
		/// </summary>
		/// <param name="id">ID</param>
		/// <param name="name">Name</param>
		public SSSDataObject(int id, string name)
		{
			ID = id;
			Name = name;
		}

		#endregion

		#region Properties

		/// <summary>
		/// ID
		/// </summary>
		[DataMember(Order = 10)]
		public int ID
		{ get; set; }

		/// <summary>
		/// Name
		/// </summary>
		[DataMember(Order = 20)]
		public string Name
		{ get; set; }

		#endregion

		#region IExtensibleDataObject

		/// <summary>
		/// Erweiterungsdaten
		/// </summary>
		public ExtensionDataObject ExtensionData { get; set; }

		#endregion
	}
}
