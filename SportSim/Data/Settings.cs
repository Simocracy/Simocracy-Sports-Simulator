using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Statische Einstellungsklasse des ganzen SportSim
	/// </summary>
	[DataContract]
	public class Settings
	{

		#region Assembly Infos

		/// <summary>
		/// Gibt die aktuelle Programmversion (Major.Minor.Revision) zurück.
		/// </summary>
		public static string ProgramVersion
		{
			get
			{
				var version = Assembly.GetExecutingAssembly().GetName().Version;
				var versionString = String.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Revision);
#if DEBUG
				versionString = String.Format("{0} Debug Build", versionString);
#endif
				return versionString;
			}
		}

		/// <summary>
		/// Gibt den aktuellen Programmnamen zurück
		/// </summary>
		public static string ProgramName
		{
			get
			{
				return ((AssemblyTitleAttribute) Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyTitleAttribute))).Title;
			}
		}

		#endregion

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

		/// <summary>
		/// Basis-Strings für die Wikicode-Generierung
		/// </summary>
		/// <remarks>Werden in JSON-File definiert und über <see cref="WikiStrings"/> verfügbar gemacht.</remarks>
		[IgnoreDataMember]
		public static WikiStrings WikiStrings { get; set; } = new WikiStrings();

		#endregion
		
		#region Members

		private static string _ZipFileName = "data.zip"; // TODO: Dateiformat in .sss benennen

		private static string _FootballTeamsFileName = "footballTeams.json";
		private static string _StatesFileName = "states.json";
		private static string _StadiumsFileName = "stadiums.json";
		private static string _LeagueWikiTemplatesFileName = "leageWikiTemplates.json";
		private static string _WikiStringsFileName = "wikiStrings.json";

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
					SimpleLog.Error("Could not serialize State List");
					SimpleLog.Log(e);
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
					SimpleLog.Error("Could not serialize Stadium List");
					SimpleLog.Log(e);
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
					SimpleLog.Error("Could not serialize FootballTeam List");
					SimpleLog.Log(e);
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
					SimpleLog.Error("Could not serialize LeagueWikiTemplate List");
					SimpleLog.Log(e);
				}

				// WikiStrings
				try
				{
					var wikiStringsStream = new MemoryStream();
					ser = new DataContractJsonSerializer(typeof(WikiStrings));
					ser.WriteObject(wikiStringsStream, WikiStrings);
					streams.Add(_WikiStringsFileName, wikiStringsStream);
				}
				catch(Exception e)
				{
					SimpleLog.Error("Could not serialize WikiStrings");
					SimpleLog.Log(e);
				}


				// Save as Zip
				ZipFileHelper.SaveZipFile(_ZipFileName, streams);
			}
			catch(Exception e)
			{
				SimpleLog.Error(String.Format("{0} {1}", "Error saving Settings to", _ZipFileName));
				SimpleLog.Log(e);
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
					SimpleLog.Error("Could not read States");
					SimpleLog.Log(e);
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
					SimpleLog.Error("Could not read Stadiums");
					SimpleLog.Log(e);
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
					SimpleLog.Error("Could not read FootballTeams");
					SimpleLog.Log(e);
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
					SimpleLog.Error("Could not read LeagueWikiTemplates");
					SimpleLog.Log(e);
				}

				// WikiStrings
				try
				{
					streams[_WikiStringsFileName].Position = 0;
					ser = new DataContractJsonSerializer(typeof(WikiStrings));
					WikiStrings = (WikiStrings) ser.ReadObject(streams[_WikiStringsFileName]);
				}
				catch(Exception e)
				{
					SimpleLog.Error("Could not read WikiStrings");
					SimpleLog.Log(e);
				}
			}
			catch(Exception e)
			{
				SimpleLog.Error(String.Format("{0} {1}", "Could not read database", _ZipFileName));
				SimpleLog.Log(e);
			}
		}

		#endregion

		#region Logging

		/// <summary>
		/// Initialisiert den Logger
		/// </summary>
		public static void SetupLogger()
		{
			SimpleLog.SetLogFile(logDir:"SSS-Log", writeText: true, check:false);
		}

		/// <summary>
		/// Loggt, dass das angegebene <see cref="SSSDataObject"/> erstellt wurde.
		/// </summary>
		/// <param name="obj">Erstelltes <see cref="SSSDataObject"/></param>
		public static void LogObjCreated(SSSDataObject obj)
		{
			SimpleLog.Info(String.Format("Created: {0}", obj.ToString()));
		}

		/// <summary>
		/// Loggt, dass das angegebene <see cref="SSSDataObject"/> gespeichert wurde.
		/// </summary>
		/// <param name="obj">Gespeichertes <see cref="SSSDataObject"/></param>
		public static void LogObjSaved(SSSDataObject obj)
		{
			SimpleLog.Info(String.Format("Saved: {0}", obj.ToString()));
		}

		/// <summary>
		/// Loggt, dass das angegebene <see cref="SSSDataObject"/> gelöscht wurde.
		/// </summary>
		/// <param name="obj">Gelöschtes <see cref="SSSDataObject"/></param>
		public static void LogDeleted(SSSDataObject obj)
		{
			SimpleLog.Info(String.Format("Deleted: {0}", obj.ToString()));
		}

		/// <summary>
		/// Loggt, dass die angegebene <see cref="Page"/> geöffnet wurde.
		/// </summary>
		/// <param name="obj">Geöffnete <see cref="Page"/></param>
		public static void LogPageOpened(Page obj)
		{
			SimpleLog.Info(String.Format("Opened Page: {0}", (obj != null) ? obj.Title : "Unknown"));
		}

		/// <summary>
		/// Loggt, dass der angegebene <see cref="Button"/> angeklickt wurde.
		/// </summary>
		/// <param name="obj">Angeklickter <see cref="Button"/></param>
		public static void LogButtonClicked(Button obj)
		{
			SimpleLog.Info(String.Format("Clicked Button: {0}", (obj != null) ? obj.Content : "Unknown"));
		}

		#endregion

	}
}
