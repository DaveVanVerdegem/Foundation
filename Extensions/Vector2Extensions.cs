using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Extensions
{
	public static class Vector2Extensions
	{
		#region Methods
		/// <summary>
		/// Converts a Vector2 to a Vector3 variable where x,y axis stay on relevant alignment.
		/// </summary>
		/// <param name="vector2">Value to convert.</param>
		/// <param name="z">Z value to pass through.</param>
		/// <returns>Returns Vector3 value.</returns>
		public static Vector3 ToVector3(this Vector2 vector2, float z = 0)
		{
			return new Vector3(vector2.x, vector2.y, z);
		}

		/// <summary>
		/// Converts a Vector2 to a Vector3 variable where y-axis is remapped to z-axis.
		/// </summary>
		/// <param name="vector2">Value to convert.</param>
		/// <param name="y">Y value to pass through.</param>
		/// <returns>Returns Vector3 value.</returns>
		public static Vector3 ToVector3Top(this Vector2 vector2, float y = 0)
		{
			return new Vector3(vector2.x, y, vector2.y);
		}

		/// <summary>
		/// Returns the average vector of a list of vectors.
		/// </summary>
		/// <param name="vectors">List of vectors to calculate average from.</param>
		/// <returns>Returns average as a Vector2.</returns>
		public static Vector2 Average(List<Vector2> vectors)
		{
			Vector2 average = Vector2.zero;

			for (int i = 0; i < vectors.Count; i++)
			{
				average += vectors[i];
			}

			return average / vectors.Count;
		}

		/// <summary>
		/// Returns the average vector of a list of vectors.
		/// </summary>
		/// <param name="vector2"></param>
		/// <param name="vectors">List of vectors to calculate average from.</param>
		/// <returns>Returns average as a Vector2.</returns>
		public static Vector2 Average(this Vector2 vector2, List<Vector2> vectors)
		{
			return Average(vectors);
		}
		#endregion
	} 
}
