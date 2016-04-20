using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Abstrakte Basisklasse für Teams
	/// </summary>
	[DataContract]
	[DebuggerDisplay("Team, Name={Name}, State={State}, Stadium={Stadium}")]
	public abstract class Team : SSSDataObject
	{
		#region Members
		
		private State _State;
		private int _StateID;
		private Stadium _Stadium;
		private int _StadiumID;
		private string _Logo;

		#endregion

		#region Constructor

		/// <summary>
		/// Erstellt ein neues Team
		/// </summary>
		/// <param name="id">ID des Teams</param>
		/// <param name="name">Name des Teams</param>
		public Team(int id, string name)
			: this(id, name, String.Empty)
		{ }

		/// <summary>
		/// Erstellt ein neues Team
		/// </summary>
		/// <param name="id">ID des Teams</param>
		/// <param name="name">Name des Teams</param>
		/// <param name="logo">Logo des Teams</param>
		public Team(int id, string name, string logo)
			: this(id, name, logo, State.NoneState, Stadium.NoneStadium)
		{ }

		/// <summary>
		/// Erstellt ein neues Team
		/// </summary>
		/// <param name="id">ID des Teams</param>
		/// <param name="name">Name des Teams</param>
		/// <param name="logo">Logo des Teams</param>
		/// <param name="state">Staat des Teams</param>
		/// <param name="stadium">Stadion des Teams</param>
		public Team(int id, string name, string logo, State state, Stadium stadium)
			: base(id, name)
		{
			Logo = logo;
			State = state;
			Stadium = stadium;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Logo des Teams
		/// </summary>
		[DataMember(Order = 100)]
		public string Logo
		{
			get { return _Logo; }
			set { _Logo = value; Notify(); }
		}

		/// <summary>
		/// Angabe ob Logo extern hochgeladen ist
		/// </summary>
		[IgnoreDataMember]
		public bool IsExternLogo
		{ get { return WikiHelper.CheckValidHttpUrl(Logo); } }

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
		/// Stadion des Teams
		/// </summary>
		[IgnoreDataMember]
		public Stadium Stadium
		{
			get { return _Stadium; }
			set
			{
				_Stadium = value;
				_StadiumID = value.ID;
				Notify("Stadium");
				Notify("StadiumID");
			}
		}

		/// <summary>
		/// Stadion-ID des Teams
		/// </summary>
		[DataMember(Order = 120)]
		private int StadiumID
		{
			get { return _StadiumID; }
			set
			{
				_StadiumID = value;
				_Stadium = (value != -1) ? Settings.Stadiums.Get(value) : Stadium.NoneStadium;
				Notify("Stadium");
				Notify("StadiumID");
			}
		}

		/// <summary>
		/// Gesamtstärke des Teams
		/// </summary>
		[IgnoreDataMember]
		public abstract int Strength
		{ get; }

		/// <summary>
		/// Durchschnittsstärke eines Spielers
		/// </summary>
		[IgnoreDataMember]
		public double StrengthPerPlayer
		{
			get { return Strength / PlayerCount; }
		}

		/// <summary>
		/// Anzahl der Spieler pro Team
		/// </summary>
		[IgnoreDataMember]
		public abstract int PlayerCount
		{ get; }

		#endregion

		#region Overrided Methods

		/// <summary>
		/// Gibt einen <see cref="String"/> zurück, der das Objekt darstellt.
		/// </summary>
		/// <returns>Objekt als String</returns>
		public override string ToString()
		{
			return String.Format("{0}, Logo={1}, StateID={2}, StadiumID={3}", base.ToString(), Logo, StateID, StadiumID);
		}

		#endregion
	}
}