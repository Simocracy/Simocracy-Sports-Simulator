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
	public class Stadium
	{
		#region Static Members

		/// <summary>
		/// Leeres Stadion ohne Angaben
		/// </summary>
		private static Stadium _NoStadium = new Stadium(-1, String.Empty, State.NoState, String.Empty, 0, EStadiumType.GenericStadium);

		#endregion

		#region Constructors

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
		{
			ID = id;
			Name = name;
			State = state;
			City = city;
			Capacity = capacity;
			StadiumType = stadiumType;
		}

		/// <summary>
		/// Deserialisiert einen Staat
		/// </summary>
		/// <param name="info">SerializationInfo zum deserialisieren</param>
		/// <param name="context">StreamingContext zum deserialisieren</param>
		public Stadium(SerializationInfo info, StreamingContext context)
		{
			ID = info.GetInt32("id");
			Name = info.GetString("name");

			City = info.GetString("city");
			Capacity = info.GetInt32("capacity");
			StadiumType = (EStadiumType) info.GetValue("type", typeof(EStadiumType));
		}

		#endregion

		#region Properties

		/// <summary>
		/// Leeres Stadion ohne Angaben
		/// </summary>
		public static Stadium NoStadium
		{
			get
			{
				return _NoStadium;
			}
		}

		/// <summary>
		/// ID des Stadions
		/// </summary>
		[DataMember]
		public int ID { get; private set; }

		/// <summary>
		/// Name des Stadions
		/// </summary>
		[DataMember]
		public string Name { get; private set; }

		/// <summary>
		/// Staat in dem das Stadion liegt
		/// </summary>
		//[DataMember]
		public State State { get; private set; }

		/// <summary>
		/// Stadt in dem das Stadion liegt
		/// </summary>
		[DataMember]
		public string City { get; private set; }

		/// <summary>
		/// Kapazität des Stadions
		/// </summary>
		[DataMember]
		public int Capacity { get; private set; }

		/// <summary>
		/// Typ des Stadions
		/// </summary>
		[DataMember]
		public EStadiumType StadiumType { get; private set; }

		#endregion

		#region Serialization

		/// <summary>
		/// Serialisiert ein Stadion
		/// </summary>
		/// <param name="info">SerializationInfo</param>
		/// <param name="context">StreamingContext</param>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("id", ID);
			info.AddValue("name", Name);
			info.AddValue("stateID", State.ID);
			info.AddValue("city", City);
			info.AddValue("capacity", Capacity);
			info.AddValue("type", StadiumType);
		}

		#endregion
	}
}
