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
				HexagonTile tile = UnityEngine.Object.Instantiate(hexagonPrefab, parent.position + hexagon.ToWorldPosition(), Quaternion.identity, parent);
				tile.Hexagon = hexagon;
				hexagon.HexagonTile = tile;
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Removes a hexagon from the grid.
		/// </summary>
		/// <param name="hexagon">Hexagon tile to remove.</param>
		/// <returns>Returns true if the hexagon was found and succesfully removed.</returns>
		public bool RemoveTile(Hexagon hexagon)
		{
			if (hexagon is null) return false;
			if (!_hexagons.Contains(hexagon)) return false;

			_hexagons.Remove(hexagon);

			return true;
		}

		/// <summary>
		/// Removes a list of hexagons from the grid.
		/// </summary>
		/// <param name="hexagons">List of hexagons to remove.</param>
		public void RemoveTiles(List<Hexagon> hexagons)
		{
			foreach(Hexagon hexagon in hexagons)
				RemoveTile(hexagon);
		}
		#endregion
	}
}
