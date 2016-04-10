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
			Settings.LoadSettings();

			// Open MainWindow
			App app = new App();
			app.InitializeComponent();
			MainWindow window = new MainWindow();
			app.Run(window);
		}
	}
}
