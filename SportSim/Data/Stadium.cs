using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Klasse für Stadien bzw. Sporthallen, in denen Teams ihre Matches austragen
	/// </summary>
	[DataContract]
	public class Stadium : SSSDataObject
	{
		#region Members

		/// <summary>
		/// Leeres Stadion ohne Angaben
		/// </summary>
		private static Stadium _NoneStadium = new Stadium(-1, String.Empty, State.NoneState, String.Empty, 0, EStadiumType.GenericStadium);

		private State _State;
		private int _StateID;

		#endregion

		#region Constructors

		/// <summary>
		/// Erstellt ein neues Stadion
		/// </summary>
		/// <param name="id">ID des Stadions</param>
		/// <param name="name">Name des Stadions</param>
		public Stadium(int id, string name)
			: this(id, name, State.NoneState, String.Empty, 0, EStadiumType.GenericStadium)
		{ }

		/// <summary>
		/// Erstellt ein neues Stadion
		/// </summary>
		/// <param name="id">ID des Stadions</param>
		/// <param name="name">Name des Stadions</param>
		/// <param name="state">Staat in dem das Stadion liegt</param>
		/// <param name="city">Stadt in dem das Stadion liegt</param>
		/// <param name="capacity">Kapazität des Stadions</param>
		/// <param name="stadiumType">Typ des Stadions</param>
		public Stadium(int id, string name, State state, string city, int capacity, EStadiumType stadiumType)
			: base(id, name)
		{
			State = state;
			City = city;
			Capacity = capacity;
			StadiumType = stadiumType;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Leeres Stadion ohne Angaben
		/// </summary>
		public static Stadium NoneStadium
		{
			get
			{
				return _NoneStadium;
			}
		}

		/// <summary>
		/// Staat in dem das Stadion liegt
		/// </summary>
		[IgnoreDataMember]
		public State State
		{
			get { return _State; }
			private set
			{
				_State = value;
				_StateID = value.ID;
			}
		}

		/// <summary>
		/// Staat-ID in dem das Stadion liegt
		/// </summary>
		[DataMember(Order = 100)]
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
		/// Stadt in dem das Stadion liegt
		/// </summary>
		[DataMember(Order = 110)]
		public string City { get; private set; }

		/// <summary>
		/// Kapazität des Stadions
		/// </summary>
		[DataMember(Order = 120)]
		public int Capacity { get; private set; }

		/// <summary>
		/// Typ des Stadions
		/// </summary>
		[DataMember(Order = 130)]
		public EStadiumType StadiumType { get; private set; }

		#endregion
	}
}
