using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Fussballteam
	/// </summary>
	public class FootballTeam : Team
	{

		#region Constructors

		/// <summary>
		/// Erstellt ein neues Fußballteam
		/// </summary>
		/// <param name="name"></param>
		public FootballTeam(int id, string name)
			: this(id, name, String.Empty, 0, 0, 0, 0)
		{ }

		/// <summary>
		/// Erstellt ein neues Fußballteam
		/// </summary>
		/// <param name="name">Name des Teams</param>
		/// <param name="goalkeeperStrength">Stärke des Torhüters</param>
		/// <param name="defenseStrength">Stärke der Verteidigung</param>
		/// <param name="midfieldStrength">Stärke des Mittelfelds</param>
		/// <param name="forwardStrength">Stärke der Offensive</param>
		public FootballTeam(int id, string name, int goalkeeperStrength, int defenseStrength, int midfieldStrength, int forwardStrength)
			: this(id, name, String.Empty, goalkeeperStrength, defenseStrength, midfieldStrength, forwardStrength)
		{ }

		/// <summary>
		/// Erstellt ein neues Fußballteam
		/// </summary>
		/// <param name="name">Name des Teams</param>
		/// <param name="logo">Name der Logodatei</param>
		/// <param name="goalkeeperStrength">Stärke des Torhüters</param>
		/// <param name="defenseStrength">Stärke der Verteidigung</param>
		/// <param name="midfieldStrength">Stärke des Mittelfelds</param>
		/// <param name="forwardStrength">Stärke der Offensive</param>
		public FootballTeam(int id, string name, string logo, int goalkeeperStrength, int defenseStrength, int midfieldStrength, int forwardStrength)
			: base(id, name, logo)
		{
			GoalkeeperStrength = goalkeeperStrength;
			DefenseStrength = defenseStrength;
			MidfieldStrength = midfieldStrength;
			ForwardStrength = forwardStrength;
		}

		#endregion

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