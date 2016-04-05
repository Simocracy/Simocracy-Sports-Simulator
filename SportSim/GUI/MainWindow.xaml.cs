using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		#region Constructor

		public MainWindow()
		{
			InitializeComponent();
		}

		#endregion

		#region Menu Commands

		/// <summary>
		/// Daten speichern
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _MenuItemSave_Click(object sender, RoutedEventArgs e)
		{
			Settings.Save();
		}

		/// <summary>
		/// Teamverwaltung öffnen
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _MenuItemTeams_Click(object sender, RoutedEventArgs e)
		{

		}

		/// <summary>
		/// Stadionverwaltung öffnen
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _MenuItemStadiums_Click(object sender, RoutedEventArgs e)
		{
			_MainFrame.Content = new ManageStadiumsPage();
		}

		/// <summary>
		/// Staatenverwaltung öffnen
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _MenuItemStates_Click(object sender, RoutedEventArgs e)
		{
			_MainFrame.Content = new ManageStatesPage();
		}

		/// <summary>
		/// Fußballliga simulieren
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _MenuItemFootballLeague_Click(object sender, RoutedEventArgs e)
		{

		}

		/// <summary>
		/// Fußballturnier simulieren
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _MenuItemFootballTournament_Click(object sender, RoutedEventArgs e)
		{

		}

		#endregion
	}
}
