using Foundation.Helpers;
using System;
using UnityEngine;

namespace Foundation.Graphs.Grids.Hexagonal
{
	/// <summary>
	/// Implementation following the guidelines at https://www.redblobgames.com/grids/hexagons/implementation.html
	/// </summary>
	[Serializable]
	public class HexagonalCell : Cell<HexagonalCoordinates>
	{
		#region Inspector Fields
		[SerializeField] private float _size = 1f;
		#endregion

		#region Fields
		private HexagonalCoordinates _coordinates = HexagonalCoordinates.Zero;
		#endregion

		#region Properties
		public float Size => _size;
		public override HexagonalCoordinates Coordinates => _coordinates;

		public override float Width => Mathf.Sqrt(3) * Size;
		public override float Height => 2 * Size;
		#endregion

		#region Life Cycle
		public override void Initialize(HexagonalCoordinates coordinates)
		{
			_coordinates = coordinates;
		}
		#endregion

		#region Methods
		public override void SetCoordinates(HexagonalCoordinates coordinates)
		{
			_coordinates = coordinates;
		}

		public override int GetDirectionFromCell(Cell<HexagonalCoordinates> hexagon)
		{
			return HexagonalDirections.Get(HexagonalCoordinates.Subtract(Coordinates, hexagon.Coordinates).Normalized().ToVector3Int());
		}
		#endregion

		#region Position Conversion
		public override Vector3 ToWorldPosition() => Coordinates.ToWorldPosition(Size);
		#endregion
	}
}