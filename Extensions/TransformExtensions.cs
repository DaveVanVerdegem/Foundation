using UnityEngine;

namespace Foundation.Extensions
{
	public static class TransformExtensions
	{
		#region Methods
		/// <summary>
		/// Rotates the transform around the Y-axis to look at the given position.
		/// </summary>
		/// <param name="transform">Transform to rotate.</param>
		/// <param name="position">Position to look at.</param>
		public static void LookAtY(this Transform transform, Vector3 position)
		{
			Vector3 lookDirection = position - transform.position;
			lookDirection.y = 0;
			transform.rotation = Quaternion.LookRotation(lookDirection);
		}

		/// <summary>
		/// Rotates the transform around the Z-axis to look at the given position. Useful in 2D space.
		/// </summary>
		/// <param name="transform">Transform to rotate.</param>
		/// <param name="position">Position to look at.</param>
		public static void LookAtZ(this Transform transform, Vector3 position)
		{
			// Get Angle in Radians
			float AngleRadians = Mathf.Atan2(position.y - transform.position.y, position.x - transform.position.x);
			// Get Angle in Degrees
			float AngleDegrees = (180 / Mathf.PI) * AngleRadians;
			// Rotate Object
			transform.rotation = Quaternion.Euler(0, 0, AngleDegrees);
		}

		/// <summary>
		/// Rotates the transform around the Z-axis to look at the given position. Useful in 2D space.
		/// </summary>
		/// <param name="transform">Transform to rotate.</param>
		/// <param name="position">Position to look at.</param>
		public static void LookAtZ(Transform transform, Vector2 position)
		{
			LookAtZ(transform, position.ToVector3());
		}
		#endregion
	} 
}