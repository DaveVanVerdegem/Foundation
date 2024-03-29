using System;

namespace Foundation.Helpers
{
	public class Timer
	{
		#region Properties
		/// <summary>
		/// Absolute progress of the timer.
		/// </summary>
		public float Progress => _progress;

		/// <summary>
		/// Normalized progress of the timer, from a range from 0 to 1f.
		/// </summary>
		public float ProgressNormalized => _progress / _duration;

		/// <summary>
		/// Event that gets triggered when the timer completes.
		/// </summary>
		public event Action OnCompleted;
		#endregion

		#region Fields
		private readonly float _duration = 0f;
		private float _progress = 0f;
		#endregion

		#region Constructors
		/// <summary>
		/// Create a new timer with a specific duration.
		/// </summary>
		/// <param name="duration">Duration for the timer.</param>
		public Timer(float duration)
		{
			_duration = duration;
		}
		#endregion

		#region Life Cycle
		/// <summary>
		/// Updates the timer with the time passed. Must be called every frame to keep the timer running.
		/// </summary>
		/// <param name="timePassed"></param>
		public void Update(float timePassed)
		{
			_progress += timePassed;

			if (_progress >= _duration)
			{
				OnCompleted?.Invoke();
				_progress -= _duration;
			}
		}

		/// <summary>
		/// Reset the timer to its initial state.
		/// </summary>
		public void Reset()
		{
			_progress = 0f;
		}
		#endregion
	}
}
