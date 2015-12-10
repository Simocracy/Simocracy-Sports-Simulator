using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim.Data
{
	/// <summary>
	/// Klasse für Staaten in Simocracy
	/// </summary>
	public class State
	{
		#region Members

		private static State _NoState = new State(String.Empty, String.Empty);

		#endregion

		#region Constructors

		/// <summary>
		/// Erstellt einen neuen Staat
		/// </summary>
		/// <param name="name">Name des Staates</param>
		/// <param name="flag">Flaggenkürzel des Staates</param>
		public State(string name, string flag)
		{
			Name = name;
			Flag = flag;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Leerer Staat ohne Angaben
		/// </summary>
		public static State NoState
		{
			get
			{
				return _NoState;
			}
		}

		/// <summary>
		/// Name des Staates
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Flaggenkürzel des Staates
		/// </summary>
		public string Flag { get; private set; }

		#endregion
	}
}
