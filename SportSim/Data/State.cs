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
	/// Klasse für Staaten in Simocracy
	/// </summary>
	[DataContract]
	[DebuggerDisplay("State, Name={Name}")]
	public class State : SSSDataObject
	{
		#region Members

		/// <summary>
		/// Leerer Staat ohne Angaben
		/// </summary>
		private static State _NoneState = new State(-1, String.Empty, String.Empty, EContinent.Unknown);

		private string _Flag;
		private EContinent _Continent;

		#endregion

		#region Constructors

		/// <summary>
		/// Erstellt einen neuen Staat
		/// </summary>
		/// <param name="id">ID des Staates</param>
		/// <param name="name">Name des Staates</param>
		public State(int id, string name)
			: this(id, name, String.Empty, EContinent.Unknown)
		{ }

		/// <summary>
		/// Erstellt einen neuen Staat
		/// </summary>
		/// <param name="id">ID des Staates</param>
		/// <param name="name">Name des Staates</param>
		/// <param name="flag">Flaggenkürzel des Staates</param>
		/// <param name="continent">Kontinent des Staates</param>
		public State(int id, string name, string flag, EContinent continent)
			: base(id, name)
		{
			Flag = flag;
			Continent = continent;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Leerer Staat ohne Angaben
		/// </summary>
		public static State NoneState
		{
			get { return _NoneState; }
		}

		/// <summary>
		/// Flaggenkürzel des Staates
		/// </summary>
		[DataMember(Order = 100)]
		public string Flag
		{
			get { return _Flag; }
			set { _Flag = value; Notify(); }
		}


		/// <summary>
		/// Hauptkontinent des Staates
		/// </summary>
		[DataMember(Order = 110)]
		public EContinent Continent
		{
			get { return _Continent; }
			set { _Continent = value; Notify(); }
		}

		#endregion

		#region Overrided Methods

		/// <summary>
		/// Gibt einen <see cref="String"/> zurück, der das Objekt darstellt.
		/// </summary>
		/// <returns>Objekt als String</returns>
		public override string ToString()
		{
			return String.Format("{0} {1}={2} {3}={4}", base.ToString(),
				nameof(Flag), Flag, nameof(Continent), Continent);
		}

		#endregion
	}
}
