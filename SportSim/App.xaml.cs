using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Interaktionslogik für "App.xaml"
	/// </summary>
	public partial class App : Application
	{
		/// <summary>
		/// Main-Methode
		/// </summary>
		[STAThread]
		public static void Main()
		{
			// Load Settings
			// not yet
			// Settings.Load();


			////var application = new App();
			////application.InitializeComponent();
			////application.Run();

			var staat = new State(7, "Teststaat", "Testflagge");
			var stadion = new Stadium(5, "teststadion", staat, "teststadt", 123456, EStadiumType.GenericStadium);
			var team = new FootballTeam(12, "testteam", "testlogo", 2, 3, 4, 5, staat, stadion);

			Settings.States = new StateCollection();
			Settings.States.Add(staat);
			staat = new State(6, "Teststaat2", "Testflagge2");
			Settings.States.Add(staat);

			Settings.Stadiums = new StadiumCollection();
			Settings.Stadiums.Add(stadion);

			Settings.FootballTeams = new FootballTeamCollection();
			Settings.FootballTeams.Add(team);

			////using(FileStream writer = new FileStream("file.xml", FileMode.Create, FileAccess.Write))
			////{
			////	DataContractSerializer ser = new DataContractSerializer(typeof(FootballTeamCollection));
			////	ser.WriteObject(writer, Settings.FootballTeams);
			////}
			////FootballTeamCollection loadObj;
			////using(FileStream reader = new FileStream("file.xml", FileMode.Open, FileAccess.Read))
			////{
			////	DataContractSerializer ser = new DataContractSerializer(typeof(FootballTeamCollection));
			////	loadObj = (FootballTeamCollection) ser.ReadObject(reader);
			////}
			//Settings.Save();



			// Open MainWindow
			App app = new App();
			MainWindow window = new MainWindow();
			app.Run(window);
		}
	}
}
