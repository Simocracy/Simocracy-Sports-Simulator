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
			//var application = new App();
			//application.InitializeComponent();
			//application.Run();

			var staat = new State(0, "Teststaat", "Testflagge");
			var stadion = new Stadium(0, "teststadion", staat, "teststadt", 123456, EStadiumType.GenericStadium);

			var staaten = new List<State>();
			staaten.Add(staat);

			var stadien = new List<Stadium>();
			stadien.Add(stadion);

			using(FileStream writer = new FileStream("file.xml", FileMode.Create, FileAccess.Write))
			//using(var writer = new System.Xml.Serialization.XmlSerializer())
			{
				DataContractSerializer ser = new DataContractSerializer(typeof(List<Stadium>));
				ser.WriteObject(writer, stadien);
			}
			List<Stadium> loadObj;
			using(FileStream reader = new FileStream("file.xml", FileMode.Open, FileAccess.Read))
			{
				DataContractSerializer ser = new DataContractSerializer(typeof(List<Stadium>));
				loadObj = (List<Stadium>) ser.ReadObject(reader);

			}
		}
	}
}
