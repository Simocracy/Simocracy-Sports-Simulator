using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Klasse für Motorsportteams
	/// </summary>
	[DataContract]
	[DebuggerDisplay("RacingTeam, Name={Name}, State={State}")]
	public class RacingTeam : SSSDataObject
	{
		#region Members

		private State _State;
		private int _StateID;
		private int _Strength;
		private ERacingSeries _RacingSeries;
		private ObservableCollection<RacingDriver> _Drivers;

		#endregion

		#region Constructor

		/// <summary>
		/// Erstellt ein neues Rennteam
		/// </summary>
		/// <param name="id">ID des Teams</param>
		/// <param name="name">Name des Teams</param>
		public RacingTeam(int id, string name)
			: this(id, name, State.NoneState, 0, ERacingSeries.Unknwon)
		{ }

		/// <summary>
		/// Erstellt ein neues Rennteam
		/// </summary>
		/// <param name="id">ID des Teams</param>
		/// <param name="name">Name des Teams</param>
		/// <param name="state">Staat des Teams</param>
		/// <param name="strength">Stärke des Teams</param>
		public RacingTeam(int id, string name, State state, int strength, ERacingSeries racingSeries)
			: base(id, name)
		{
			State = state;
			Strength = strength;
			RacingSeries = racingSeries;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Staat des Teams
		/// </summary>
		[IgnoreDataMember]
		public State State
		{
			get { return _State; }
			set
			{
				_State = value;
				_StateID = value.ID;
				Notify("State");
				Notify("StateID");
			}
		}

		/// <summary>
		/// Staat-ID des Teams
		/// </summary>
		[DataMember(Order = 100)]
		private int StateID
		{
			get { return _StateID; }
			set
			{
				_StateID = value;
				_State = (value != -1) ? Settings.States.Get(value) : State.NoneState;
				Notify("State");
				Notify("StateID");
			}
		}

		/// <summary>
		/// Gesamtstärke des Teams
		/// </summary>
		[DataMember(Order = 110)]
		public int Strength
		{
			get { return _Strength; }
			set { _Strength = value; Notify(); }
		}

		/// <summary>
		/// Rennserie, in der das Team aktiv ist
		/// </summary>
		[DataMember(Order = 120)]
		public ERacingSeries RacingSeries
		{
			get { return _RacingSeries; }
			set { _RacingSeries = value; Notify(); }
		}

		/// <summary>
		/// Fahrer des Teams
		/// </summary>
		[IgnoreDataMember]
		public ObservableCollection<RacingDriver> Drivers
		{
			get { return _Drivers; }
			set { _Drivers = value; Notify(); }
		}

		/// <summary>
		/// IDs der Fahrer
		/// </summary>
		[DataMember(Order = 130)]
		private IEnumerable<int> DriverIDs
		{
			get { return Drivers.Select(x => x.ID); }
			set
			{
				if(Drivers == null)
					Drivers = new ObservableCollection<RacingDriver>();
				foreach(var id in value)
					Drivers.Add(Settings.RacingDrivers.Get(id));
			}
		}

		/// <summary>
		/// Anzahl der Fahrer des Teams
		/// </summary>
		[IgnoreDataMember]
		public int DriverCount
		{ get { return Drivers.Count; } }

		#endregion

		#region Overrided Methods

		/// <summary>
		/// Gibt einen <see cref="String"/> zurück, der das Objekt darstellt.
		/// </summary>
		/// <returns>Objekt als String</returns>
		public override string ToString()
		{
			return String.Format("{0}, StateID={1}, RacingSeries={2}, Strength={3}, DriverCount={4}", base.ToString(), StateID, Strength, DriverCount);
		}

		#endregion
	}
}
