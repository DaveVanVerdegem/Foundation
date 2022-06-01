using UnityEngine;

namespace Foundation.Extensions
{
	public static class IntExtensions
	{
		#region Methods
		/// <summary>
		/// Improved modulo method that works on negative numbers as well.
		/// </summary>
		/// <param name="integer">Number to apply modulo on.</param>
		/// <param name="modulo">Modulo to apply.</param>
		/// <returns>Remainder of modulo division.</returns>
		public static int Modulo(this int integer, int modulo)
		{
			return ((integer % modulo) + modulo) % modulo;
		}

		/// <summary>
		/// Randomizes the sign of this int.
		/// </summary>
		/// <param name="value">Int to give randomized sign.</param>
		/// <param name="negativeProbability">Probability to get negative sign.</param>
		/// <returns>Returns int with random sign.</returns>
		public static int RandomizedSign(this int value, float negativeProbability = 0.5f)
		{
			return Random.value < negativeProbability ? -value : value;
		}
		#endregion
	} 
}
