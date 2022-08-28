using System.Collections.Generic;

namespace Foundation.Events
{
/// <summary>
/// Extendable class that serves as a replacement for (non-existing) extendable enums. To extend on this inherit from this class and define new constants.
/// </summary>
 public class BaseGameEventType : IEqualityComparer<BaseGameEventType>
	{
		#region Values
		/// <summary>
		/// Const value that can be used as an int. This value serves as a default starting point that can be extended on.
		/// </summary>
		public const int None = 0;
		#endregion

		#region Property
		public int Value { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Creates a new reference that can be used to reference to.
		/// </summary>
		/// <param name="value">Value to set to keep the reference.</param>
		public BaseGameEventType(int value)
		{
			Value = value;
		}
		#endregion

		#region Operators
		/// <summary>
		/// Implicit operator that returns its value when the BaseGameEventType object is called. 
		/// This operator allows us to directly get the value of the object without calling a conversion.
		/// </summary>
		/// <param name="eventType">BaseGameEventType to get value for.</param>
		public static implicit operator int(BaseGameEventType eventType)
		{
			return eventType.Value;
		}

		/// <summary>
		/// This implicit operator allows us to get a new BaseGameEventType object based on its relevant value.
		/// </summary>
		/// <param name="value">Value to get relevant BaseGameEventType object for.</param>
		public static implicit operator BaseGameEventType(int value)
		{
			return new BaseGameEventType(value);
		}

		public bool Equals(BaseGameEventType x, BaseGameEventType y)
		{
			return x.Value == y.Value;
		}

		public int GetHashCode(BaseGameEventType obj)
		{
			return obj.GetHashCode();
		}

		public string ToString() => Value.ToString();
		#endregion

	}
}
