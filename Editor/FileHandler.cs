using UnityEngine;
using System.IO;
using static System.IO.Path;
using static System.IO.Directory;
using static UnityEngine.Application;
using static UnityEditor.AssetDatabase;

namespace Foundation.Editor
{
	public class FileHandler
	{
		#region Methods
		public static void CreateFile(string path, string body)
		{
			path = Combine(dataPath, path);

			Debug.Log("Creating File: " + path);
			if (File.Exists(path) == false)
			{
				using StreamWriter outfile = new StreamWriter(path);
				outfile.Write(body);
			}

			Refresh();
		}

		public static void CreateFolders(params string[] folders)
		{
			foreach (string folder in folders)
			{
				CreateDirectory(Combine(dataPath, folder));
			}

			Refresh();
		}
		#endregion
	}
}