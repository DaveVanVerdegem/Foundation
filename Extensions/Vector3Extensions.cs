using UnityEngine;

namespace Foundation.Extensions
{
	public static class Vector3Extensions
	{
		#region Methods
		/// <summary>
		/// Converts a Vector3 to a Vector2 variable.
		/// </summary>
		/// <param name="vector3">Value to convert.</param>
		/// <returns>Returns Vector3 value.</returns>
		public static Vector2 ToVector2(this Vector3 vector3)
		{
			return new Vector2(vector3.x, vector3.y);
		}
		#endregion
	}
}