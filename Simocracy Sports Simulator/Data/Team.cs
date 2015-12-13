using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Abstrakte Basisklasse für Teams
	/// </summary>
	public abstract class Team
	{
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
		public int ID
		{ get; set; }

		/// <summary>
		/// Name des Teams
		/// </summary>
		public string Name
		{ get; set; }

		/// <summary>
		/// Dateiname des Logos im Wiki
		/// </summary>
		public string LogoFileName
		{ get; set; }

		/// <summary>
		/// Staat des Teams
		/// </summary>
		public State State
		{ get; set; }

		/// <summary>
		/// Stadion des Teams
		/// </summary>
		public Stadium Stadium
		{ get; set; }

		/// <summary>
		/// Gesamtstärke des Teams
		/// </summary>
		public abstract int Strength
		{ get; }

		/// <summary>
		/// Durchschnittsstärke eines Spielers
		/// </summary>
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
		public abstract int PlayerCount
		{ get; }

		#endregion
	}
}