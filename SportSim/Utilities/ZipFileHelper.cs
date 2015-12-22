using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simocracy.SportSim
{
	/// <summary>
	/// Klasse um Datei mit Einstellungen und vorhandenen Teams zu speichern/laden
	/// </summary>
	public static class ZipFileHelper
	{

		/// <summary>
		/// Speichert die übergebenen Steams in der angegebenen ZIP-Datei.
		/// </summary>
		/// <param name="filename">Zielpfad der ZIP-Datei</param>
		/// <param name="files">Zu speichernde Streams. Tupelformat: Dateiname, Stream</param>
		public static async void SaveZipFile(string filename, Tuple<string, MemoryStream>[] files)
		{
			using(var outStream = new FileStream(filename, FileMode.Create))
			{
				using(var zipFile = new ZipArchive(outStream, ZipArchiveMode.Create))
				{
					int fileIndex = 0;
					foreach(var file in files)
					{
						// Falls kein Name angegeben Dateiname mit Index
						var streamName = !String.IsNullOrWhiteSpace(file.Item1) ? file.Item1 : "file" + fileIndex;

						var fileInZip = zipFile.CreateEntry(streamName, CompressionLevel.Optimal);
						using(var entryStream = fileInZip.Open())
						{
							file.Item2.Position = 0;
							await file.Item2.CopyToAsync(entryStream);
						}

						fileIndex++;
					}
				}
			}
		}

	}
}
