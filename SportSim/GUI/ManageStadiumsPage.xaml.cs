using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	/// Interaktionslogik für ManageStadiumsPage.xaml
	/// </summary>
	public partial class ManageStadiumsPage : Page
	{
		public ManageStadiumsPage()
		{
			InitializeComponent();
			_IsInNewMode = false;

			TypeComboBox.ItemsSource = Enum.GetValues(typeof(EStadiumType)).Cast<EStadiumType>().Where(e => e != EStadiumType.UnknownStadium && e != EStadiumType.GenericStadium);
		}

		private bool _IsInNewMode;

		public Stadium SelectedStadium
		{
			get { return (Stadium) StadiumsList.SelectedItem; }
			set {
				StadiumsList.SelectedItem = value;
				_IsInNewMode = false;
			}
		}

		private void ClearInputs()
		{
			NameTextBox.Clear();
			CityTextBox.Clear();
			CapacityIntTextBox.Clear();
			CapacityNatTextBox.Clear();
			StateComboBox.SelectedItem = null;
			TypeComboBox.SelectedItem = null;
		}

		private bool ValidateInputs()
		{
			if(String.IsNullOrEmpty(CapacityNatTextBox.Text))
				CapacityNatTextBox.Text = "0";
			
			return true; // TODO Implement
		}

		private void SaveData()
		{
			SelectedStadium.Name = NameTextBox.Text;
			SelectedStadium.City = CityTextBox.Text;
			SelectedStadium.CapacityInt = Int32.Parse(CapacityIntTextBox.Text);
			SelectedStadium.CapacityNat = Int32.Parse(CapacityNatTextBox.Text);
			SelectedStadium.State = (State) StateComboBox.SelectedItem;
			SelectedStadium.StadiumType = (EStadiumType) TypeComboBox.SelectedItem;
		}

		private void Create()
		{
			Settings.Stadiums.Create(
				NameTextBox.Text,
				(State) StateComboBox.SelectedItem,
				CityTextBox.Text,
				Convert.ToInt32(CapacityIntTextBox.Text),
				Convert.ToInt32(CapacityNatTextBox.Text),
				(EStadiumType) TypeComboBox.SelectedItem);

			_IsInNewMode = false;
		}

		private void _DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			Settings.Stadiums.Remove(SelectedStadium);
			_IsInNewMode = false;
		}

		private void _AddButton_Click(object sender, RoutedEventArgs e)
		{
			ClearInputs();
			_IsInNewMode = true;
		}

		private void _SaveButton_Click(object sender, RoutedEventArgs e)
		{
			if(ValidateInputs())
			{
				if(_IsInNewMode)
					Create();
				else
					SaveData();
			}
		}

		private void StadiumsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			_IsInNewMode = false;
		}
	}
}
