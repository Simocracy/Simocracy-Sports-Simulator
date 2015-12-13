using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Klasse für Staaten in Simocracy
	/// </summary>
	[DataContract]
	public class State
	{
		#region Members

		/// <summary>
		/// Leerer Staat ohne Angaben
		/// </summary>
		private static State _NoState = new State(-1, String.Empty, String.Empty);

		#endregion

		#region Constructors

		/// <summary>
		/// Erstellt einen neuen Staat
		/// </summary>
		/// <param name="id">ID des Staates</param>
		/// <param name="name">Name des Staates</param>
		/// <param name="flag">Flaggenkürzel des Staates</param>
		public State(int id, string name, string flag)
		{
			ID = id;
			Name = name;
			Flag = flag;
		}

		/// <summary>
		/// Deserialisiert einen Staat
		/// </summary>
		/// <param name="info">SerializationInfo zum deserialisieren</param>
		/// <param name="context">StreamingContext zum deserialisieren</param>
		public State(SerializationInfo info, StreamingContext context)
		{
			ID = info.GetInt32("id");
			Name = info.GetString("name");
			Flag = info.GetString("flag");
		}

		#endregion

		#region Properties

		/// <summary>
		/// Leerer Staat ohne Angaben
		/// </summary>
		public static State NoState
		{
			get
			{
				return _NoState;
			}
		}

		/// <summary>
		/// ID des Staates
		/// </summary>
		[DataMember]
		public int ID { get; private set; }

		/// <summary>
		/// Name des Staates
		/// </summary>
		[DataMember]
		public string Name { get; private set; }

		/// <summary>
		/// Flaggenkürzel des Staates
		/// </summary>
		[DataMember]
		public string Flag { get; private set; }

		#endregion

		#region Serialization

		/// <summary>
		/// Serialisiert einen Staat
		/// </summary>
		/// <param name="info">SerializationInfo</param>
		/// <param name="context">StreamingContext</param>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("id", ID);
			info.AddValue("name", Name);
			info.AddValue("flag", Flag);
		}

		#endregion
	}
}
