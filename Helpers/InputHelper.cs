using System;
using UnityEngine;
using UnityEngine.Events;
#if ENABLE_INPUT_SYSTEM
    // New input system backends are enabled.
	using UnityEngine.InputSystem;
#endif


namespace Foundation.Helpers
{
	[AddComponentMenu("Foundation/Input Helper")]
	public class InputHelper : MonoBehaviour
	{
#if ENABLE_INPUT_SYSTEM
		#region Enums
		public enum ControlScheme
		{
			KeyboardMouse = 0,
			Gamepad = 1,
			Touch = 2,
			Joystick = 3,
			XR = 4,
		}
		#endregion

		#region Inspector Fields

		// New input system backends are enabled.
		[SerializeField] private PlayerInput _playerInput = null;

		[Header("Events")]
		public UnityEvent<ControlScheme> OnControlSchemeChanged = new UnityEvent<ControlScheme>();
		#endregion

		#region Fields
		private ControlScheme _currentControlScheme = ControlScheme.KeyboardMouse;
		#endregion

		#region Life Cycle
		private void Awake()
		{
			if (_playerInput == null)
			{
				_playerInput = FindObjectOfType<PlayerInput>();

				if (_playerInput = null)
					throw new NullReferenceException("No PlayerInput component found in the scene.");
			}
		}

		private void Update()
		{
			DetectControlSchemeChange();
		}
		#endregion

		#region Methods
		/// <summary>
		/// Detects if the current control scheme has changed and invokes the OnControlSchemeChanged event.
		/// </summary>
		private void DetectControlSchemeChange()
		{
			ControlScheme controlScheme = ParseControlScheme(_playerInput.currentControlScheme);
			if (_currentControlScheme == controlScheme) return;

			_currentControlScheme = controlScheme;
			OnControlSchemeChanged?.Invoke(_currentControlScheme);
		}

		/// <summary>
		/// Parses the control scheme string to the ControlScheme enum.
		/// </summary>
		/// <param name="controlScheme">Control scheme string from Unity.</param>
		/// <returns>Returns the ControlScheme enum.</returns>
		private ControlScheme ParseControlScheme(string controlScheme)
		{
			return controlScheme switch
			{
				"KeyboardMouse" => ControlScheme.KeyboardMouse,
				"Gamepad" => ControlScheme.Gamepad,
				"Touch" => ControlScheme.Touch,
				"Joystick" => ControlScheme.Joystick,
				"XR" => ControlScheme.XR,
				_ => ControlScheme.KeyboardMouse,
			};
		}
		#endregion
#endif
	}
}
