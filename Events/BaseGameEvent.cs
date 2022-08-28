using System.Collections.Generic;

namespace Foundation.Events
{
	/// <summary>
	/// Base game event class. Inherit from this class to create new Game Events.
	/// </summary>
	public abstract class BaseGameEvent 
	{
		#region Properties
		/// <summary>
		/// Type of this game event.
		/// </summary>
		public BaseGameEventType EventType { get; }
		#endregion

		#region Constructor
		/// <summary>
		/// Creates a new event. Make sure to call Dispatch() on this new event to call it.
		/// </summary>
		/// <param name="eventType">Type for this event. This is used to identify it.</param>
		public BaseGameEvent(BaseGameEventType eventType)
		{
			EventType = eventType;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Dispatches the created event. Call this to trigger the newly created event.
		/// </summary>
		public void Dispatch()
		{
			GameEventDispatcher.Dispatch(this);
		}
		#endregion
	}
}
