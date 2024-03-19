using Foundation.Patterns;
using Foundation.SceneManagement;
using UnityEngine;

public abstract class SceneObjectSingleton<T> : SimpleSingleton<T> where T: MonoBehaviour, ISceneObject
{
	#region Properties
	public bool HasSetUp { get; protected set; }
	public bool HasStartedUp { get; protected set; }
	#endregion

	#region Life Cycle
	public abstract void SetUp();

	public abstract void StartUp();
	#endregion
}
