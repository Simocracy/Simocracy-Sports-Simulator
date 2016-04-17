using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{
	public class WikiHelper
	{
		#region Basics

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

		#endregion

		#region Football

		/// <summary>
		/// Erstellt den Code für die Tabelle der angegebenen <see cref="FootballLeague"/>
		/// </summary>
		/// <param name="league"><see cref="FootballLeague"/> der zu generierenden Tabelle</param>
		/// <param name="qual1Count">Anzahl der Qual1-Plätze</param>
		/// <param name="qual2Count">Anzahl der Qual2-Plätze</param>
		/// <returns>Generierten Tabellencode</returns>
		public static string GenerateTableCode(FootballLeague league, int qual1Count, int qual2Count)
		{
			StringBuilder sb = new StringBuilder(Settings.WikiStrings.FootballLeagueTableHeader);

			int position = 1;
			foreach(DataRow row in league.Table.Rows)
			{
				try
				{
					var team = row["Team"] as FootballTeam;
					var matches = (int) row["Matches"];
					var win = (int) row["Win"];
					var drawn = (int) row["Drawn"];
					var lose = (int) row["Lose"];
					var goalsFor = (int) row["GoalsFor"];
					var goalsAgainst = (int) row["GoalsAgainst"];
					var goalsString = String.Format("{0}:{1}", goalsFor, goalsAgainst);
					var points = (int) row["Points"];

					string classString = String.Empty;
					if(position <= qual1Count)
						classString = Settings.WikiStrings.ClassQual1;
					else if(position - qual1Count <= qual2Count)
						classString = Settings.WikiStrings.ClassQual2;

					sb.AppendFormat(Settings.WikiStrings.FootballLeagueTableElememt, classString, position++, team.Name, matches, win, drawn, lose, goalsString, points);
				}
				catch(Exception e)
				{
					System.Diagnostics.Debug.WriteLine(e);
				}
			}

			sb.Append(Settings.WikiStrings.TableEnd);
			return sb.ToString();
		}

		/// <summary>
		/// Generiert den Code für die Darstellung der Ergebnisse der angegebenen <see cref="FootballLeague"/> und nutzt dazu die angegebene <see cref="LeagueWikiTemplate"/>
		/// </summary>
		/// <param name="league"><see cref="FootballLeague"/> der darzustellenden Ergebnisse</param>
		/// <param name="isDate">Angabe, ob das Datum in der Ausgabe enthalten ist</param>
		/// <param name="isLocation">Angabe, ob der Spielort in der Ausgabe enthalten ist</param>
		/// <param name="template"><see cref="LeagueWikiTemplate"/> der darzustellenden Ergebnisse</param>
		/// <returns>Generierten Ergebniscode</returns>
		public static string GenerateResultsCode(FootballLeague league, bool isDate, bool isLocation, LeagueWikiTemplate template = null)
		{
			if(template == null)
				//return GenerateResultsCode(league, isDate, isLocation);
				throw new NotImplementedException("Results output without template not implemented");



			return String.Empty;
		}

		/// <summary>
		/// Generiert den Code für die Darstellung der Ergebnisse der angegebenen <see cref="FootballLeague"/>
		/// </summary>
		/// <param name="league"><see cref="FootballLeague"/> der darzustellenden Ergebnisse</param>
		/// <param name="isDate">Angabe, ob das Datum in der Ausgabe enthalten ist</param>
		/// <param name="isLocation">Angabe, ob der Spielort in der Ausgabe enthalten ist</param>
		/// <returns>Generierten Ergebniscode</returns>
		public static string GenerateResultsCode(FootballLeague league, bool isDate, bool isLocation)
		{
			throw new NotImplementedException("Results output without template not implemented");
		}

		#endregion
	}
}
