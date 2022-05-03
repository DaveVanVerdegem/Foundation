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

		/// <summary>
		/// Adds an item to the list only if it isn't in the list yet.
		/// </summary>
		/// <param name="list">List to add object to.</param>
		/// <param name="item">Object to add.</param>
		/// <returns>Returns true if the object could be added.</returns>
		public static bool AddUnique<T>(this List<T> list, T item)
		{
			if (list.Contains(item))
				return false;

			list.Add(item);
			return true;
		}
	} 
}
