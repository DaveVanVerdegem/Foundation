using Foundation.Patterns;
using Foundation.Helpers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Foundation.SceneManagement
{
	public class SceneInitializer : SimpleSingleton<SceneInitializer>
	{
		#region Properties
		public bool IsDone { get; private set; } = false;
		public float Progress { get; private set; }
		#endregion

		#region Fields
		private List<ISceneObject> _sceneObjects = new List<ISceneObject>();
		#endregion

		#region Life Cycle
		private void Awake()
		{
			StartCoroutine(SetUpCoroutine());
		}

		public IEnumerator SetUpCoroutine()
		{
			Debug.Log("Setting up scene...");

			_sceneObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISceneObject>().ToList();

			for (int i = 0; i < _sceneObjects.Count; i++)
			{
				_sceneObjects[i].SetUp();

				Progress = i / (float)_sceneObjects.Count;

				yield return null;
			}

			Progress = 1f;
			IsDone = true;

			// Allows testing scenes independently from the SceneManager.
			if (!SceneManager.IsPersistentSceneLoaded())
				StartUp();
		}

		public void StartUp()
		{
			_sceneObjects.RemoveAll(sceneObject => !sceneObject.IsAlive());

			for (int i = 0; i < _sceneObjects.Count; i++)
			{
				_sceneObjects[i].StartUp();
			}

			Debug.Log("Scene started up.");
		}
		#endregion
	}
}