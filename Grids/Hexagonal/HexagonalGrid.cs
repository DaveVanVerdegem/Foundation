using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Grids.Hexagonal
{
	public class HexagonalGrid
	{
		#region Properties
		public List<Hexagon> Hexagons => _hexagons;
		#endregion

		#region Fields
		private List<Hexagon> _hexagons = new List<Hexagon>();
		#endregion

		#region Constructors
		public HexagonalGrid(int radius)
		{
			for (int q = -radius; q <= radius; q++)
			{
				int r1 = Mathf.Max(-radius, -q - radius);
				int r2 = Mathf.Min(radius, -q + radius);

				for (int r = r1; r <= r2; r++)
				{
					_hexagons.Add(new Hexagon(q, r, -q - r));
				}
			}
		}
		#endregion

		#region Static Methods
		public static HexagonalGrid Instantiate(int radius, Transform parent, HexagonTile hexagonPrefab)
		{
			HexagonalGrid hexagonalGrid = new HexagonalGrid(radius);

			PlaceTiles(hexagonalGrid, hexagonPrefab, parent);

			return hexagonalGrid;
		}

		private static void PlaceTiles(HexagonalGrid grid, HexagonTile hexagonPrefab, Transform parent)
		{
			foreach (Hexagon hexagon in grid.Hexagons)
			{
				HexagonTile tile = Object.Instantiate(hexagonPrefab, parent.position + hexagon.ToWorldPosition(), Quaternion.identity, parent);
				tile.Hexagon = hexagon;
				hexagon.HexagonTile = tile;
			}
		}
		#endregion
	}
}
