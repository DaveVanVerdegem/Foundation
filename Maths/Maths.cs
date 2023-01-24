using UnityEngine;

namespace Foundation.Maths
{
	public static class Maths
	{
		#region Angles
		/// <summary>
		/// Returns the angle that a vector points in on a flat plane. Where a Vector2.up returns 0 and continues clockwise.
		/// </summary>
		/// <param name="x">Horizontal value of the vector.</param>
		/// <param name="y">Vertical value of the vector.</param>
		/// <returns>Returns a value between 0 and 360.</returns>
		public static float GetAngle(float x, float y)
		{
			float angle = Mathf.Atan2(x, y) * Mathf.Rad2Deg;

			if (x < 0)
				angle += 360f;

			return angle;
		}

		/// <summary>
		/// Returns the angle that a vector points in on a flat plane. Where a Vector2.up returns 0 and continues clockwise.
		/// </summary>
		/// <param name="vector">Vector to process.</param>
		/// <returns>Returns a value between 0 and 360.</returns>
		public static float GetAngle(Vector2 vector) => GetAngle(vector.x, vector.y);
		#endregion
	}
}

