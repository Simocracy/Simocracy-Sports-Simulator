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
			Settings.LogPageOpened(this);

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

		#endregion

		#region Methods
		
		/// <summary>
		/// Filtert die Teamliste basierend auf Kontinent und Staat
		/// </summary>
		private void FilterTeamList()
		{
			SimpleLog.Info(String.Format("Filter Teamlist: Continent={0} State={1}", SelectedContinent, SelectedState?.Name));

			FilteredTeamList = new FootballTeamCollection(Settings.FootballTeams);
			if(SelectedContinent != EContinent.Unknown)
				FilteredTeamList = new FootballTeamCollection(FilteredTeamList.Where(x => x.State.Continent == SelectedContinent));
			if(SelectedState != null && SelectedState != State.NoneState)
				FilteredTeamList = new FootballTeamCollection(FilteredTeamList.Where(x => x.State == SelectedState));
		}

		/// <summary>
		/// Filtert die Staatenliste basierend auf dem Kontinent
		/// </summary>
		private void FilterStateList()
		{
			SimpleLog.Info(String.Format("Filter Statelist: Continent={0}", SelectedContinent));

			StatesComboBoxList = (SelectedContinent != EContinent.Unknown) ? new StateCollection(Settings.States.Where(x => x.Continent == SelectedContinent)) : new StateCollection(Settings.States);
			StatesComboBoxList.Insert(0, State.NoneState);
		}

		/// <summary>
		/// Filtert die Vorlagenliste basierend auf Ligagröße und Datums/Ortsangaben
		/// </summary>
		private void FilterTemplatesList()
		{
			SimpleLog.Info(String.Format("Filter Templatelist: LeagueSize={0}, IsDate={1}, IsLocation={2}",
				League.TeamCount, DateCheckBox.IsChecked, LocationCheckBox.IsChecked));

			TemplatesComboBoxList = new LeagueWikiTemplateCollection(Settings.LeageWikiTemplates.Where(x =>
					x.LeagueSize == League.TeamCount &&
					x.IsDate == DateCheckBox.IsChecked &&
					x.IsLocation == LocationCheckBox.IsChecked));
			//TemplatesComboBoxList.Insert(0, LeagueWikiTemplate.NoneTemplate);

			if(TemplatesComboBoxList.Count > 0)
				WikiTemplateComboBox.SelectedIndex = 0;
		}

		/// <summary>
		/// Füllt die Comboboxen für die Positionen der Qualx-Tabellenplätze
		/// </summary>
		private void FillWikiCodeQualComboBoxes()
		{
			SimpleLog.Info(String.Format("Filter Qual-Classes: LeagueSize={0}, Qual1Count={1}, Qual2Count={2}",
				League.TeamCount, Qual1PlacesComboBox.SelectedIndex, Qual2PlacesComboBox.SelectedIndex));

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
			Settings.LogButtonClicked(sender as Button);
			FootballTeamsListBox.SelectAll();
		}

		private void DiselectAllTeamsButton_Click(object sender, RoutedEventArgs e)
		{
			Settings.LogButtonClicked(sender as Button);
			FootballTeamsListBox.SelectedItems.Clear();
		}

		private void GenerateMatchesButton_Click(object sender, RoutedEventArgs e)
		{
			Settings.LogButtonClicked(sender as Button);
			League.Teams = FootballTeamCollection.CreateCollection(FootballTeamsListBox.SelectedItems);
			League.CreateMatches();

			FillWikiCodeQualComboBoxes();
			FilterTemplatesList();
		}

		private async void SimulateButton_Click(object sender, RoutedEventArgs e)
		{
			Settings.LogButtonClicked(sender as Button);
			await League.SimulateAsync();
		}

		private void SwapTeamsButton_Click(object sender, RoutedEventArgs e)
		{
			Settings.LogButtonClicked(sender as Button);
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

		private async void GenerateWikiCodeButton_Click(object sender, RoutedEventArgs e)
		{
			Settings.LogButtonClicked(sender as Button);
			SimpleLog.Info(String.Format("Generate Wikicode, LeagueSize={0}, Table={1}, Qual1Count={2}, Qual2Count={3}, Results={4}, Template={5}",
				League.TeamCount, TableCheckBox.IsChecked, Qual1PlacesComboBox.SelectedIndex, Qual2PlacesComboBox.SelectedIndex,
				ResultsCheckBox.IsChecked, (WikiTemplateComboBox.SelectedItem as LeagueWikiTemplate).Name));
			WikiCodeTextBox.Text = String.Empty;
			
			if(TableCheckBox.IsChecked == true)
			{
				try
				{
					await League.CalculateTableAsync();
					WikiCodeTextBox.Text += await WikiHelper.GenerateTableCodeAsync(League, Qual1PlacesComboBox.SelectedIndex, Qual2PlacesComboBox.SelectedIndex);
				}
				catch(Exception ex)
				{
					SimpleLog.Log(ex);
				}
			}

			if(ResultsCheckBox.IsChecked == true && WikiTemplateComboBox.SelectedIndex >= 0)
			{
				try
				{
					WikiCodeTextBox.Text += await WikiHelper.GenerateResultsCodeAsync(League, WikiTemplateComboBox.SelectedItem as LeagueWikiTemplate);
				}
				catch(Exception ex)
				{
					SimpleLog.Log(ex);
				}
			}
		}

		private void CopyWikiCodeButton_Click(object sender, RoutedEventArgs e)
		{
			Settings.LogButtonClicked(sender as Button);
			try
			{
				Clipboard.SetText(WikiCodeTextBox.Text);
			}
			catch { }
		}

		#endregion

		#region Observer

		public event PropertyChangedEventHandler PropertyChanged;
		protected void Notify([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion
	}
 }
