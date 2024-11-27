using UnityEngine;

namespace Foundation.Graphs.Grids.Orthogonal
{
	public class OrthogonalCell : Cell<OrthogonalCoordinates>
	{
		#region Fields
		private Vector2 _size;
		private OrthogonalCoordinates _coordinates = OrthogonalCoordinates.Zero;
		#endregion

		#region Properties
		public Vector2 Size => _size;
		public override OrthogonalCoordinates Coordinates => _coordinates;

		public override float Width => Size.x;
		public override float Height => Size.y;
		#endregion

		#region Life Cycle
		public override void Initialize(OrthogonalCoordinates coordinates)
		{
			_coordinates = coordinates;
		}

		public void Initialize(OrthogonalCoordinates coordinates, Vector2 size)
		{
			_coordinates = coordinates;
			_size = size;
		}
		#endregion

		#region Methods
		public override void SetCoordinates(OrthogonalCoordinates coordinates)
		{
			_coordinates = coordinates;
		}

		public override int GetDirectionFromCell(Cell<OrthogonalCoordinates> cell)
		{
			throw new System.NotImplementedException();
			//return HexagonalDirections.Get(HexagonalCoordinates.Subtract(Coordinates, hexagon.Coordinates).Normalized().ToVector3Int());
		}
		#endregion

		#region Position Conversion
		public override Vector3 ToWorldPosition() => Coordinates.ToWorldPosition(Size);
		#endregion
	}
}
