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
			//StatesComboBoxList = new StateCollection(Settings.States);
			//StatesComboBoxList.Insert(0, State.NoneState);
			FilterStateList();
			//FilteredTeamList = new FootballTeamCollection(Settings.FootballTeams);
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

		private void SelectAllTeamsButton_Click(object sender, RoutedEventArgs e)
		{
			FootballTeamsListBox.SelectAll();
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
