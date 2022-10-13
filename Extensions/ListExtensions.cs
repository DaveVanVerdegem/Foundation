using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
			if (list.Count == 0)
				throw new System.IndexOutOfRangeException("Cannot select a random item from an empty list.");

			return list[UnityEngine.Random.Range(0, list.Count)];
		}

		/// <summary>
		/// Returns a random object from this list.
		/// </summary>
		/// <typeparam name="T">Object type.</typeparam>
		/// <param name="list">List to return random object from.</param>
		/// <param name="exclusions">Objects that are excluded.</param>
		/// <returns>Returns random object.</returns>
		public static T Random<T>(this List<T> list, List<T> exclusions)
		{
			if(list.Count == 0)
				throw new System.IndexOutOfRangeException("Cannot select a random item from an empty list.");

			List<T> selectionList = new List<T>(list);

			for (int i = 0; i < exclusions.Count; i++)
				selectionList.Remove(exclusions[i]);

			if(selectionList.Count == 0)
				throw new System.IndexOutOfRangeException("No items left over after excluding. Cannot select a random item from an empty list.");

			return selectionList[UnityEngine.Random.Range(0, selectionList.Count)];
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

		/// <summary>
		/// Shuffle the list in place using the Fisher-Yates method.
		/// </summary>
		/// <param name="list">List to shuffle.</param>
		public static void Shuffle<T>(this IList<T> list)
		{
			System.Random rng = new System.Random();
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = rng.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}

		/// <summary>
		/// Orders the given list of MonoBehaviours by distance.
		/// </summary>
		/// <param name="list">List to sort.</param>
		/// <param name="position">Position to calculate distance from.</param>
		/// <returns>Returns an ordered list, starting with the closest object.</returns>
		public static List<T> OrderByDistance<T>(this List<T> list, Vector3 position) where T: MonoBehaviour
		{
			return list.OrderBy(x => Vector2.Distance(position, x.transform.position)).ToList();
		}
	} 
}
