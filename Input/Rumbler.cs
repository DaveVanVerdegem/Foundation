using Foundation.Helpers;
using Foundation.Patterns;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Foundation.Input
{
	public class Rumbler: Singleton<Rumbler>
	{
		#region Fields
		/// <summary>
		/// Timer to keep track of the rumble duration.
		/// </summary>
		private Timer _timer = null;
		#endregion

		#region Life Cycle
		private void Update()
		{
			if (Instance._timer == null) return;

			_timer.Update(Time.deltaTime);
		}

		private void OnDestroy()
		{
			// Make sure to disable the motors when the object is destroyed. Else the controller will keep rumbling.
			DisableMotors();
		}
		#endregion

		#region Methods
		/// <summary>
		/// Rumble the controller for a specific duration.
		/// </summary>
		/// <param name="duration">Duration to rumble the controller for in seconds.</param>
		/// <param name="lowFrequency">Rumble strength for the low-frequency motor (left).</param>
		/// <param name="highFrequency">Rumble strength for the high-frequency motor (right).</param>
		public static void Rumble(float duration, float lowFrequency, float highFrequency)
		{
			Instance._timer = new Timer(duration);
			Instance._timer.OnCompleted += DisableMotors;

			Gamepad.current.SetMotorSpeeds(lowFrequency, highFrequency);
		}

		/// <summary>
		/// Disable the motors of the controller.
		/// </summary>
		private static void DisableMotors()
		{
			Gamepad.current.SetMotorSpeeds(0, 0);
		}
		#endregion
	}
}
