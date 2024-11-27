using Foundation.Patterns;
using Foundation.SceneManagement.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using NaughtyAttributes;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace Foundation.SceneManagement
{
	public class SceneManager : Singleton<SceneManager>
	{
		#region Inspector Fields
		[SerializeField] public bool _useLoadingScreen = true;

		//[EnableIf("_useLoadingScreen")]
		[SerializeField] private LoadingScreen _loadingScreen = null;
		#endregion

		#region Fields
		private List<AsyncOperation> _scenesLoading = new List<AsyncOperation>();
		private int _activeScene => UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

		private float _totalProgress = 0;
		private float _totalSceneProgress;
		private float _totalSetupProgress;
		#endregion

		#region Life Cycle
		private void Update()
		{
			if (_totalProgress < 1f)
				return;

			if (AnyKeyPressed())
			{
				FinishLoading();
			}
		}

		private bool AnyKeyPressed()
		{
#if ENABLE_INPUT_SYSTEM
			return Keyboard.current.anyKey.isPressed
				|| Mouse.current.leftButton.isPressed
				|| Mouse.current.rightButton.isPressed
				|| Mouse.current.middleButton.isPressed;
# else
			return Input.anyKey;
#endif
		}
		#endregion

		#region Static Methods
		public static void LoadScene(SceneIndex scene, bool forceReload = false) => Instance.LoadSceneBySceneIndex(scene, forceReload);

		public static bool IsPersistentSceneLoaded()
		{
			int scenesLoaded = Instance.GetSceneCount();

			for (int i = 0; i < scenesLoaded; i++)
			{
				Scene scene = Instance.GetSceneAt(i);

				if (scene.buildIndex == SceneIndex.Persistent.Index)
					return scene.isLoaded;
			}

			return false;
		}
		#endregion

		#region Methods
		private void LoadSceneBySceneIndex(SceneIndex sceneIndex, bool forceReload = false)
		{
			if (!forceReload && _activeScene == sceneIndex.Index) return;

			SetLoadingScreenProperties(sceneIndex);

			UnloadOpenScenes();
			_scenesLoading.Add(LoadSceneAsync(sceneIndex));

			StartCoroutine(LoadProgressCoroutine());
		}

		private void UnloadOpenScenes()
		{
			int openSceneCount = GetSceneCount();

			for (int i = 0; i < openSceneCount; i++)
			{
				if (i == SceneIndex.Persistent.Index)
					continue;

				_scenesLoading.Add(UnloadSceneAsync(GetSceneAt(i).buildIndex));
			}
		}

		private IEnumerator LoadProgressCoroutine()
		{
			SetLoadingScreenProgress(0);

			yield return StartCoroutine(GetSceneLoadProgressCoroutine());
			yield return StartCoroutine(GetTotalProgressCoroutine());

			if (_useLoadingScreen && !_loadingScreen.LoadingScreenProperties.WaitForAnyKey)
				FinishLoading();
			else
				FinishLoading();
		}

		private IEnumerator GetSceneLoadProgressCoroutine()
		{
			for (int i = 0; i < _scenesLoading.Count; i++)
			{
				while (!_scenesLoading[i].isDone)
				{
					_totalSceneProgress = 0;

					for (int j = 0; j < _scenesLoading.Count; j++)
					{
						_totalSceneProgress += _scenesLoading[i].progress;
					}

					_totalSceneProgress /= _scenesLoading.Count;
					SetLoadProgress();

					yield return null;
				}
			}

			int lastLoadedScene = GetSceneCount() - 1;
			SetActiveScene(GetSceneAt(lastLoadedScene).buildIndex);

			_totalSceneProgress = 1;
			SetLoadProgress();

			_scenesLoading.Clear();
		}

		private IEnumerator GetTotalProgressCoroutine()
		{
			_totalSetupProgress = 0;

			while (SceneInitializer.Instance == null || !SceneInitializer.Instance.IsDone)
			{
				if (SceneInitializer.Instance == null)
				{
					_totalSetupProgress = 0;
				}
				else
				{
					_totalSetupProgress = SceneInitializer.Instance.Progress;
				}

				SetLoadProgress();

				yield return null;
			}

			_totalSetupProgress = SceneInitializer.Instance.Progress;
			SetLoadProgress();
		}

		private void SetLoadProgress()
		{
			_totalProgress = (_totalSceneProgress + _totalSetupProgress) * .5f;
			SetLoadingScreenProgress(_totalProgress);
		}

		private void ResetProgress()
		{
			_totalProgress = 0;
			_totalSceneProgress = 0;
			_totalSetupProgress = 0;
		}

		private void FinishLoading()
		{
			SceneInitializer.Instance.StartUp();
			DisableLoadingScreen();
			ResetProgress();
		}
		#endregion

		#region Unity SceneManager Shorthand Methods
		private AsyncOperation LoadSceneAsync(SceneIndex sceneIndex)
			=> UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex.Index, LoadSceneMode.Additive);

		private AsyncOperation UnloadSceneAsync(int sceneIndex)
			=> UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneIndex);

		private AsyncOperation UnloadSceneAsync(SceneIndex sceneIndex)
			=> UnloadSceneAsync(sceneIndex.Index);

		private bool SetActiveScene(int sceneIndex)
			=> UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(sceneIndex));

		private bool SetActiveScene(SceneIndex sceneIndex)
			=> SetActiveScene(sceneIndex.Index);

		private Scene GetSceneAt(int index)
			=> UnityEngine.SceneManagement.SceneManager.GetSceneAt(index);

		private int GetSceneCount()
			=> UnityEngine.SceneManagement.SceneManager.sceneCount;
		#endregion

		#region Loading Screen Methods
		private void SetLoadingScreenProperties(SceneIndex sceneIndex)
		{
			if (!_useLoadingScreen) return;

			_loadingScreen.Enable(sceneIndex.LoadingScreenProperties);
		}

		private void SetLoadingScreenProgress(float progress)
		{
			if (!_useLoadingScreen) return;

			_loadingScreen.SetLoadProgress(progress);
		}

		private void DisableLoadingScreen()
		{
			if (!_useLoadingScreen) return;

			_loadingScreen.Disable();
		}
		#endregion
	}
}