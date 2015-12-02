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
				return Strength / 11;
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