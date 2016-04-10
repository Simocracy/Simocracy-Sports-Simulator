using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Vorlage im Wiki
	/// </summary>
	[DataContract]
	[DebuggerDisplay("WikiTemplate, Name={Name}")]
	public class WikiTemplate : SSSDataObject
	{

		#region Constructor

		/// <summary>
		/// Definiert eine neue Vorlage
		/// </summary>
		/// <param name="id">ID</param>
		/// <param name="name">Vorlagenname</param>
		public WikiTemplate(int id, string name)
			: base(id, name)
		{ }

		/// <summary>
		/// Definiert eine neue Vorlage
		/// </summary>
		/// <param name="id">ID</param>
		/// <param name="name">Vorlagenname</param>
		/// <param name="templateCode">Einbindungscode der Vorlage</param>
		public WikiTemplate(int id, string name, string templateCode)
			: base(id, name)
		{
			TemplateCode = templateCode;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Einbindungscode der Vorlage
		/// </summary>
		[DataMember(Order = 100)]
		public string TemplateCode
		{ get; set; }

		#endregion

	}
}
