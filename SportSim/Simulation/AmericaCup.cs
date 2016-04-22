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

		#endregion

		#region Methods

		/// <summary>
		/// Lost die Gruppen aus und initialisiert diese.
		/// </summary>
		public void Draw()
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
		}

		/// <summary>
		/// Simuliert die Gruppen
		/// </summary>
		public void SimulateGroups()
		{
			if(Groups != null)
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
