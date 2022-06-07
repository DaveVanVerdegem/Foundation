namespace Foundation.Extensions
{
	public static class FloatExtensions
	{
		#region Methods
		/// <summary>
		/// Remaps a value from one range to another scale range.
		/// </summary>
		/// <param name="value">Value to remap.</param>
		/// <param name="minimumTargetValue">Starting point of new range.</param>
		/// <param name="maximumTargetValue">End point of new range.</param>
		/// <param name="minimumStartValue">Starting point of current range.</param>
		/// <param name="maximumStartValue">End point of current range.</param>
		/// <returns>Returns remapped value.</returns>
		public static float Remap(this float value, float minimumTargetValue, float maximumTargetValue, float minimumStartValue = 0, float maximumStartValue = 1)
		{
			return (value - minimumStartValue) / (maximumStartValue - minimumStartValue) * (maximumTargetValue - minimumTargetValue) + minimumTargetValue;
		}

		/// <summary>
		/// Subtracts the given value from 1 (1-x).
		/// </summary>
		/// <param name="value">Value to subtract from 1.</param>
		/// <returns>The remainder after subtracting.</returns>
		public static float OneMinus(this float value)
		{
			return 1f - value;
		}

		public static int Sign(this float value)
		{
			return value < 0 ? -1 : 1;
		}
		#endregion
	} 
}
