using UnityEditor;
using UnityEngine;
using System.IO;

namespace Foundation.Editor
{
	public class CreateClass
	{
		public static void CreateFile(string path, string body)
		{
			Debug.Log("Creating Classfile: " + path);
			if (File.Exists(path) == false)
			{
				using StreamWriter outfile = new StreamWriter(path);
				outfile.Write(body);
			}

			AssetDatabase.Refresh();
		}
	} 
}