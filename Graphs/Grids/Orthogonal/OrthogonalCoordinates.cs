using Foundation.Helpers;
using System;
using UnityEngine;

namespace Foundation.Graphs.Grids.Orthogonal
{
	public class OrthogonalCoordinates : Coordinates
	{
		#region Properties
		public readonly int X;
		public readonly int Y;
		#endregion

		#region Static Properties
		public static OrthogonalCoordinates Zero => new OrthogonalCoordinates(0, 0);
		#endregion

		#region Constructors
		public OrthogonalCoordinates(int x, int y)
		{
			X = x;
			Y = y;
		}
		#endregion

		#region Equality Methods
		public static bool operator ==(OrthogonalCoordinates a, OrthogonalCoordinates b)
		{
			if (ReferenceEquals(null, a) && ReferenceEquals(null, b))
				return true;

			if (ReferenceEquals(null, a) || ReferenceEquals(null, b))
				return false;

			return a.X == b.X && a.Y == b.Y;
		}

		public static bool operator !=(OrthogonalCoordinates a, OrthogonalCoordinates b)
			=> !(a == b);

		public override bool Equals(object o)
		{
			if (o == null)
				return false;

			return Equals(o);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(X, Y);
		}
		#endregion

		#region Arithmetic Methods
		public static OrthogonalCoordinates Add(OrthogonalCoordinates a, OrthogonalCoordinates b)
			=> new OrthogonalCoordinates(a.X + b.X, a.Y + b.Y);

		public static OrthogonalCoordinates Add(OrthogonalCoordinates a, Vector2Int vector)
			=> Add(a, new OrthogonalCoordinates(vector.x, vector.y));

		public static OrthogonalCoordinates Add(OrthogonalCoordinates a, Vector3Int vector)
			=> Add(a, new OrthogonalCoordinates(vector.x, vector.y));

		public static OrthogonalCoordinates Subtract(OrthogonalCoordinates a, OrthogonalCoordinates b)
			=> new OrthogonalCoordinates(a.X - b.X, a.Y - b.Y);

		public static OrthogonalCoordinates Subtract(OrthogonalCoordinates a, Vector2Int vector)
	=> Subtract(a, new OrthogonalCoordinates(vector.x, vector.y));

		public static OrthogonalCoordinates Subtract(OrthogonalCoordinates a, Vector3Int vector)
			=> Subtract(a, new OrthogonalCoordinates(vector.x, vector.y));

		public static OrthogonalCoordinates Multiply(OrthogonalCoordinates a, int k)
			=> new OrthogonalCoordinates(a.X * k, a.Y * k);
		#endregion

		#region Distance Methods
		// HACK: Not sure if this is the intended behavior for the length.
		public static int Length(OrthogonalCoordinates coordinates)
			=> Mathf.RoundToInt(new Vector2(coordinates.X, coordinates.Y).magnitude);

		public int Length()
			=> Length(this);

		public static int Distance(OrthogonalCoordinates a, OrthogonalCoordinates b)
			=> Length(Subtract(a, b));

		public OrthogonalCoordinates Normalized()
			=> Normalized(this);

		public static OrthogonalCoordinates Normalized(OrthogonalCoordinates coordinates)
		{
			int normalizedX = Mathf.Clamp(coordinates.X, -1, 1);
			int normalizedY = Mathf.Clamp(coordinates.Y, -1, 1);

			return new OrthogonalCoordinates(normalizedX, normalizedY);
		}
		#endregion

		#region Neighbor Methods
		public Vector3Int Direction(int direction /* 0 to 5 */)
			=> HexagonalDirections.Get(direction);

		public static OrthogonalCoordinates Neighbour(OrthogonalCoordinates cell, int direction)
			=> Add(cell, cell.Direction(direction));
		#endregion

		#region Position Conversion
		public Vector3 ToWorldPosition(Vector2 cellSize)
		{
			return new Vector3(X * cellSize.x, 0, Y * cellSize.y);
		}
		#endregion

		#region Convertors
		public override Vector3Int ToVector3Int() => new Vector3Int(X, Y, 0);

		public override string ToString() => $"({X}, {Y})";
		#endregion
	}
}