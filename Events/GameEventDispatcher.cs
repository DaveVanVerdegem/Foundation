using Foundation.Patterns;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Foundation.Events
{
	public class GameEventDispatcher: Singleton<GameEventDispatcher>
	{
		#region Fields
		/// <summary>
		/// Dictionary with all the events and their types.
		/// </summary>
		private Dictionary<BaseGameEventType, UnityGameEvent> _gameEvents = new Dictionary<BaseGameEventType, UnityGameEvent>(new MyClassSpecialComparer());
		#endregion

		#region Methods
		/// <summary>
		/// Add a listener of a certain type to the dispatcher.
		/// </summary>
		/// <param name="type">Type of the event.</param>
		/// <param name="call">Callback when the event is triggered.</param>
		public static void AddListener(BaseGameEventType type, UnityAction<BaseGameEvent> call)
		{
			UnityGameEvent unityEvent = null;
			if(Instance._gameEvents.TryGetValue(type, out unityEvent))
			{
				unityEvent.AddListener(call);
			}
			else
			{
				unityEvent = new UnityGameEvent();
				unityEvent.AddListener(call);
				Instance._gameEvents.Add(type, unityEvent);
			}
		}

		/// <summary>
		/// Remove a listener of a certain type from the dispatcher.
		/// </summary>
		/// <param name="type">Type of the listener.</param>
		/// <param name="call">Callback of the event.</param>
		public static void RemoveListener(BaseGameEventType type, UnityAction<BaseGameEvent> call)
		{
			UnityGameEvent unityEvent = null;
			if (Instance._gameEvents.TryGetValue(type, out unityEvent))
				unityEvent.RemoveListener(call);
		}

		public static void RemoveAllListeners(BaseGameEventType type)
		{
			UnityGameEvent unityEvent = null;
			if (Instance._gameEvents.TryGetValue(type, out unityEvent))
				unityEvent.RemoveAllListeners();
		}

		/// <summary>
		/// Dispatches a game event.
		/// </summary>
		/// <param name="gameEvent">Event to dispatch.</param>
		public static void Dispatch(BaseGameEvent gameEvent)
		{
			UnityGameEvent unityEvent;
			if (Instance._gameEvents.TryGetValue(gameEvent.EventType, out unityEvent))
				unityEvent.Invoke(gameEvent);
		}
		#endregion
	}

	public class MyClassSpecialComparer : IEqualityComparer<BaseGameEventType>
	{
		public bool Equals(BaseGameEventType x, BaseGameEventType y)
		{
			return x.Value == y.Value;
	
	}

		public int GetHashCode(BaseGameEventType x)
		{
			return x.Value;
			//throw new NotImplementedException();
			//return x.GetHashCode();
		}


	}
}
