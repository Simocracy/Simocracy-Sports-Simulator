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
	public abstract class Team : IExtensibleDataObject
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
		/// <param name="logo">Name der Logodatei</param>
		public Team(int id, string name, string logo)
			: this(id, name, logo, null, null)
		{ }

		/// <summary>
		/// Erstellt ein neues Team
		/// </summary>
		/// <param name="id">ID des Teams</param>
		/// <param name="name">Name des Teams</param>
		/// <param name="logo">Name der Logodatei</param>
		/// <param name="state">Staat des Teams</param>
		/// <param name="stadium">Stadion des Teams</param>
		public Team(int id, string name, string logo, State state, Stadium stadium)
		{
			ID = id;
			Name = name;
			LogoFileName = logo;
			State = state;
			Stadium = stadium;
		}

		#endregion

		#region Properties

		/// <summary>
		/// ID des Teams
		/// </summary>
		[DataMember(Order = 10)]
		public int ID
		{ get; set; }

		/// <summary>
		/// Name des Teams
		/// </summary>
		[DataMember(Order = 20)]
		public string Name
		{ get; set; }

		/// <summary>
		/// Dateiname des Logos im Wiki
		/// </summary>
		[DataMember(Order = 30)]
		public string LogoFileName
		{ get; set; }

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
		[DataMember(Order = 40)]
		private int StateID
		{
			get { return _StateID; }
			set
			{
				_StateID = value;
				_State = Settings.States.Get(value);
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
		[DataMember(Order = 50)]
		private int StadiumID
		{
			get { return _StadiumID; }
			set
			{
				_StadiumID = value;
				_Stadium = Settings.Stadiums.Get(value);
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

		#region IExtensibleDataObject

		/// <summary>
		/// Erweiterungsdaten
		/// </summary>
		public ExtensionDataObject ExtensionData { get; set; }

		#endregion
	}
}