using Foundation.Helpers;
using System;
using UnityEngine;

namespace Foundation.Grids.Hexagonal
{
	public class HexagonTile : MonoBehaviour
	{
		#region Properties
		public Hexagon Hexagon { get; set; }
		#endregion

		#region Methods
		public int GetDirectionFromTile(HexagonTile otherTile)
		{
			return HexagonalDirections.Get(Hexagon.Subtract(Hexagon, otherTile.Hexagon).Normalized().ToVector3Int());
		}
		#endregion
	}
}