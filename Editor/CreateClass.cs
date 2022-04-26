using UnityEditor;
using UnityEngine;
using System.IO;

namespace Foundation.Editor
{
	public class CreateClass
	{
		[MenuItem("Foundation/Patterns/Create Facade")]
		private static void CreateFacade()
		{
			string path = "Assets/Facade.cs";
			string body = "namespace Foundation.Patterns\n{\n	static class Facade\n	{\n	}\n}";

			CreateFile(path, body);
		}

		private static void CreateFile(string path, string body)
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