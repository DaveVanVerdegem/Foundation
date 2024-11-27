using Foundation.Helpers;
using System;
using UnityEngine;

namespace Foundation.Graphs.Grids.Hexagonal
{
	public class HexagonalCoordinates : Coordinates
	{
		#region Properties
		public int Q;
		public int R;
		public int S;
		#endregion

		#region Static Properties
		public static HexagonalCoordinates Zero => new HexagonalCoordinates(0, 0, 0);
		#endregion

		#region Constructors
		public HexagonalCoordinates(int q, int r, int s)
		{
			if (q + r + s != 0)
				throw new Exception("Hexagon coordinates don't add up to 0.");

			Q = q;
			R = r;
			S = s;
		}
		#endregion

		#region Equality Methods
		public static bool operator ==(HexagonalCoordinates a, HexagonalCoordinates b)
		{
			if (ReferenceEquals(null, a) && ReferenceEquals(null, b))
				return true;

			if (ReferenceEquals(null, a) || ReferenceEquals(null, b))
				return false;

			return a.Q == b.Q && a.R == b.R && a.S == b.S;
		}

		public static bool operator !=(HexagonalCoordinates a, HexagonalCoordinates b)
			=> !(a == b);

		public bool Equals(HexagonalCoordinates other)
			=> this == other;

		public override bool Equals(object o)
		{
			if (o == null)
				return false;

			return Equals(o);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Q, R, S);
		}
		#endregion

		#region Arithmetic Methods
		public static HexagonalCoordinates Add(HexagonalCoordinates a, HexagonalCoordinates b)
			=> new HexagonalCoordinates(a.Q + b.Q, a.R + b.R, a.S + b.S);

		public static HexagonalCoordinates Add(HexagonalCoordinates a, Vector3Int vector)
			=> Add(a, new HexagonalCoordinates(vector.x, vector.y, vector.z));

		public static HexagonalCoordinates Subtract(HexagonalCoordinates a, HexagonalCoordinates b)
			=> new HexagonalCoordinates(a.Q - b.Q, a.R - b.R, a.S - b.S);

		public static HexagonalCoordinates Subtract(HexagonalCoordinates a, Vector3Int vector)
			=> Subtract(a, new HexagonalCoordinates(vector.x, vector.y, vector.z));

		public static HexagonalCoordinates Multiply(HexagonalCoordinates a, int k)
			=> new HexagonalCoordinates(a.Q * k, a.R * k, a.S * k);
		#endregion

		#region Distance Methods
		public static int Length(HexagonalCoordinates coordinates)
			=> Mathf.RoundToInt(Math.Abs(coordinates.Q) + Math.Abs(coordinates.R) + Math.Abs(coordinates.S) / 2);

		public int Length()
			=> Length(this);

		public static int Distance(HexagonalCoordinates a, HexagonalCoordinates b)
			=> Length(Subtract(a, b));

		public HexagonalCoordinates Normalized()
			=> Normalized(this);

		public static HexagonalCoordinates Normalized(HexagonalCoordinates coordinates)
		{
			int normalizedQ = Mathf.Clamp(coordinates.Q, -1, 1);
			int normalizedR = Mathf.Clamp(coordinates.R, -1, 1);
			int normalizedS = Mathf.Clamp(coordinates.S, -1, 1);

			return new HexagonalCoordinates(normalizedQ, normalizedR, normalizedS);
		}
		#endregion

		#region Neighbor Methods
		public Vector3Int Direction(int direction /* 0 to 5 */)
			=> HexagonalDirections.Get(direction);

		public static HexagonalCoordinates Neighbour(HexagonalCoordinates hexagon, int direction)
			=> Add(hexagon, hexagon.Direction(direction));
		#endregion

		#region Position Conversion
		public Vector3 ToWorldPosition(float size)
		{
			float x = size * Mathf.Sqrt(3) * Q + Mathf.Sqrt(3) / 2 * R;
			float y = size * 3 / 2 * R;

			return new Vector3(x, 0, y);
		}
		#endregion

		#region Convertors
		public override Vector3Int ToVector3Int() => new Vector3Int(Q, R, S);

		public override string ToString() => $"({Q}, {R}, {S})";
		#endregion
	}
}