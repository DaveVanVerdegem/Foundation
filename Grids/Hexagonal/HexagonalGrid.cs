using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Grids.Hexagonal
{
	public class HexagonalGrid
	{
		#region Properties
		public Dictionary<HexagonCoordinates, Hexagon> Hexagons => _hexagons;
		#endregion

		#region Fields
		private Dictionary<HexagonCoordinates, Hexagon> _hexagons = new Dictionary<HexagonCoordinates, Hexagon>();
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
					_hexagons.Add(new HexagonCoordinates(q, r, -q - r), null);
				}
			}
		}
		#endregion

		#region Static Methods
		public static HexagonalGrid Instantiate(int radius, Transform parent, Hexagon hexagonPrefab)
		{
			HexagonalGrid hexagonalGrid = new HexagonalGrid(radius);

			PlaceTiles(hexagonalGrid, hexagonPrefab, parent);

			return hexagonalGrid;
		}

		private static void PlaceTiles(HexagonalGrid grid, Hexagon hexagonPrefab, Transform parent)
		{
			List<Hexagon> hexagons = new List<Hexagon>();

			foreach(KeyValuePair<HexagonCoordinates, Hexagon> pair in grid._hexagons)
			{
				Hexagon hexagon = Object.Instantiate(hexagonPrefab, parent.position + pair.Key.ToWorldPosition(hexagonPrefab.Size), Quaternion.identity, parent);
				hexagon.SetCoordinates(pair.Key);

				hexagons.Add(hexagon);
				//grid.Add(hexagon);
			}

			foreach (Hexagon hexagon in hexagons)
			{
				grid.Add(hexagon);
			}
		}
		#endregion

		#region Methods
		public Hexagon GetHexagon(HexagonCoordinates coordinates) => _hexagons[coordinates];

		public bool Add(Hexagon hexagon, HexagonCoordinates coordinates)
		{
			if (_hexagons.ContainsKey(coordinates))
			{
				_hexagons[coordinates] = hexagon;
				return true;
			}

			return false;
		}

		public bool Add(Hexagon hexagon) => Add(hexagon, hexagon.Coordinates);

		/// <summary>
		/// Removes a hexagon from the grid.
		/// </summary>
		/// <param name="hexagon">Hexagon tile to remove.</param>
		/// <returns>Returns true if the hexagon was found and succesfully removed.</returns>
		public bool Remove(Hexagon hexagon)
		{
			if (hexagon is null) return false;
			if(!_hexagons.ContainsValue(hexagon)) return false;

			_hexagons[hexagon.Coordinates] = null;

			return true;
		}

		/// <summary>
		/// Removes a list of hexagons from the grid.
		/// </summary>
		/// <param name="hexagons">List of hexagons to remove.</param>
		public void Remove(List<Hexagon> hexagons)
		{
			foreach(Hexagon hexagon in hexagons)
				Remove(hexagon);
		}
		#endregion
	}
}
