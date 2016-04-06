﻿using System;
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

		#region Members

		private static string _ZipFileName = "data.zip"; // TODO: Dateiformat in .sss benennen

		private static string _FootballTeamsFileName = "footballTeams";
		private static string _StatesFileName = "states";
		private static string _StadiumsFileName = "stadiums";

		#endregion

		#region Saving Loading

		/// <summary>
		/// Speichert die aktuellen Einstellungen im XML-Format
		/// </summary>
		public static void Save()
		{
			try
			{
				var streams = new Dictionary<string, MemoryStream>();
				DataContractSerializer ser;

				// States
				var statesStream = new MemoryStream();
				ser = new DataContractSerializer(typeof(StateCollection));
				ser.WriteObject(statesStream, States);
				streams.Add(_StatesFileName, statesStream);

				// Stadiums
				var stadiumsStream = new MemoryStream();
				ser = new DataContractSerializer(typeof(StadiumCollection));
				ser.WriteObject(stadiumsStream, Stadiums);
				streams.Add(_StadiumsFileName, stadiumsStream);

				// FootballTeams
				var footbalTeamStream = new MemoryStream();
				ser = new DataContractSerializer(typeof(FootballTeamCollection));
				ser.WriteObject(footbalTeamStream, FootballTeams);
				streams.Add(_FootballTeamsFileName, footbalTeamStream);


				// Save as Zip
				ZipFileHelper.SaveZipFile(_ZipFileName, streams);
			}
			catch(Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e);
			}
		}

		/// <summary>
		/// Speichert die aktuellen Einstellungen im JSON-Format
		/// </summary>
		public static void SaveJson()
		{
			try
			{
				var streams = new Dictionary<string, MemoryStream>();
				DataContractJsonSerializer ser;

				// States
				var statesStream = new MemoryStream();
				ser = new DataContractJsonSerializer(typeof(StateCollection));
				ser.WriteObject(statesStream, States);
				streams.Add(_StatesFileName, statesStream);

				// Stadiums
				var stadiumsStream = new MemoryStream();
				ser = new DataContractJsonSerializer(typeof(StadiumCollection));
				ser.WriteObject(stadiumsStream, Stadiums);
				streams.Add(_StadiumsFileName, stadiumsStream);

				// FootballTeams
				var footbalTeamStream = new MemoryStream();
				ser = new DataContractJsonSerializer(typeof(FootballTeamCollection));
				ser.WriteObject(footbalTeamStream, FootballTeams);
				streams.Add(_FootballTeamsFileName, footbalTeamStream);


				// Save as Zip
				ZipFileHelper.SaveZipFile(_ZipFileName, streams);
			}
			catch(Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e);
			}
		}

		public static async void Load()
		{
			try
			{
				// Load Zip
				var streams = await ZipFileHelper.LoadZipFile(_ZipFileName);
				DataContractSerializer ser;

				// States
				streams[_StatesFileName].Position = 0;
				ser = new DataContractSerializer(typeof(StateCollection));
				States = (StateCollection) ser.ReadObject(streams[_StatesFileName]);

				// Stadiums
				streams[_StadiumsFileName].Position = 0;
				ser = new DataContractSerializer(typeof(StadiumCollection));
				Stadiums = (StadiumCollection) ser.ReadObject(streams[_StadiumsFileName]);

				// Football Teams
				streams[_FootballTeamsFileName].Position = 0;
				ser = new DataContractSerializer(typeof(FootballTeamCollection));
				FootballTeams = (FootballTeamCollection) ser.ReadObject(streams[_FootballTeamsFileName]);
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
