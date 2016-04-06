using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Abstrakte Basisklasse für Teams
	/// </summary>
	[DataContract]
	public abstract class Team : SSSDataObject
	{
		#region Members
		
		private State _State;
		private int _StateID;
		private Stadium _Stadium;
		private int _StadiumID;

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
		{ get; set; }

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
			get
			{
				return Strength / PlayerCount;
			}
		}

		/// <summary>
		/// Anzahl der Spieler pro Team
		/// </summary>
		[IgnoreDataMember]
		public abstract int PlayerCount
		{ get; }

		#endregion
	}
}