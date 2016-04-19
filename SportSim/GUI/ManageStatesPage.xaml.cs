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
	/// Interaktionslogik für ManageStatesPage.xaml
	/// </summary>
	public partial class ManageStatesPage : Page, INotifyPropertyChanged
	{
		public ManageStatesPage()
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
		private State _SelectedState;

		public State SelectedState
		{
			get { return _SelectedState; }
			set
			{
				_SelectedState = value;
				MarkAllValid();
				_IsInNewMode = false;
				Notify("SelectedState");
			}
		}

		private void ClearInputs()
		{
			MarkAllValid();

			DebugIDLabel.ClearValue(Label.ContentProperty);
			NameTextBox.Clear();
			FlagTextBox.Clear();
			ContinentComboBox.ClearValue(ComboBox.SelectedValueProperty);
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

			if(String.IsNullOrEmpty(FlagTextBox.Text))
			{
				isAllValid = false;
				MarkWrongInput(FlagTextBox);
			}

			if(ContinentComboBox.SelectedIndex < 0)
			{
				isAllValid = false;
				MarkWrongInput(ContinentComboBox);
			}

			return isAllValid;
		}

		private void SaveData()
		{
			SelectedState.Name = NameTextBox.Text;
			SelectedState.Flag = FlagTextBox.Text;
			SelectedState.Continent = (EContinent) Enum.Parse(typeof(EContinent), ContinentComboBox.SelectedValue.ToString());

			Settings.LogObjSaved(SelectedState);
		}

		private void Create()
		{
			Settings.States.Create(
				NameTextBox.Text,
				FlagTextBox.Text,
				(EContinent) Enum.Parse(typeof(EContinent), ContinentComboBox.SelectedValue.ToString()));

			_IsInNewMode = false;
			SelectedState = Settings.States.Last();

			Settings.LogObjCreated(SelectedState);
		}

		private void Delete()
		{
			Settings.States.Remove(SelectedState);
			MarkAllValid();
			_IsInNewMode = false;
			Settings.LogDeleted(SelectedState);
			SelectedState = null;
		}

		private void MarkAllValid()
		{
			NameTextBox.ClearValue(Control.StyleProperty);
			FlagTextBox.ClearValue(Control.StyleProperty);
			ContinentComboBox.ClearValue(Control.StyleProperty);
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
				if(_IsInNewMode || SelectedState == null)
					Create();
				else
					SaveData();

				MarkAllValid();
			}
		}

		private void StatesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
