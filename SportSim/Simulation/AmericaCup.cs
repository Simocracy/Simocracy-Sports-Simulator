using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Simuliert einen Amerikapokal mit je 32 Mannschaften in Champions League in America League
	/// </summary>
	public class AmericaCup : INotifyPropertyChanged
	{

		#region Constructor

		/// <summary>
		/// Erstellt eine neue Instanz für einen Amerikapokal
		/// </summary>
		public AmericaCup()
		{
			Randomizer = new Random();
			IsGroupsSimulatable = false;
		}

		#endregion

		#region Members

		private ObservableCollection<FootballTeam> _CLPot1;
		private ObservableCollection<FootballTeam> _CLPot2;
		private ObservableCollection<FootballTeam> _CLPot3;
		private ObservableCollection<FootballTeam> _CLPot4;
		private ObservableCollection<FootballTeam> _ALPot1;
		private ObservableCollection<FootballTeam> _ALPot2;
		private ObservableCollection<FootballTeam> _ALPot3;
		private ObservableCollection<FootballTeam> _ALPot4;

		private ObservableCollection<FootballLeague> _Groups;
		private bool _IsGroupsSimulatable;

		#endregion

		#region Properties

		/// <summary>
		/// Zufallsgenerator
		/// </summary>
		private Random Randomizer { get; set; }

		/// <summary>
		/// CL-Lostopf 1
		/// </summary>
		public ObservableCollection<FootballTeam> CLPot1
		{
			get { return _CLPot1; }
			set { _CLPot1 = value; Notify(); }
		}

		/// <summary>
		/// CL-Lostopf 2
		/// </summary>
		public ObservableCollection<FootballTeam> CLPot2
		{
			get { return _CLPot2; }
			set { _CLPot2 = value; Notify(); }
		}

		/// <summary>
		/// CL-Lostopf 3
		/// </summary>
		public ObservableCollection<FootballTeam> CLPot3
		{
			get { return _CLPot3; }
			set { _CLPot3 = value; Notify(); }
		}

		/// <summary>
		/// CL-Lostopf 4
		/// </summary>
		public ObservableCollection<FootballTeam> CLPot4
		{
			get { return _CLPot4; }
			set { _CLPot4 = value; Notify(); }
		}

		/// <summary>
		/// AL-Lostopf 1
		/// </summary>
		public ObservableCollection<FootballTeam> ALPot1
		{
			get { return _ALPot1; }
			set { _ALPot1 = value; Notify(); }
		}

		/// <summary>
		/// AL-Lostopf 2
		/// </summary>
		public ObservableCollection<FootballTeam> ALPot2
		{
			get { return _ALPot2; }
			set { _ALPot2 = value; Notify(); }
		}

		/// <summary>
		/// AL-Lostopf 3
		/// </summary>
		public ObservableCollection<FootballTeam> ALPot3
		{
			get { return _ALPot3; }
			set { _ALPot3 = value; Notify(); }
		}

		/// <summary>
		/// AL-Lostopf 4
		/// </summary>
		public ObservableCollection<FootballTeam> ALPot4
		{
			get { return _ALPot4; }
			set { _ALPot4 = value; Notify(); }
		}

		/// <summary>
		/// CL/AL-Gruppen. Die ersten 8 Elemente bilden die CL-Gruppen, die anderen 8 die AL-Gruppen.
		/// </summary>
		public ObservableCollection<FootballLeague> Groups
		{
			get { return _Groups; }
			set { _Groups = value; Notify(); }
		}

		/// <summary>
		/// Auslosung war Erfolgreich und Ergebnisse können simuliert werden
		/// </summary>
		public bool IsGroupsSimulatable
		{
			get { return _IsGroupsSimulatable; }
			private set { _IsGroupsSimulatable = value; Notify(); }
		}

		#endregion

		#region Methods

		/// <summary>
		/// Lost die Gruppen aus und initialisiert diese. Versucht bis zu 5 Auslosungsdurchläufe.
		/// </summary>
		/// <param name="recursiveCount">Nummer des Losungsdurchlaufes</param>
		public void DrawGroups(int recursiveCount = 0)
		{
			CLPot1.OrderBy(x => Randomizer.Next());
			CLPot2.OrderBy(x => Randomizer.Next());
			CLPot3.OrderBy(x => Randomizer.Next());
			CLPot4.OrderBy(x => Randomizer.Next());
			ALPot1.OrderBy(x => Randomizer.Next());
			ALPot2.OrderBy(x => Randomizer.Next());
			ALPot3.OrderBy(x => Randomizer.Next());
			ALPot4.OrderBy(x => Randomizer.Next());

			Groups = new ObservableCollection<FootballLeague>();
			for(int i = 0; i < 8; i++)
				Groups.Add(new FootballLeague(CLPot1[i], CLPot2[i], CLPot3[i], CLPot4[i]));
			for(int i = 0; i < 8; i++)
				Groups.Add(new FootballLeague(ALPot1[i], ALPot2[i], ALPot3[i], ALPot4[i]));

			// Gleiche Nationen in einer CL-Gruppe behandeln
			bool[] isNationValid = new bool[16];
			for(int i = 0; i < 8; i++)
			{
				var group = Groups[i];
				isNationValid[i] = true;

				if(group.Teams[0].State == group.Teams[1].State)
				{
					if(i > 0 && Groups[i - 1].Teams[1].State != group.Teams[1].State)
					{
						var newTeam = Groups[i - 1].Teams[1];
						Groups[i - 1].Teams[1] = group.Teams[1];
						group.Teams[1] = newTeam;
					}
					else if(i < 7 && Groups[i + 1].Teams[1].State != group.Teams[1].State)
					{
						var newTeam = Groups[i + 1].Teams[1];
						Groups[i + 1].Teams[1] = group.Teams[1];
						group.Teams[1] = newTeam;
					}
				}
				if(group.Teams[0].State == group.Teams[2].State)
				{
					if(i > 0 && Groups[i - 1].Teams[2].State != group.Teams[2].State)
					{
						var newTeam = Groups[i - 1].Teams[2];
						Groups[i - 1].Teams[2] = group.Teams[2];
						group.Teams[2] = newTeam;
					}
					else if(i < 7 && Groups[i + 1].Teams[2].State != group.Teams[2].State)
					{
						var newTeam = Groups[i + 1].Teams[2];
						Groups[i + 1].Teams[2] = group.Teams[2];
						group.Teams[2] = newTeam;
					}
				}
				if(group.Teams[0].State == group.Teams[3].State)
				{
					if(i > 0 && Groups[i - 1].Teams[3].State != group.Teams[3].State)
					{
						var newTeam = Groups[i - 1].Teams[3];
						Groups[i - 1].Teams[3] = group.Teams[3];
						group.Teams[3] = newTeam;
					}
					else if(i < 7 && Groups[i + 1].Teams[3].State != group.Teams[3].State)
					{
						var newTeam = Groups[i + 1].Teams[3];
						Groups[i + 1].Teams[3] = group.Teams[3];
						group.Teams[3] = newTeam;
					}
				}
				if(group.Teams[1].State == group.Teams[2].State)
				{
					if(i > 0 && Groups[i - 1].Teams[2].State != group.Teams[2].State)
					{
						var newTeam = Groups[i - 1].Teams[2];
						Groups[i - 1].Teams[2] = group.Teams[2];
						group.Teams[2] = newTeam;
					}
					else if(i < 7 && Groups[i + 1].Teams[2].State != group.Teams[2].State)
					{
						var newTeam = Groups[i + 1].Teams[2];
						Groups[i + 1].Teams[2] = group.Teams[2];
						group.Teams[2] = newTeam;
					}
				}
				if(group.Teams[1].State == group.Teams[3].State)
				{
					if(i > 0 && Groups[i - 1].Teams[3].State != group.Teams[3].State)
					{
						var newTeam = Groups[i - 1].Teams[3];
						Groups[i - 1].Teams[3] = group.Teams[3];
						group.Teams[3] = newTeam;
					}
					else if(i < 7 && Groups[i + 1].Teams[3].State != group.Teams[3].State)
					{
						var newTeam = Groups[i + 1].Teams[3];
						Groups[i + 1].Teams[3] = group.Teams[3];
						group.Teams[3] = newTeam;
					}
				}
				if(group.Teams[2].State == group.Teams[3].State)
				{
					if(i > 0 && Groups[i - 1].Teams[3].State != group.Teams[3].State)
					{
						var newTeam = Groups[i - 1].Teams[3];
						Groups[i - 1].Teams[3] = group.Teams[3];
						group.Teams[3] = newTeam;
					}
					else if(i < 7 && Groups[i + 1].Teams[3].State != group.Teams[3].State)
					{
						var newTeam = Groups[i + 1].Teams[3];
						Groups[i + 1].Teams[3] = group.Teams[3];
						group.Teams[3] = newTeam;
					}
				}

				isNationValid[i] = AreSameStatesInGroup(group);
			}

			// AL-Gruppen prüfen
			for(int i = 8; i < 16; i++)
			{
				var group = Groups[i];
				isNationValid[i] = true;

				if(group.Teams[0].State == group.Teams[1].State)
				{
					if(i > 0 && Groups[i - 1].Teams[1].State != group.Teams[1].State)
					{
						var newTeam = Groups[i - 1].Teams[1];
						Groups[i - 1].Teams[1] = group.Teams[1];
						group.Teams[1] = newTeam;
					}
					else if(i < 7 && Groups[i + 1].Teams[1].State != group.Teams[1].State)
					{
						var newTeam = Groups[i + 1].Teams[1];
						Groups[i + 1].Teams[1] = group.Teams[1];
						group.Teams[1] = newTeam;
					}
				}
				if(group.Teams[0].State == group.Teams[2].State)
				{
					if(i > 0 && Groups[i - 1].Teams[2].State != group.Teams[2].State)
					{
						var newTeam = Groups[i - 1].Teams[2];
						Groups[i - 1].Teams[2] = group.Teams[2];
						group.Teams[2] = newTeam;
					}
					else if(i < 7 && Groups[i + 1].Teams[2].State != group.Teams[2].State)
					{
						var newTeam = Groups[i + 1].Teams[2];
						Groups[i + 1].Teams[2] = group.Teams[2];
						group.Teams[2] = newTeam;
					}
				}
				if(group.Teams[0].State == group.Teams[3].State)
				{
					if(i > 0 && Groups[i - 1].Teams[3].State != group.Teams[3].State)
					{
						var newTeam = Groups[i - 1].Teams[3];
						Groups[i - 1].Teams[3] = group.Teams[3];
						group.Teams[3] = newTeam;
					}
					else if(i < 7 && Groups[i + 1].Teams[3].State != group.Teams[3].State)
					{
						var newTeam = Groups[i + 1].Teams[3];
						Groups[i + 1].Teams[3] = group.Teams[3];
						group.Teams[3] = newTeam;
					}
				}
				if(group.Teams[1].State == group.Teams[2].State)
				{
					if(i > 0 && Groups[i - 1].Teams[2].State != group.Teams[2].State)
					{
						var newTeam = Groups[i - 1].Teams[2];
						Groups[i - 1].Teams[2] = group.Teams[2];
						group.Teams[2] = newTeam;
					}
					else if(i < 7 && Groups[i + 1].Teams[2].State != group.Teams[2].State)
					{
						var newTeam = Groups[i + 1].Teams[2];
						Groups[i + 1].Teams[2] = group.Teams[2];
						group.Teams[2] = newTeam;
					}
				}
				if(group.Teams[1].State == group.Teams[3].State)
				{
					if(i > 0 && Groups[i - 1].Teams[3].State != group.Teams[3].State)
					{
						var newTeam = Groups[i - 1].Teams[3];
						Groups[i - 1].Teams[3] = group.Teams[3];
						group.Teams[3] = newTeam;
					}
					else if(i < 7 && Groups[i + 1].Teams[3].State != group.Teams[3].State)
					{
						var newTeam = Groups[i + 1].Teams[3];
						Groups[i + 1].Teams[3] = group.Teams[3];
						group.Teams[3] = newTeam;
					}
				}
				if(group.Teams[2].State == group.Teams[3].State)
				{
					if(i > 0 && Groups[i - 1].Teams[3].State != group.Teams[3].State)
					{
						var newTeam = Groups[i - 1].Teams[3];
						Groups[i - 1].Teams[3] = group.Teams[3];
						group.Teams[3] = newTeam;
					}
					else if(i < 7 && Groups[i + 1].Teams[3].State != group.Teams[3].State)
					{
						var newTeam = Groups[i + 1].Teams[3];
						Groups[i + 1].Teams[3] = group.Teams[3];
						group.Teams[3] = newTeam;
					}
				}

				isNationValid[i] = AreSameStatesInGroup(group);
			}

			// Wenn eine Gruppe immer noch nicht passt, dann Prozedere von vorne beginnen
			IsGroupsSimulatable = true;
			if(isNationValid.Contains(false))
			{
				if(recursiveCount < 5)
					DrawGroups();
				else
					IsGroupsSimulatable = false;
			}
		}

		/// <summary>
		/// Simuliert die Gruppen
		/// </summary>
		public void SimulateGroups()
		{
			if(IsGroupsSimulatable && Groups != null)
				foreach(var group in Groups)
					group.Simulate();
		}

		/// <summary>
		/// Simuliert die Gruppen asynchron.
		/// </summary>
		public async void SimulateGroupsAsync()
		{
			await Task.Run(() => SimulateGroups());
		}

		/// <summary>
		/// Prüft, ob in der Gruppe 2 Mannschaften oder mehr aus dem gleichen Staat sind
		/// </summary>
		/// <param name="group">Gruppe</param>
		/// <returns>True, wenn 2 oder mehr Mannschaften aus dem gleichen Staat</returns>
		private bool AreSameStatesInGroup(FootballLeague group)
		{
			return (group.Teams[0].State == group.Teams[1].State) || (group.Teams[0].State == group.Teams[2].State) ||
				(group.Teams[0].State == group.Teams[3].State) || (group.Teams[1].State == group.Teams[2].State) ||
				(group.Teams[1].State == group.Teams[3].State) || (group.Teams[2].State == group.Teams[3].State);
		}

		#endregion

		#region INotifyPropertyChanged

		/// <summary>
		/// Observer-Event
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Observer
		/// </summary>
		/// <param name="propertyName">Property</param>
		protected void Notify([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

	}
}
