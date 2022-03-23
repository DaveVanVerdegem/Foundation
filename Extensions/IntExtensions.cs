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
		#endregion
	} 
}
