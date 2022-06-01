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
		#endregion
	} 
}