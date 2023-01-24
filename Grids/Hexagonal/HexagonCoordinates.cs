using Foundation.Helpers;
using System;
using UnityEngine;

namespace Foundation.Grids.Hexagonal
{
	public struct HexagonCoordinates : IEquatable<HexagonCoordinates>
	{
		#region Properties
		public int Q;
		public int R;
		public int S;
		#endregion

		#region Static Properties
		public static HexagonCoordinates Zero => new HexagonCoordinates(0, 0, 0);
		#endregion

		#region Constructors
		public HexagonCoordinates(int q, int r, int s)
		{
			if (q + r + s != 0)
				throw new Exception("Hexagon coordinates don't add up to 0.");

			Q = q;
			R = r;
			S = s;
		}
		#endregion

		#region Equality Methods
		public static bool operator ==(HexagonCoordinates a, HexagonCoordinates b)
		{
			if (ReferenceEquals(null, a) && ReferenceEquals(null, b))
				return true;

			if (ReferenceEquals(null, a) || ReferenceEquals(null, b))
				return false;

			return a.Q == b.Q && a.R == b.R && a.S == b.S;
		}

		public static bool operator !=(HexagonCoordinates a, HexagonCoordinates b)
			=> !(a == b);

		public bool Equals(HexagonCoordinates other)
			=> this == other;

		public override bool Equals(object o)
		{
			if (o == null)
				return false;

			return Equals(o);
		}

		public override int GetHashCode()
		{
			int hashCode = -1013937445;
			hashCode = hashCode * -1521134295 + Q.GetHashCode();
			hashCode = hashCode * -1521134295 + R.GetHashCode();
			hashCode = hashCode * -1521134295 + S.GetHashCode();
			return hashCode;
		}
		#endregion

		#region Arithmetic Methods
		public static HexagonCoordinates Add(HexagonCoordinates a, HexagonCoordinates b)
			=> new HexagonCoordinates(a.Q + b.Q, a.R + b.R, a.S + b.S);

		public static HexagonCoordinates Add(HexagonCoordinates a, Vector3Int vector)
			=> Add(a, new HexagonCoordinates(vector.x, vector.y, vector.z));

		public static HexagonCoordinates Subtract(HexagonCoordinates a, HexagonCoordinates b)
			=> new HexagonCoordinates(a.Q - b.Q, a.R - b.R, a.S - b.S);

		public static HexagonCoordinates Subtract(HexagonCoordinates a, Vector3Int vector)
			=> Subtract(a, new HexagonCoordinates(vector.x, vector.y, vector.z));

		public static HexagonCoordinates Multiply(HexagonCoordinates a, int k)
			=> new HexagonCoordinates(a.Q * k, a.R * k, a.S * k);
		#endregion

		#region Distance Methods
		public static int Length(HexagonCoordinates coordinates)
			=> Mathf.RoundToInt(Math.Abs(coordinates.Q) + Math.Abs(coordinates.R) + Math.Abs(coordinates.S) / 2);

		public int Length()
			=> Length(this);

		public static int Distance(HexagonCoordinates a, HexagonCoordinates b)
			=> Length(Subtract(a, b));

		public HexagonCoordinates Normalized()
			=> Normalized(this);

		public static HexagonCoordinates Normalized(HexagonCoordinates coordinates)
		{
			int normalizedQ = Mathf.Clamp(coordinates.Q, -1, 1);
			int normalizedR = Mathf.Clamp(coordinates.R, -1, 1);
			int normalizedS = Mathf.Clamp(coordinates.S, -1, 1);

			return new HexagonCoordinates(normalizedQ, normalizedR, normalizedS);
		}
		#endregion

		#region Neighbor Methods
		public Vector3Int Direction(int direction /* 0 to 5 */)
			=> HexagonalDirections.Get(direction);

		public static HexagonCoordinates Neighbour(HexagonCoordinates hexagon, int direction)
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
		public Vector3Int ToVector3Int() => new Vector3Int(Q, R, S);

		public override string ToString() => $"({Q}, {R}, {S})";
		#endregion
	}
}