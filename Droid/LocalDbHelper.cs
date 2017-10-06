using System;
using System.IO;
using SoftGestCloud.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalDbHelper))]
namespace SoftGestCloud.Droid
{
	public class LocalDbHelper : ILocalDbHelper
	{
		public string GetLocalFilePath(string fileName)
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

			if (!Directory.Exists(libFolder))
			{
				Directory.CreateDirectory(libFolder);
			}

			return Path.Combine(libFolder, fileName);
		}
	}
}
