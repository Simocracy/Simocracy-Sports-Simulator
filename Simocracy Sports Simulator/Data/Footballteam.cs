using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simocracy.SportSim.Data
{
	/// <summary>
	/// Fussballteam
	/// </summary>
	public class Footballteam : Team
	{

		#region Properties

		/// <summary>
		/// Gesamtstärke des Teams
		/// </summary>
		public override int Strength
		{
			get
			{
				return GoalkeeperStrength + DefenseStrength + MidfieldStrength + ForwardStrength;
			}
		}

		/// <summary>
		/// Anzahl der Spieler pro Team
		/// </summary>
		public override int PlayerCount
		{
			get
			{
				return 11;
			}
		}

		/// <summary>
		/// Stärke des Torhüters
		/// </summary>
		public int GoalkeeperStrength
		{ get; set; }

		/// <summary>
		/// Stärke der Verteidigung
		/// </summary>
		public int DefenseStrength
		{ get; set; }

		/// <summary>
		/// Stärke des Mittelfelds
		/// </summary>
		public int MidfieldStrength
		{ get; set; }

		/// <summary>
		/// Stärke der Stürmer
		/// </summary>
		public int ForwardStrength
		{ get; set; }

		#endregion
	}
}