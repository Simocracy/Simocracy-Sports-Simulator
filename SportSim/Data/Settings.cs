using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Statische Einstellungsklasse des ganzen SportSim
	/// </summary>
	[DataContract]
	public static class Settings
	{

		#region Lists

		/// <summary>
		/// Liste aller Fussballteams
		/// </summary>
		[IgnoreDataMember]
		public static FootballTeamCollection FootballTeams { get; set; }

		/// <summary>
		/// Liste aller Staaten
		/// </summary>
		[IgnoreDataMember]
		public static StateCollection States { get; set; }

		/// <summary>
		/// Liste aller Stadien
		/// </summary>
		[IgnoreDataMember]
		public static StadiumCollection Stadiums { get; set; }

		#endregion

		#region Saving Loading

		/// <summary>
		/// Speichert die aktuellen Einstellungen
		/// </summary>
		public static void Save()
		{
			var streams = new List<Tuple<string, MemoryStream>>();

			// FootballTeams
			var footballTeamStream = Tuple.Create("footballTeams", new MemoryStream());
			DataContractSerializer ser = new DataContractSerializer(typeof(FootballTeamCollection));
			ser.WriteObject(footballTeamStream.Item2, FootballTeams);
			streams.Add(footballTeamStream);

			// States
			var statesStream = Tuple.Create("states", new MemoryStream());
			ser = new DataContractSerializer(typeof(StateCollection));
			ser.WriteObject(statesStream.Item2, States);
			streams.Add(statesStream);

			// States
			var stadiumsStream = Tuple.Create("states", new MemoryStream());
			ser = new DataContractSerializer(typeof(StadiumCollection));
			ser.WriteObject(stadiumsStream.Item2, Stadiums);
			streams.Add(stadiumsStream);


			// Save as Zip
			ZipFileHelper.SaveZipFile("test.zip", streams.ToArray()); // TODO korrekter Dateiname

		}

		#endregion

	}
}
