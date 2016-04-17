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
	/// Interaktionslogik für FootballLeaguePage.xaml
	/// </summary>
	public partial class FootballLeaguePage : Page, INotifyPropertyChanged
	{
		#region Constructor

		public FootballLeaguePage()
		{
			InitializeComponent();
			DataContext = this;

			League = new FootballLeague();
			FilterStateList();
			FilterTeamList();
		}

		#endregion

		#region Properties

		private Object _SelectedExpander;
		public Object SelectedExpander
		{
			get { return _SelectedExpander; }
			set
			{
				_SelectedExpander = value;
				Notify("SelectedExpander");
			}
		}

		private FootballLeague _League;
		public FootballLeague League
		{
			get { return _League; }
			set
			{
				_League = value;
				Notify("League");
			}
		}

		private EContinent _SelectedContinent;
		public EContinent SelectedContinent
		{
			get { return _SelectedContinent; }
			set
			{
				_SelectedContinent = value;
				FilterStateList();
				FilterTeamList();
				Notify("SelectedContinent");
			}
		}

		private StateCollection _StatesComboBoxList;
		public StateCollection StatesComboBoxList
		{
			get { return _StatesComboBoxList; }
			set
			{
				_StatesComboBoxList = value;
				Notify("StatesComboBoxList");
			}
		}

		private State _SelectedState;
		public State SelectedState
		{
			get { return _SelectedState; }
			set
			{
				_SelectedState = value;
				FilterTeamList();
				Notify("SelectedState");
			}
		}

		private FootballTeamCollection _FilteredTeamList;
		public FootballTeamCollection FilteredTeamList
		{
			get { return _FilteredTeamList; }
			set
			{
				_FilteredTeamList = value;
				Notify("FilteredTeamList");
			}
		}

		private LeagueWikiTemplateCollection _TemplatesComboBoxList;
		public LeagueWikiTemplateCollection TemplatesComboBoxList
		{
			get { return _TemplatesComboBoxList; }
			set
			{
				_TemplatesComboBoxList = value;
				Notify("TemplatesComboBoxList");
			}
		}

		//public 

		#endregion

		#region Methods

		private void FilterTeamList()
		{
			FilteredTeamList = new FootballTeamCollection(Settings.FootballTeams);
			if(SelectedContinent != EContinent.Unknown)
				FilteredTeamList = new FootballTeamCollection(FilteredTeamList.Where(x => x.State.Continent == SelectedContinent));
			if(SelectedState != null && SelectedState != State.NoneState)
				FilteredTeamList = new FootballTeamCollection(FilteredTeamList.Where(x => x.State == SelectedState));
		}

		private void FilterStateList()
		{
			StatesComboBoxList = new StateCollection(Settings.States.Where(x => x.Continent == SelectedContinent));
			StatesComboBoxList.Insert(0, State.NoneState);
		}

		private void FilterTemplatesList()
		{
			TemplatesComboBoxList = new LeagueWikiTemplateCollection(Settings.LeageWikiTemplates.Where(x =>
					x.LeagueSize == League.TeamCount &&
					x.IsDate == DateCheckBox.IsChecked &&
					x.IsLocation == LocationCheckBox.IsChecked));
			//TemplatesComboBoxList.Insert(0, LeagueWikiTemplate.NoneTemplate);
		}

		private void FillWikiCodeQualComboBoxes()
		{
			var valuesQ1 = new int[League.TeamCount + 1];
			for(int i = 0; i <= League.TeamCount; i++)
				valuesQ1[i] = i;
			Qual1PlacesComboBox.ItemsSource = valuesQ1;
			if(Qual1PlacesComboBox.SelectedIndex == -1)
				Qual1PlacesComboBox.SelectedIndex = 0;

			var valuesQ2 = new int[League.TeamCount - Qual1PlacesComboBox.SelectedIndex + 1];
			for(int i = 0; i <= League.TeamCount - Qual1PlacesComboBox.SelectedIndex; i++)
				valuesQ2[i] = i;
			Qual2PlacesComboBox.ItemsSource = valuesQ2;
			if(Qual2PlacesComboBox.SelectedIndex == -1)
				Qual2PlacesComboBox.SelectedIndex = 0;
		}

		private void SelectAllTeamsButton_Click(object sender, RoutedEventArgs e)
		{
			FootballTeamsListBox.SelectAll();
		}

		private void GenerateMatchesButton_Click(object sender, RoutedEventArgs e)
		{
			League.Teams = FootballTeamCollection.CreateCollection(FootballTeamsListBox.SelectedItems);
			League.CreateMatches();

			FillWikiCodeQualComboBoxes();
			FilterTemplatesList();
		}

		private void SimulateButton_Click(object sender, RoutedEventArgs e)
		{
			League.Simulate();
		}

		private void SwapTeamsButton_Click(object sender, RoutedEventArgs e)
		{
			var match = ((FrameworkElement) sender).DataContext as FootballMatch;
			match.SwapTeams();
		}

		private void Qual1PlacesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			FillWikiCodeQualComboBoxes();
		}

		private void DateCheckBox_Checked(object sender, RoutedEventArgs e)
		{
			FilterTemplatesList();
		}

		private void DateCheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			FilterTemplatesList();
		}

		private void LocationCheckBox_Checked(object sender, RoutedEventArgs e)
		{
			FilterTemplatesList();
		}

		private void LocationCheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			FilterTemplatesList();
		}

		private void GenerateWikiCodeButton_Click(object sender, RoutedEventArgs e)
		{
			WikiCodeTextBox.Text = String.Empty;

			if(TableCheckBox.IsChecked == true)
			{
				League.CalculateTable();
				WikiCodeTextBox.Text += WikiHelper.GenerateTableCode(League, Qual1PlacesComboBox.SelectedIndex, Qual2PlacesComboBox.SelectedIndex);
			}

			if(ResultsCheckBox.IsChecked == true)
			{
				WikiCodeTextBox.Text += WikiHelper.GenerateResultsCode(League, (bool) DateCheckBox.IsChecked, (bool) LocationCheckBox.IsChecked, WikiTemplateComboBox.SelectedItem as LeagueWikiTemplate);
			}
		}

		private void CopyWikiCodeButton_Click(object sender, RoutedEventArgs e)
		{
			Clipboard.SetText(WikiCodeTextBox.Text);
		}

		#endregion

		#region Observer

		public event PropertyChangedEventHandler PropertyChanged;
		protected void Notify(String propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion
	}
 }
