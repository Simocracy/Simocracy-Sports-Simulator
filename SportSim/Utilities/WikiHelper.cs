using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{
	public class WikiHelper
	{
		/// <summary>
		/// Entfernt den Wiki-Dateinamensraum aus dem angegeben String
		/// </summary>
		/// <param name="filename">Voller Dateiname mit Namensraum</param>
		/// <returns>Dateiname ohne Namensraum</returns>
		public static string RemoveFileNamespace(string filename)
		{
			return filename.TrimStart("Datei:".ToCharArray());
		}

		/// <summary>
		/// Prüft, ob der String eine gültige HTTP(S)-URL ist
		/// </summary>
		/// <param name="url">URL</param>
		/// <returns>True wenn gültige HTTP(S)-URL</returns>
		public static bool CheckValidHttpUrl(string url)
		{
			Uri uriResult;
			return Uri.TryCreate(url, UriKind.Absolute, out uriResult)
				&& (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
		}
	}
}
