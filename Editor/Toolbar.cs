using UnityEditor;
using UnityEngine;

namespace Foundation.Editor
{
	public class Toolbar
	{
		#region Fields
		private const string _facadeBody =
			"namespace Foundation.Patterns\n{\n	static class Facade\n	{\n	}\n}";
		#endregion

		#region Base Methods
		private static void CreateNewAsset(string fileName, string body)
		{
			ProjectWindowUtil.CreateAssetWithContent(fileName, body);
		}
		#endregion

		#region Setup
		[MenuItem("Foundation/Setup/Setup Project", false, 10)]
		public static void SetupProject()
		{
			LoadNewManifestAsync();
			CreateDefaultFolders();
		}

		[MenuItem("Foundation/Setup/Load Manifest", false, 120)]
		static async void LoadNewManifestAsync()
		{
			await Packages.LoadNewManifest("2cc583387cc70e6bf857e63f2e825e22");
		}

		[MenuItem("Foundation/Setup/Create Default Folders", false, 120)]
		public static void CreateDefaultFolders()
		{
			FileHandler.CreateFolders("Scenes", "Code", "Materials", "Prefabs");
		}
		#endregion

		#region Patterns
		[MenuItem("Foundation/Patterns/Facade")]
		private static void CreateFacade()
		{
			string path = "Facade.cs";

			FileHandler.CreateFile(path, _facadeBody);
		}

		[MenuItem("Assets/Create/Foundation/Patterns/Facade", false, 1)]
		private static void CreateFacadeAssets()
		{
			string fileName = "Facade.cs";

			CreateNewAsset(fileName, _facadeBody);
		}
		#endregion

		#region Helpers
		[MenuItem("Foundation/Helpers/AxialGizmo")]
		private static void CreateAxialGizmo()
		{
			string path = "Helpers/AxialGizmo";

			Object prefab = Resources.Load<Object>(path);
			Selection.activeObject = PrefabUtility.InstantiatePrefab(prefab);
		}
		#endregion
	} 
}