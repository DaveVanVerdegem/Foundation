using UnityEngine;

namespace Foundation.SceneManagement
{
	public abstract class SceneObject : MonoBehaviour, ISceneObject
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
}