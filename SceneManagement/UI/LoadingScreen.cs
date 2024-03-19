using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Foundation.SceneManagement.UI
{
	public class LoadingScreen : MonoBehaviour
	{
		#region Inspector Fields
		[SerializeField] private Slider _progressBar = null;
		[SerializeField] private TextMeshProUGUI _infoText = null;
		[SerializeField] private Image _loadingArtImage = null;
		[Space]
		[SerializeField] private float _sineAmplitude = .05f;
		[SerializeField] private float _sineFrequency = 2f;
		#endregion

		#region Properties
		public LoadingScreenProperties LoadingScreenProperties { get; private set; }
		#endregion

		#region Life Cycle
		public void Enable(LoadingScreenProperties properties)
		{
			LoadingScreenProperties = properties;

			_loadingArtImage.sprite = LoadingScreenProperties.LoadingArt;
			_loadingArtImage.enabled = LoadingScreenProperties.LoadingArt != null;

			gameObject.SetActive(true);
		}

		private void Update()
		{
			if (_progressBar.value < 1f) return;

			SineScaleInfoText();
		}

		public void Disable()
		{
			gameObject.SetActive(false);
		}
		#endregion

		#region Methods
		public void SetLoadProgress(float progress)
		{
			_progressBar.value = progress;
			_infoText.text = progress < 1f ? LoadingScreenProperties.LoadingText : LoadingScreenProperties.FinishedText;
		}

		private void SineScaleInfoText()
		{
			float scale = _sineAmplitude * Mathf.Sin(Time.unscaledTime * _sineFrequency) + 1;
			_infoText.transform.localScale = scale * Vector3.one;
		}
		#endregion
	}
}