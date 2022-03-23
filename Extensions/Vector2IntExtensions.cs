using UnityEngine;

namespace Foundation.Extensions
{
	public static class Vector2IntExtensions
	{
		#region Methods
		/// <summary>
		/// Converts a Vector2Int to a Vector3 variable.
		/// </summary>
		/// <param name="vector2Int">Value to convert.</param>
		/// <param name="z">Z value to pass through.</param>
		/// <returns>Returns Vector3 value.</returns>
		public static Vector3 ToVector3(this Vector2Int vector2Int, float z = 0)
		{
			return new Vector3(vector2Int.x, vector2Int.y, z);
		}
		#endregion
	} 
}
