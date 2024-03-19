using UnityEngine;

namespace Foundation.SceneManagement.UI
{
	[CreateAssetMenu(menuName = "Foundation/Loading Screen Properties")]
	public class LoadingScreenProperties : ScriptableObject
	{
		#region Inspector Fields
		[SerializeField] private bool _waitForAnyKey = false;
		[SerializeField] private Sprite _loadingArt = null;
		[SerializeField] private string _loadingText = "Loading game...";
		[SerializeField] private string _finishedText = "Press any key to continue.";
		#endregion

		#region Properties
		public bool WaitForAnyKey => _waitForAnyKey;
		public Sprite LoadingArt => _loadingArt;
		public string LoadingText => _loadingText;
		public string FinishedText => _finishedText;
		#endregion
	}
}