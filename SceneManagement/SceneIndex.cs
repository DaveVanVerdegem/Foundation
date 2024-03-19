using Foundation.SceneManagement.UI;

namespace Foundation.SceneManagement
{
	public class SceneIndex
	{
		#region Static Scene Indices
		public static readonly SceneIndex Persistent = new SceneIndex(0);
		public static readonly SceneIndex Game = new SceneIndex(1);
		public static readonly SceneIndex Mission = new SceneIndex(2);
		#endregion

		#region Properties
		public int Index { get; }
		public LoadingScreenProperties LoadingScreenProperties { get; }

		public SceneIndex(int index/*, LoadingScreenProperties loadingScreenProperties*/)
		{
			Index = index;
			//LoadingScreenProperties = loadingScreenProperties ?? throw new ArgumentNullException(nameof(loadingScreenProperties));
		}
		#endregion
	}
}