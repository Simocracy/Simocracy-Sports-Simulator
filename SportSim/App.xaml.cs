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
			Settings.LoadXml();


			////var application = new App();
			////application.InitializeComponent();
			////application.Run();

			//var staat = new State(7, "Teststaat", "Testflagge", Continent.Europe);
			//var stadion = new Stadium(5, "teststadion", staat, "teststadt", 123456, EStadiumType.GenericStadium);
			//var team = new FootballTeam(12, "testteam", "testlogo", false, 2, 3, 4, 5, staat, stadion);

			//Settings.States = new StateCollection();
			//Settings.States.Add(staat);
			//staat = new State(6, "Teststaat2", "Testflagge2", Continent.America);
			//Settings.States.Add(staat);

			//Settings.Stadiums = new StadiumCollection();
			//Settings.Stadiums.Add(stadion);

			//Settings.FootballTeams = new FootballTeamCollection();
			//Settings.FootballTeams.Add(team);
			//team = new FootballTeam(12, "testteam2", "testlogo2", true, 2, 3, 4, 5, staat, stadion);
			//Settings.FootballTeams.Add(team);

			//Settings.Save();



			// Open MainWindow
			App app = new App();
			app.InitializeComponent();
			MainWindow window = new MainWindow();
			app.Run(window);
		}
	}
}
