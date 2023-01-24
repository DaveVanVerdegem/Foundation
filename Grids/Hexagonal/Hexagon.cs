using Foundation.Helpers;
using System;
using UnityEngine;

namespace Foundation.Grids.Hexagonal
{
	/// <summary>
	/// Implementation following the guidelines at https://www.redblobgames.com/grids/hexagons/implementation.html
	/// </summary>
	[Serializable]
	public class Hexagon : MonoBehaviour
	{
		#region Inspector Fields
		private float _size = 1f;
		private HexagonCoordinates _coordinates = HexagonCoordinates.Zero;
		#endregion

		#region Properties
		public float Size => _size;
		public HexagonCoordinates Coordinates => _coordinates;

		public float Width => Mathf.Sqrt(3) * Size;
		public float Height => 2 * Size;
		#endregion

		#region Life Cycle
		public void Initialize(HexagonCoordinates coordinates)
		{
			_coordinates = coordinates;
		}
		#endregion

		#region Methods
		public void SetCoordinates(HexagonCoordinates coordinates)
		{
			_coordinates = coordinates;
		}

		public int GetDirectionFromTile(Hexagon hexagon)
		{
			return HexagonalDirections.Get(HexagonCoordinates.Subtract(Coordinates, hexagon.Coordinates).Normalized().ToVector3Int());
		}
		#endregion

		#region Position Conversion
		public Vector3 ToWorldPosition() => Coordinates.ToWorldPosition(Size);
		#endregion
	}
}