using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	public abstract class SSSDataObject : IExtensibleDataObject, INotifyPropertyChanged
	{

		#region Members

		private int _ID;
		private string _Name;

		#endregion

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
		{
			get { return _ID; }
			set { _ID = value; Notify(); }
		}

		/// <summary>
		/// Name
		/// </summary>
		[DataMember(Order = 20)]
		public string Name
		{
			get { return _Name; }
			set { _Name = value; Notify(); }
		}

		#endregion

		#region Overrided Methods

		/// <summary>
		/// Gibt einen <see cref="String"/> zurück, der das Objekt darstellt.
		/// </summary>
		/// <returns>Objekt als String</returns>
		public override string ToString()
		{
			return String.Format("{0}: ID={1}, Name={2}", GetType(), ID, Name);
		}

		#endregion

		#region IExtensibleDataObject

		/// <summary>
		/// Erweiterungsdaten
		/// </summary>
		public ExtensionDataObject ExtensionData { get; set; }

		#endregion

		#region INotifyPropertyChanged

		/// <summary>
		/// Observer-Event
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Observer
		/// </summary>
		/// <param name="propertyName">Property</param>
		protected void Notify([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

	}
}
