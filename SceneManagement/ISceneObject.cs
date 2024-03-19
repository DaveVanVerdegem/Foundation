using Foundation.Helpers;

namespace Foundation.SceneManagement
{
	public interface ISceneObject : IHasAliveCheck
	{
		#region Life Cycle
		public void SetUp();

		public void StartUp();
		#endregion
	}
}