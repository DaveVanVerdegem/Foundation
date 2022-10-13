using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Extensions
{
	public static class Vector2Extensions
	{
		#region Modifiers
		/// <summary>
		/// Sets the x value of this Vector.
		/// </summary>
		/// <param name="vector2">Vector to adjust.</param>
		/// <param name="x">Value to set.</param>
		/// <returns>Returns adjusted Vector.</returns>
		public static Vector2 SetX(this Vector2 vector2, float x)
		{
			return new Vector2(x, vector2.y);
		}

		/// <summary>
		/// Sets the y value of this Vector.
		/// </summary>
		/// <param name="vector2">Vector to adjust.</param>
		/// <param name="y">Value to set.</param>
		/// <returns>Returns adjusted Vector.</returns>
		public static Vector2 SetY(this Vector2 vector2, float y)
		{
			return new Vector2(vector2.x, y);
		}

		/// <summary>
		/// Rounds the given Vector to a whole number.
		/// </summary>
		/// <param name="vector2">Vector2 to round.</param>
		/// <returns>Returns a Vector2 consisting of whole numbers.</returns>
		public static Vector2 Round(this Vector2 vector2)
		{
			return new Vector2(Mathf.Round(vector2.x), Mathf.Round(vector2.y));
		}

		/// <summary>
		/// Floors the given Vector to a whole number.
		/// </summary>
		/// <param name="vector2">Vector3 to floor.</param>
		/// <returns>Returns a Vector3 consisting of whole numbers.</returns>
		public static Vector2 Floor(this Vector2 vector2)
		{
			return new Vector2(Mathf.Floor(vector2.x), Mathf.Floor(vector2.y));
		}

		/// <summary>
		/// Ceils the given Vector to a whole number.
		/// </summary>
		/// <param name="vector2">Vector2 to ceil.</param>
		/// <returns>Returns a Vector2 consisting of whole numbers.</returns>
		public static Vector2 Ceil(this Vector2 vector2)
		{
			return new Vector2(Mathf.Ceil(vector2.x), Mathf.Ceil(vector2.y));
		}
		#endregion

		#region Convertors
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
		#endregion

		#region Methods
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

		/// <summary>
		/// Returns the normalized direction to another position.
		/// </summary>
		/// <param name="vector2">Origin position.</param>
		/// <param name="target">Target position.</param>
		/// <returns>Returns a direction as a normalized Vector2.</returns>
		public static Vector2 DirectionTo(this Vector2 vector2, Vector2 target)
		{
			return (target - vector2).normalized;
		}
		#endregion
	} 
}
