using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Extensions
{
	public static class Vector3Extensions
	{
		#region Modifiers
		/// <summary>
		/// Sets the x value of this Vector.
		/// </summary>
		/// <param name="vector3">Vector to adjust.</param>
		/// <param name="x">Value to set.</param>
		/// <returns>Returns adjusted Vector.</returns>
		public static Vector3 SetX(this Vector3 vector3, float x)
		{
			return new Vector3(x, vector3.y, vector3.z);
		}

		/// <summary>
		/// Sets the y value of this Vector.
		/// </summary>
		/// <param name="vector3">Vector to adjust.</param>
		/// <param name="y">Value to set.</param>
		/// <returns>Returns adjusted Vector.</returns>
		public static Vector3 SetY(this Vector3 vector3, float y)
		{
			return new Vector3(vector3.x, y, vector3.z);
		}

		/// <summary>
		/// Sets the z value of this Vector.
		/// </summary>
		/// <param name="vector3">Vector to adjust.</param>
		/// <param name="z">Value to set.</param>
		/// <returns>Returns adjusted Vector.</returns>
		public static Vector3 SetZ(this Vector3 vector3, float z)
		{
			return new Vector3(vector3.x, vector3.y, z);
		}

		/// <summary>
		/// Flattens the given Vector on the Y-axis.
		/// </summary>
		/// <param name="vector3">Vector3 to flatten.</param>
		/// <returns>Returns a flattened Vector3</returns>
		public static Vector3 Flattened(this Vector3 vector3)
		{
			return new Vector3(vector3.x, 0f, vector3.z);
		}

		/// <summary>
		/// Rounds the given Vector to a whole number.
		/// </summary>
		/// <param name="vector3">Vector3 to round.</param>
		/// <returns>Returns a Vector3 consisting of whole numbers.</returns>
		public static Vector3 Round(this Vector3 vector3)
		{
			return new Vector3(Mathf.Round(vector3.x), Mathf.Round(vector3.y), Mathf.Round(vector3.z));
		}

		/// <summary>
		/// Rounds the given Vector to a Vector3Int.
		/// </summary>
		/// <param name="vector3">Vector3 to round.</param>
		/// <returns>Returns a Vector3Int.</returns>
		public static Vector3Int RoundToInt(this Vector3 vector3)
		{
			return new Vector3Int(Mathf.RoundToInt(vector3.x), Mathf.RoundToInt(vector3.y), Mathf.RoundToInt(vector3.z));
		}

		/// <summary>
		/// Floors the given Vector to a whole number.
		/// </summary>
		/// <param name="vector3">Vector3 to floor.</param>
		/// <returns>Returns a Vector3 consisting of whole numbers.</returns>
		public static Vector3 Floor(this Vector3 vector3)
		{
			return new Vector3(Mathf.Floor(vector3.x), Mathf.Floor(vector3.y), Mathf.Floor(vector3.z));
		}

		/// <summary>
		/// Ceils the given Vector to a whole number.
		/// </summary>
		/// <param name="vector3">Vector3 to ceil.</param>
		/// <returns>Returns a Vector3 consisting of whole numbers.</returns>
		public static Vector3 Ceil(this Vector3 vector3)
		{
			return new Vector3(Mathf.Ceil(vector3.x), Mathf.Ceil(vector3.y), Mathf.Ceil(vector3.z));
		}

		/// <summary>
		/// Returns a random Vector3 between the given minimum and maximum values.
		/// </summary>
		/// <param name="minimum">Minimum inclusive value possible.</param>
		/// <param name="maximum">Maximum inclusive value possible.</param>
		/// <returns>Returns a Vector3 randomized between the given values.</returns>
		public static Vector3 Random(Vector3 minimum, Vector3 maximum)
		{
			return new Vector3(
				UnityEngine.Random.Range(minimum.x, maximum.x), 
				UnityEngine.Random.Range(minimum.y, maximum.y), 
				UnityEngine.Random.Range(minimum.z, maximum.z));
		}

		/// <summary>
		/// Returns a random Vector3 between 0 and 1.
		/// </summary>
		/// <returns>Returns a random Vector3 between 0 and 1.</returns>
		public static Vector3 Random()
		{
			return Random(Vector3.zero, Vector3.one);
		}

		/// <summary>
		/// Returns a random Vector3 between the given minimum and maximum values with a uniform range.
		/// </summary>
		/// <param name="minimum">Minimum value.</param>
		/// <param name="maximum">Maximum value.</param>
		/// <returns>Returns a random Vector3 where each value is the same.</returns>
		public static Vector3 RandomUniform(float minimum, float maximum)
		{
			float random = UnityEngine.Random.Range(minimum, maximum);

			return Vector3.one * random;
		}
		#endregion

		#region Convertors
		/// <summary>
		/// Converts a Vector3 to a Vector2 variable.
		/// </summary>
		/// <param name="vector3">Value to convert.</param>
		/// <returns>Returns Vector2 value.</returns>
		public static Vector2 ToVector2(this Vector3 vector3)
		{
			return new Vector2(vector3.x, vector3.y);
		}

		/// <summary>
		/// Converts a Vector3 to a Vector2 variable where the y-axis is discarded.
		/// </summary>
		/// <param name="vector3">Value to convert.</param>
		/// <returns>Returns a Vector2 value from the x and z values of the given Vector3.</returns>
		public static Vector2 ToVector2FromTop(this Vector3 vector3)
		{
			return new Vector2(vector3.x, vector3.z);
		}
		#endregion

		#region Methods
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

		/// <summary>
		/// Returns the normalized direction to another position.
		/// </summary>
		/// <param name="vector3">Origin position.</param>
		/// <param name="target">Target position.</param>
		/// <returns>Returns a direction as a normalized Vector3.</returns>
		public static Vector3 DirectionTo(this Vector3 vector3, Vector3 target)
		{
			return (target - vector3).normalized;
		}

		/// <summary>
		/// Calculates a distance over a flat plane.
		/// </summary>
		/// <param name="origin">Starting position.</param>
		/// <param name="target">Target position.</param>
		/// <returns>Returns the distance as a float.</returns>
		public static float DistanceFlat(this Vector3 origin, Vector3 target)
		{
			return Vector3.Distance(origin.Flattened(), target.Flattened());
		}

		/// <summary>
		/// Returns the nearest point on an axis that passes through zero.
		/// </summary>
		/// <param name="axisDirection">Direction of the axis to find point on.</param>
		/// <param name="position">Point to approximate.</param>
		/// <param name="isNormalized">True if the axis direction is normalized.</param>
		/// <returns>Returns the nearest point on the axis, to the given position.</returns>
		public static Vector3 NearestPointOnAxis(this Vector3 axisDirection, Vector3 position, bool isNormalized = false)
		{
			if (!isNormalized) axisDirection.Normalize();

			float dot = Vector3.Dot(position, axisDirection);
			return axisDirection * dot;
		}

		// lineDirection - unit vector in direction of line
		// pointOnLine - a point on the line (allowing us to define an actual line in space)
		// point - the point to find nearest on line for

		/// <summary>
		/// Returns the nearest point on a vector line.
		/// </summary>
		/// <param name="lineDirection">Direction of vector line.</param>
		/// <param name="position">Position to approximate.</param>
		/// <param name="pointOnLine">A point on the line that helps us place the line in space.</param>
		/// <param name="isNormalized">True if the line direction is normalized.</param>
		/// <returns>Returns the nearest point on the line direction, to the given position.</returns>
		public static Vector3 NearestPointOnLine(this Vector3 lineDirection, Vector3 position, Vector3 pointOnLine, bool isNormalized = false)
		{
			if (!isNormalized) lineDirection.Normalize();

			float dot = Vector3.Dot(position - pointOnLine, lineDirection);
			return pointOnLine + (lineDirection * dot);
		}
		#endregion
	}
}