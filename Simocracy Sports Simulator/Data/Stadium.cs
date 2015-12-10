using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim.Data
{
	/// <summary>
	/// Klasse für Stadien bzw. Sporthallen, in denen Teams ihre Matches austragen
	/// </summary>
	public class Stadium
	{
		#region Static Members

		private static Stadium _NoStadium = new Stadium(String.Empty, State.NoState, String.Empty, 0, EStadiumTye.GenericStadium);

		#endregion

		#region Constructors

		/// <summary>
		/// Erstellt ein neues Stadion
		/// </summary>
		/// <param name="name"></param>
		/// <param name="state"></param>
		/// <param name="city"></param>
		/// <param name="capacity"></param>
		public Stadium(string name, State state, string city, int capacity, EStadiumTye type)
		{
			Name = name;
			State = state;
			City = city;
			Capacity = capacity;
			Type = type;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Leerer Staat ohne Angaben
		/// </summary>
		public static Stadium NoStadium
		{
			get
			{
				return _NoStadium;
			}
		}

		/// <summary>
		/// Name des Stadions
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Staat in dem das Stadion liegt
		/// </summary>
		public State State { get; private set; }

		/// <summary>
		/// Stadt in dem das Stadion liegt
		/// </summary>
		public string City { get; private set; }

		/// <summary>
		/// Kapazität des Stadions
		/// </summary>
		public int Capacity { get; private set; }

		/// <summary>
		/// Typ des Stadions
		/// </summary>
		public EStadiumTye Type { get; private set; }

		#endregion
	}
}
