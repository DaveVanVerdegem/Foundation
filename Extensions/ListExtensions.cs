using System.Collections.Generic;

namespace Foundation.Extensions
{
	public static class ListExtensions
	{
		/// <summary>
		/// Returns a random object from this list.
		/// </summary>
		/// <typeparam name="T">Object type.</typeparam>
		/// <param name="list">List to return random object from.</param>
		/// <returns>Returns random object.</returns>
		public static T Random<T>(this List<T> list)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
	} 
}
