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
	/// Rennfahrer
	/// </summary>
	[DataContract]
	[DebuggerDisplay("RacingDriver, Name={Name}")]
	public class RacingDriver : SSSDataObject
	{
		#region Members

		private State _State;
		private int _StateID;
		private int _StrengthStreet;
		private int _StrengtSpeedway;
		private int _StrengtRally;

		#endregion

		#region Constructor

		/// <summary>
		/// Erstellt einen neuen Fahrer
		/// </summary>
		/// <param name="id">ID des Fahrers</param>
		/// <param name="name">Name des Fahrers</param>
		public RacingDriver(int id, string name)
			: this(id, name, State.NoneState)
		{ }

		/// <summary>
		/// Erstellt einen neuen Fahrer
		/// </summary>
		/// <param name="id">ID des Fahrers</param>
		/// <param name="name">Name des Fahrers</param>
		/// <param name="state">Staat des Fahrers</param>
		public RacingDriver(int id, string name, State state)
			: this(id, name, state, 0, 0, 0)
		{ }

		/// <summary>
		/// Erstellt einen neuen Fahrer
		/// </summary>
		/// <param name="id">ID des Fahrers</param>
		/// <param name="name">Name des Fahrers</param>
		/// <param name="state">Staat des Fahrers</param>
		/// <param name="strengthStreet">Stärke auf Straßenkursen</param>
		/// <param name="strengthSpeedway">Stärke auf Speedways</param>
		/// <param name="strengthRally">Stärke auf Rallykursen</param>
		public RacingDriver(int id, string name, State state, int strengthStreet, int strengthSpeedway, int strengthRally)
			: base(id, name)
		{
			State = state;
			StrengthStreet = strengthStreet;
			StrengthSpeedway = strengthSpeedway;
			StrengthRally = strengthRally;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Staat des Fahrers
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
		/// Staat-ID des Fahrers
		/// </summary>
		[DataMember(Order = 110)]
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
		/// Stärke auf Straßenkursen
		/// </summary>
		[DataMember(Order = 120)]
		public int StrengthStreet
		{
			get { return _StrengthStreet; }
			set { _StrengthStreet = value; Notify(); }
		}

		/// <summary>
		/// Stärke auf Speedways
		/// </summary>
		[DataMember(Order = 130)]
		public int StrengthSpeedway
		{
			get { return _StrengtSpeedway; }
			set { _StrengtSpeedway = value; Notify(); }
		}

		/// <summary>
		/// Stärke auf Rallykursen
		/// </summary>
		[DataMember(Order = 140)]
		public int StrengthRally
		{
			get { return _StrengtRally; }
			set { _StrengtRally = value; Notify(); }
		}

		#endregion

		#region Overrided Methods

		/// <summary>
		/// Gibt einen <see cref="String"/> zurück, der das Objekt darstellt.
		/// </summary>
		/// <returns>Objekt als String</returns>
		public override string ToString()
		{
			return String.Format("{0}, StateID={1}, StrenghtStreet={2}, StrengthSpeedway={3}, StrengthRally={4}", base.ToString(), StrengthStreet, StrengthSpeedway, StrengthRally);
		}

		#endregion
	}
}
