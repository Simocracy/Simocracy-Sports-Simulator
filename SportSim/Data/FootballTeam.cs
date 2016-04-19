using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Fussballteam
	/// </summary>
	[DataContract]
	[DebuggerDisplay("FootballTeam, Name={Name}, State={State.Name}, Stadium={Stadium.Name}")]
	public class FootballTeam : Team
	{

		#region Members

		private int _GoalkeeperStrength;
		private int _DefenseStrength;
		private int _MidfieldStrength;
		private int _ForwardStrength;

		#endregion

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
		/// <param name="logo">Logo des Teams</param>
		/// <param name="isExternLogo">Angabe ob Logo extern (=nicht im Wiki) hochgeladen ist</param>
		/// <param name="goalkeeperStrength">Stärke des Torhüters</param>
		/// <param name="defenseStrength">Stärke der Verteidigung</param>
		/// <param name="midfieldStrength">Stärke des Mittelfelds</param>
		/// <param name="forwardStrength">Stärke der Offensive</param>
		public FootballTeam(int id, string name, string logo, int goalkeeperStrength, int defenseStrength, int midfieldStrength, int forwardStrength)
			: this(id, name, logo, goalkeeperStrength, defenseStrength, midfieldStrength, forwardStrength, State.NoneState, Stadium.NoneStadium)
		{ }

		/// <summary>
		/// Erstellt ein neues Fußballteam
		/// </summary>
		/// <param name="name">Name des Teams</param>
		/// <param name="logo">Logo des Teams</param>
		/// <param name="isExternLogo">Angabe ob Logo extern (=nicht im Wiki) hochgeladen ist</param>
		/// <param name="goalkeeperStrength">Stärke des Torhüters</param>
		/// <param name="defenseStrength">Stärke der Verteidigung</param>
		/// <param name="midfieldStrength">Stärke des Mittelfelds</param>
		/// <param name="forwardStrength">Stärke der Offensive</param>
		/// <param name="state">Staat des Teams</param>
		/// <param name="stadium">Stadion des Teams</param>
		public FootballTeam(int id, string name, string logo, int goalkeeperStrength, int defenseStrength, int midfieldStrength, int forwardStrength, State state, Stadium stadium)
			: base(id, name, logo, state, stadium)
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
			get { return 11; }
		}

		/// <summary>
		/// Stärke des Torhüters
		/// </summary>
		[DataMember(Order = 1000)]
		public int GoalkeeperStrength
		{
			get { return _GoalkeeperStrength; }
			set { _GoalkeeperStrength = value; Notify(); }
		}

		/// <summary>
		/// Stärke der Verteidigung
		/// </summary>
		[DataMember(Order = 1010)]
		public int DefenseStrength
		{
			get { return _DefenseStrength; }
			set { _DefenseStrength = value; Notify(); }
		}

		/// <summary>
		/// Stärke des Mittelfelds
		/// </summary>
		[DataMember(Order = 1020)]
		public int MidfieldStrength
		{
			get { return _MidfieldStrength; }
			set { _MidfieldStrength = value; Notify(); }
		}

		/// <summary>
		/// Stärke der Stürmer
		/// </summary>
		[DataMember(Order = 1030)]
		public int ForwardStrength
		{
			get { return _ForwardStrength; }
			set { ForwardStrength = value; Notify(); }
		}

		#endregion

		#region Overrided Methods

		/// <summary>
		/// Gibt einen <see cref="String"/> zurück, der das Objekt darstellt.
		/// </summary>
		/// <returns>Objekt als String</returns>
		public override string ToString()
		{
			return String.Format("{0} {1}={2} {3}={4} {5}={6} {7}={8}", base.ToString(),
				nameof(GoalkeeperStrength), GoalkeeperStrength, nameof(DefenseStrength), DefenseStrength,
				nameof(MidfieldStrength), MidfieldStrength, nameof(ForwardStrength), ForwardStrength);
		}

		#endregion
	}
}