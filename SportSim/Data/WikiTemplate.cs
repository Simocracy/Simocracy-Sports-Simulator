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

		#region Members

		private string _TemplateCode;

		#endregion

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
		{
			get { return _TemplateCode; }
			set { _TemplateCode = value; Notify(); }
		}

		#endregion

		#region Overrided Methods

		/// <summary>
		/// Gibt einen <see cref="String"/> zurück, der das Objekt darstellt.
		/// </summary>
		/// <returns>Objekt als String</returns>
		public override string ToString()
		{
			return String.Format("{0}, TemplateCode={2}", base.ToString(), TemplateCode);
		}

		#endregion

	}
}
