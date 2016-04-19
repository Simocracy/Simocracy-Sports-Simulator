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
	/// Interaktionslogik für ManageLeagueWikiTemplatesPage.xaml
	/// </summary>
	public partial class ManageLeagueWikiTemplatesPage : Page, INotifyPropertyChanged
	{
		public ManageLeagueWikiTemplatesPage()
		{
			InitializeComponent();
			DataContext = this;
			Settings.LogPageOpened(this);

#if !DEBUG
			DebugIDLabel.Visibility = Visibility.Collapsed;
#endif
		}

		private bool _IsInNewMode;
		private LeagueWikiTemplate _SelectedTemplate;

		public LeagueWikiTemplate SelectedTemplate
		{
			get { return _SelectedTemplate; }
			set
			{
				_SelectedTemplate = value;
				MarkAllValid();
				_IsInNewMode = false;
				Notify("SelectedTemplate");
			}
		}

		private void ClearInputs()
		{
			MarkAllValid();

			DebugIDLabel.ClearValue(Label.ContentProperty);
			NameTextBox.Clear();
			LeagueSizeTextBox.Clear();
			IsDateCheckBox.ClearValue(CheckBox.IsCheckedProperty);
			IsLocationCheckBox.ClearValue(CheckBox.IsCheckedProperty);
			WikiCodeTextBox.Clear();
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

			int size;
			if(String.IsNullOrEmpty(LeagueSizeTextBox.Text) || !Int32.TryParse(LeagueSizeTextBox.Text, out size))
			{
				isAllValid = false;
				MarkWrongInput(LeagueSizeTextBox);
			}

			if(String.IsNullOrEmpty(WikiCodeTextBox.Text))
			{
				isAllValid = false;
				MarkWrongInput(WikiCodeTextBox);
			}

			return isAllValid;
		}

		private void SaveData()
		{
			SelectedTemplate = WikiHelper.ParseLeagueTemplate(WikiCodeTextBox.Text, SelectedTemplate);

			Settings.LogObjSaved(SelectedTemplate);
		}

		private void Create()
		{
			Settings.LeageWikiTemplates.Add(WikiHelper.ParseLeagueTemplate(WikiCodeTextBox.Text));

			_IsInNewMode = false;
			SelectedTemplate = Settings.LeageWikiTemplates.Last();

			Settings.LogObjCreated(SelectedTemplate);
		}

		public void Delete()
		{
			Settings.LeageWikiTemplates.Remove(SelectedTemplate);
			MarkAllValid();
			_IsInNewMode = false;
			Settings.LogDeleted(SelectedTemplate);
			SelectedTemplate = null;
		}

		private void MarkAllValid()
		{
			NameTextBox.ClearValue(Control.StyleProperty);
			LeagueSizeTextBox.ClearValue(Control.StyleProperty);
			IsDateCheckBox.ClearValue(Control.StyleProperty);
			IsLocationCheckBox.ClearValue(Control.StyleProperty);
			WikiCodeTextBox.Style = Application.Current.TryFindResource("ManageMultiline") as Style;
		}

		private void MarkWrongInput(Control control)
		{
			if(control.Style != Application.Current.TryFindResource("ManageMultiline") as Style)
				control.Style = Application.Current.TryFindResource("InvalidInput") as Style;
			else
				control.Style = Application.Current.TryFindResource("InvalidInputMultiline") as Style;
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
				if(_IsInNewMode || SelectedTemplate == null)
					Create();
				else
					SaveData();

				MarkAllValid();
			}
		}

		private void TemplatesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			MarkAllValid();
			_IsInNewMode = false;
		}

		// Observer
		public event PropertyChangedEventHandler PropertyChanged;
		protected void Notify(String propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
