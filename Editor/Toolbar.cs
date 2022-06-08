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

		#region Patterns
		[MenuItem("Foundation/Patterns/Facade")]
		private static void CreateFacade()
		{
			string path = "Assets/Facade.cs";

			CreateClass.CreateFile(path, _facadeBody);
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