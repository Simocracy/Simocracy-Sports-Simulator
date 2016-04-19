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
	public partial class ManageStadiumsPage : Page, INotifyPropertyChanged
	{
		public ManageStadiumsPage()
		{
			InitializeComponent();
			DataContext = this;

			_IsInNewMode = false;
			Settings.LogPageOpened(this);

#if !DEBUG
			DebugIDLabel.Visibility = Visibility.Collapsed;
#endif
		}

		private bool _IsInNewMode;
		private Stadium _SelectedStadium;

		public Stadium SelectedStadium
		{
			get { return _SelectedStadium; }
			set
			{
				_SelectedStadium = value;
				MarkAllValid();
				_IsInNewMode = false;
				Notify("SelectedStadium");
			}
		}

		private void ClearInputs()
		{
			MarkAllValid();

			DebugIDLabel.ClearValue(Label.ContentProperty);
			NameTextBox.Clear();
			CityTextBox.Clear();
			CapacityIntTextBox.Clear();
			CapacityNatTextBox.Clear();
			StateComboBox.ClearValue(ComboBox.SelectedValueProperty);
			TypeComboBox.ClearValue(ComboBox.SelectedValueProperty);
		}

		private bool ValidateInputs()
		{
			MarkAllValid();
			bool isAllValid = true;

			if(String.IsNullOrEmpty(NameTextBox.Text))
			{
				isAllValid = false;
				MarkWrongInput(NameTextBox);
			}

			if(String.IsNullOrEmpty(CityTextBox.Text))
			{
				isAllValid = false;
				MarkWrongInput(CityTextBox);
			}

			if(StateComboBox.SelectedIndex < 0)
			{
				isAllValid = false;
				MarkWrongInput(StateComboBox);
			}

			if(TypeComboBox.SelectedIndex < 0)
			{
				isAllValid = false;
				MarkWrongInput(TypeComboBox);
			}

			int cap;
			if(String.IsNullOrEmpty(CapacityIntTextBox.Text) || !Int32.TryParse(CapacityIntTextBox.Text, out cap))
			{
				isAllValid = false;
				MarkWrongInput(CapacityIntTextBox);
			}
			
			if(!String.IsNullOrEmpty(CapacityNatTextBox.Text) && !Int32.TryParse(CapacityNatTextBox.Text, out cap))
			{
				isAllValid = false;
				MarkWrongInput(CapacityNatTextBox);
			}

			return isAllValid;
		}

		private void SaveData()
		{
			SelectedStadium.Name = NameTextBox.Text;
			SelectedStadium.City = CityTextBox.Text;
			SelectedStadium.CapacityInt = Int32.Parse(CapacityIntTextBox.Text);
			SelectedStadium.CapacityNat = (String.IsNullOrEmpty(CapacityNatTextBox.Text)) ? 0 : Convert.ToInt32(CapacityNatTextBox.Text);
			SelectedStadium.State = (State) StateComboBox.SelectedItem;
			SelectedStadium.StadiumType = (EStadiumType) Enum.Parse(typeof(EStadiumType), TypeComboBox.SelectedValue.ToString());

			Settings.LogObjSaved(SelectedStadium);
		}

		private void Create()
		{
			Settings.Stadiums.Create(
				NameTextBox.Text,
				(State) StateComboBox.SelectedItem,
				CityTextBox.Text,
				Convert.ToInt32(CapacityIntTextBox.Text),
				(String.IsNullOrEmpty(CapacityNatTextBox.Text)) ? 0 : Convert.ToInt32(CapacityNatTextBox.Text),
				(EStadiumType) Enum.Parse(typeof(EStadiumType), TypeComboBox.SelectedValue.ToString()));

			_IsInNewMode = false;
			SelectedStadium = Settings.Stadiums.Last();

			Settings.LogObjCreated(SelectedStadium);
		}

		public void Delete()
		{
			Settings.Stadiums.Remove(SelectedStadium);
			MarkAllValid();
			_IsInNewMode = false;
			Settings.LogDeleted(SelectedStadium);
			SelectedStadium = null;
		}

		private void MarkAllValid()
		{
			NameTextBox.ClearValue(Control.StyleProperty);
			CityTextBox.ClearValue(Control.StyleProperty);
			CapacityIntTextBox.ClearValue(Control.StyleProperty);
			CapacityNatTextBox.ClearValue(Control.StyleProperty);
			StateComboBox.ClearValue(Control.StyleProperty);
			TypeComboBox.ClearValue(Control.StyleProperty);
		}

		private void MarkWrongInput(Control control)
		{
			control.Style = Application.Current.TryFindResource("InvalidInput") as Style;
		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			Settings.LogButtonClicked(sender as Button);
			Delete();
		}

		private void NewButton_Click(object sender, RoutedEventArgs e)
		{
			Settings.LogButtonClicked(sender as Button);
			ClearInputs();
			NameTextBox.Focus();
			_IsInNewMode = true;
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			Settings.LogButtonClicked(sender as Button);
			if(ValidateInputs())
			{
				if(_IsInNewMode || SelectedStadium == null)
					Create();
				else
					SaveData();

				MarkAllValid();
			}
		}

		private void StadiumsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			MarkAllValid();
			_IsInNewMode = false;
		}

		// Observer
		public event PropertyChangedEventHandler PropertyChanged;
		protected void Notify([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
