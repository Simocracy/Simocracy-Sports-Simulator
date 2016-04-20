using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
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
			// Setup logger
			Settings.SetupLogger();
			SimpleLog.Check(String.Format("{0} {1} {2}", Settings.ProgramName, Settings.ProgramVersion, "started"));

			// Load Settings
			Settings.LoadSettings();

			// Open MainWindow
			App app = new App();
			try
			{
				app.InitializeComponent();
				MainWindow window = new MainWindow();
				app.Run(window);
			}
			catch(Exception e)
			{
				SimpleLog.Log(e);
			}

			app.Shutdown();
			SimpleLog.Info(String.Format("{0} {1} {2}", Settings.ProgramName, Settings.ProgramVersion, "closed"));
			SimpleLog.Flush();
			SimpleLog.StopLogging();
		}
	}
}
