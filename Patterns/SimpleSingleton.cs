using UnityEngine;

namespace Foundation.Patterns
{
	/// <summary>
	/// A simplified version of the singleton that doesn't persist through scenes.
	/// </summary>
	public class SimpleSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static object _lock = new object();
		private static T _instance;

		/// <summary>
		/// Access singleton instance through this property.
		/// </summary>
		public static T Instance
		{
			get
			{
				lock (_lock)
				{
					if (_instance == null)
					{
						// Search for existing instance.
						_instance = (T)FindObjectOfType(typeof(T));

						// Create new instance if one doesn't already exist.
						if (_instance == null)
						{
							// Need to create a new GameObject to attach the singleton to.
							var singletonObject = new GameObject();
							_instance = singletonObject.AddComponent<T>();
							singletonObject.name = typeof(T).ToString() + " (Singleton)";
						}
					}

					return _instance;
				}
			}
		}
	}
}
