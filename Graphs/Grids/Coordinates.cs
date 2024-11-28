using System;
using UnityEngine;

namespace Foundation.Graphs.Grids
{
	public abstract class Coordinates : IEquatable<Coordinates>
	{
		#region Equality Methods
		public static bool operator ==(Coordinates a, Coordinates b)
		{
			if (ReferenceEquals(null, a) && ReferenceEquals(null, b))
				return true;

			if (ReferenceEquals(null, a) || ReferenceEquals(null, b))
				return false;

			return false;
		}

		public static bool operator !=(Coordinates a, Coordinates b)
			=> !(a == b);

		public bool Equals(Coordinates other)
			=> this == other;

		public override bool Equals(object o)
		{
			if (o == null)
				return false;

			return Equals(o as Coordinates);
		}

		public abstract override int GetHashCode();
		#endregion

		//#region Arithmetic Methods
		//public static HexagonalCoordinates Add(HexagonalCoordinates a, HexagonalCoordinates b)
		//	=> new HexagonalCoordinates(a.Q + b.Q, a.R + b.R, a.S + b.S);

		//public static HexagonalCoordinates Add(HexagonalCoordinates a, Vector3Int vector)
		//	=> Add(a, new HexagonalCoordinates(vector.x, vector.y, vector.z));

		//public static HexagonalCoordinates Subtract(HexagonalCoordinates a, HexagonalCoordinates b)
		//	=> new HexagonalCoordinates(a.Q - b.Q, a.R - b.R, a.S - b.S);

		//public static HexagonalCoordinates Subtract(HexagonalCoordinates a, Vector3Int vector)
		//	=> Subtract(a, new HexagonalCoordinates(vector.x, vector.y, vector.z));

		//public static HexagonalCoordinates Multiply(HexagonalCoordinates a, int k)
		//	=> new HexagonalCoordinates(a.Q * k, a.R * k, a.S * k);
		//#endregion

		//#region Distance Methods
		//public static int Length(HexagonalCoordinates coordinates)
		//	=> Mathf.RoundToInt(Math.Abs(coordinates.Q) + Math.Abs(coordinates.R) + Math.Abs(coordinates.S) / 2);

		//public int Length()
		//	=> Length(this);

		//public static int Distance(HexagonalCoordinates a, HexagonalCoordinates b)
		//	=> Length(Subtract(a, b));

		//public HexagonalCoordinates Normalized()
		//	=> Normalized(this);

		//public static HexagonalCoordinates Normalized(HexagonalCoordinates coordinates)
		//{
		//	int normalizedQ = Mathf.Clamp(coordinates.Q, -1, 1);
		//	int normalizedR = Mathf.Clamp(coordinates.R, -1, 1);
		//	int normalizedS = Mathf.Clamp(coordinates.S, -1, 1);

		//	return new HexagonalCoordinates(normalizedQ, normalizedR, normalizedS);
		//}
		//#endregion

		//#region Neighbor Methods
		//public Vector3Int Direction(int direction /* 0 to 5 */)
		//	=> HexagonalDirections.Get(direction);

		//public static Coordinates Neighbour(Coordinates hexagon, int direction)
		//	=> Add(hexagon, hexagon.Direction(direction));
		//#endregion

		//#region Position Conversion
		//public Vector3 ToWorldPosition(float size)
		//{
		//	float x = size * Mathf.Sqrt(3) * Q + Mathf.Sqrt(3) / 2 * R;
		//	float y = size * 3 / 2 * R;

		//	return new Vector3(x, 0, y);
		//}
		//#endregion

		#region Convertors
		public abstract Vector3Int ToVector3Int();
		#endregion
	}
}
