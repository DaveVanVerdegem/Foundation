using System.Collections.Generic;
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

		/// <summary>
		/// Returns the average vector of a list of vectors.
		/// </summary>
		/// <param name="vectors">List of vectors to calculate average from.</param>
		/// <returns>Returns average as a Vector3.</returns>
		public static Vector3 Average(List<Vector3> vectors)
		{
			Vector3 average = Vector3.zero;

			for (int i = 0; i < vectors.Count; i++)
			{
				average += vectors[i];
			}

			return average / vectors.Count;
		}

		/// <summary>
		/// Returns the average vector of a list of vectors.
		/// </summary>
		/// <param name="vector3"></param>
		/// <param name="vectors">List of vectors to calculate average from.</param>
		/// <returns>Returns average as a Vector3.</returns>
		public static Vector3 Average(this Vector3 vector3, List<Vector3> vectors)
		{
			return Average(vectors);
		}
		#endregion
	}
}