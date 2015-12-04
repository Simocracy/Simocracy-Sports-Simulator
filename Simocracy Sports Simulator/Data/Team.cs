using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Simocracy.SportSim.Data
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
		/// <param name="name">Name des Teams</param>
		public Team(string name)
			: this(name, String.Empty)
		{ }

		/// <summary>
		/// Erstellt ein neues Team
		/// </summary>
		/// <param name="name">Name des Teams</param>
		/// <param name="logo">Name der Logodatei</param>
		public Team(string name, string logo)
		{
			Name = name;
			LogoFileName = logo;
		}

		#endregion

		#region Properties

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