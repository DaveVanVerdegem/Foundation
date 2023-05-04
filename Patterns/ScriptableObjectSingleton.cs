using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Foundation.Patterns
{
	/// <summary>
	/// A Scriptable Object that is a singleton.
	/// </summary>
	/// <typeparam name="T">Scriptable Object that is the Singleton. Make sure this is an Addressable in Unity with the same name.</typeparam>
	public class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObjectSingleton<T>
	{
		#region Properties
		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					AsyncOperationHandle<T> asyncOperation = Addressables.LoadAssetAsync<T>(typeof(T).Name);

					_instance = asyncOperation.WaitForCompletion(); // Forces synchronous load so that we can return immediately.
				}

				return _instance;
			}
		}
		#endregion

		#region Fields
		private static T _instance;
		#endregion
	}
}