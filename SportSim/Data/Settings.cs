using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
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
		public static FootballTeamCollection FootballTeams { get; set; } = new FootballTeamCollection();

		/// <summary>
		/// Liste aller Staaten
		/// </summary>
		[IgnoreDataMember]
		public static StateCollection States { get; set; } = new StateCollection();

		/// <summary>
		/// Liste aller Stadien
		/// </summary>
		[IgnoreDataMember]
		public static StadiumCollection Stadiums { get; set; } = new StadiumCollection();

		/// <summary>
		/// Liste aller Gruppenvorlagen im Wiki
		/// </summary>
		[IgnoreDataMember]
		public static LeagueWikiTemplateCollection LeageWikiTemplates { get; set; } = new LeagueWikiTemplateCollection();

		#endregion

		#region Members

		private static string _ZipFileName = "data.zip"; // TODO: Dateiformat in .sss benennen

		private static string _FootballTeamsFileName = "footballTeams.json";
		private static string _StatesFileName = "states.json";
		private static string _StadiumsFileName = "stadiums.json";
		private static string _LeagueWikiTemplatesFileName = "leageWikiTemplates.json";

		#endregion

		#region Saving Loading

		/// <summary>
		/// Speichert die aktuellen Einstellungen im JSON-Format
		/// </summary>
		public static void SaveSettings()
		{
			try
			{
				var streams = new Dictionary<string, MemoryStream>();
				DataContractJsonSerializer ser;

				// States
				try
				{
					var statesStream = new MemoryStream();
					ser = new DataContractJsonSerializer(typeof(StateCollection));
					ser.WriteObject(statesStream, States);
					streams.Add(_StatesFileName, statesStream);
				}
				catch(Exception e)
				{
					System.Diagnostics.Debug.WriteLine(e);
				}

				// Stadiums
				try
				{
					var stadiumsStream = new MemoryStream();
					ser = new DataContractJsonSerializer(typeof(StadiumCollection));
					ser.WriteObject(stadiumsStream, Stadiums);
					streams.Add(_StadiumsFileName, stadiumsStream);
				}
				catch(Exception e)
				{
					System.Diagnostics.Debug.WriteLine(e);
				}

				// FootballTeams
				try
				{
					var footbalTeamStream = new MemoryStream();
					ser = new DataContractJsonSerializer(typeof(FootballTeamCollection));
					ser.WriteObject(footbalTeamStream, FootballTeams);
					streams.Add(_FootballTeamsFileName, footbalTeamStream);
				}
				catch(Exception e)
				{
					System.Diagnostics.Debug.WriteLine(e);
				}

				// LeagueWikiTemplates
				try
				{
					var leagueWikiTemplateStream = new MemoryStream();
					ser = new DataContractJsonSerializer(typeof(LeagueWikiTemplateCollection));
					ser.WriteObject(leagueWikiTemplateStream, LeageWikiTemplates);
					streams.Add(_LeagueWikiTemplatesFileName, leagueWikiTemplateStream);
				}
				catch(Exception e)
				{
					System.Diagnostics.Debug.WriteLine(e);
				}


				// Save as Zip
				ZipFileHelper.SaveZipFile(_ZipFileName, streams);
			}
			catch(Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e);
			}
		}

		/// <summary>
		/// Lädt die Einstellungen im JSON-Format
		/// </summary>
		public static async void LoadSettings()
		{
			try
			{
				// Load Zip
				var streams = await ZipFileHelper.LoadZipFile(_ZipFileName);
				DataContractJsonSerializer ser;

				// States
				try
				{
					streams[_StatesFileName].Position = 0;
					ser = new DataContractJsonSerializer(typeof(StateCollection));
					States = (StateCollection) ser.ReadObject(streams[_StatesFileName]);
				}
				catch(Exception e)
				{
					System.Diagnostics.Debug.WriteLine(e);
				}

				// Stadiums
				try
				{
					streams[_StadiumsFileName].Position = 0;
					ser = new DataContractJsonSerializer(typeof(StadiumCollection));
					Stadiums = (StadiumCollection) ser.ReadObject(streams[_StadiumsFileName]);
				}
				catch(Exception e)
				{
					System.Diagnostics.Debug.WriteLine(e);
				}

				// FootballTeams
				try
				{
					streams[_FootballTeamsFileName].Position = 0;
					ser = new DataContractJsonSerializer(typeof(FootballTeamCollection));
					FootballTeams = (FootballTeamCollection) ser.ReadObject(streams[_FootballTeamsFileName]);
				}
				catch(Exception e)
				{
					System.Diagnostics.Debug.WriteLine(e);
				}

				// LeagueWikiTemplates
				try
				{
					streams[_LeagueWikiTemplatesFileName].Position = 0;
					ser = new DataContractJsonSerializer(typeof(LeagueWikiTemplateCollection));
					LeageWikiTemplates = (LeagueWikiTemplateCollection) ser.ReadObject(streams[_LeagueWikiTemplatesFileName]);
				}
				catch(Exception e)
				{
					System.Diagnostics.Debug.WriteLine(e);
				}
			}
			catch(Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e);
			}
		}

		#endregion

		#region Logging

		// TODO: Implement Logging

		#endregion

	}
}
