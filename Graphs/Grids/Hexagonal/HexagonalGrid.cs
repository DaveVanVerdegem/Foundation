using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Graphs.Grids.Hexagonal
{
	// TODO: Remove code when safe.
	public class HexagonalGrid : Grid<HexagonalCell, HexagonalCoordinates>
	{
		#region Properties
		public override Dictionary<HexagonalCoordinates, HexagonalCell> Cells => _hexagons;
		#endregion

		#region Fields
		private Dictionary<HexagonalCoordinates, HexagonalCell> _hexagons = new();
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
					_hexagons.Add(new HexagonalCoordinates(q, r, -q - r), null);
				}
			}
		}
		#endregion

		#region Static Methods
		public static HexagonalGrid Instantiate(int radius, Transform parent, HexagonalCell hexagonPrefab)
		{
			HexagonalGrid hexagonalGrid = new HexagonalGrid(radius);

			PlaceCells(hexagonalGrid, hexagonPrefab, parent);

			return hexagonalGrid;
		}

		private static void PlaceCells(HexagonalGrid grid, HexagonalCell hexagonPrefab, Transform parent)
		{
			List<HexagonalCell> hexagons = new List<HexagonalCell>();

			foreach(KeyValuePair<HexagonalCoordinates, HexagonalCell> pair in grid._hexagons)
			{
				HexagonalCell hexagon = Object.Instantiate(hexagonPrefab, parent.position + pair.Key.ToWorldPosition(hexagonPrefab.Size), Quaternion.identity, parent);
				hexagon.SetCoordinates(pair.Key);

				hexagons.Add(hexagon);
				//grid.Add(hexagon);
			}

			foreach (HexagonalCell hexagon in hexagons)
			{
				grid.Add(hexagon);
			}
		}
		#endregion

		#region Methods
		//public HexagonalCell GetHexagon(HexagonalCoordinates coordinates) => _hexagons[coordinates];

		//public bool Add(HexagonalCell hexagon, HexagonalCoordinates coordinates)
		//{
		//	if (_hexagons.ContainsKey(coordinates))
		//	{
		//		_hexagons[coordinates] = hexagon;
		//		return true;
		//	}

		//	return false;
		//}


		//public bool Add(HexagonalCell hexagon) => Add(hexagon, hexagon.Coordinates);

		///// <summary>
		///// Removes a hexagon from the grid.
		///// </summary>
		///// <param name="hexagon">Hexagon tile to remove.</param>
		///// <returns>Returns true if the hexagon was found and succesfully removed.</returns>
		//public bool Remove(HexagonalCell hexagon)
		//{
		//	if (hexagon is null) return false;
		//	if(!_hexagons.ContainsValue(hexagon)) return false;

		//	_hexagons[hexagon.Coordinates] = null;

		//	return true;
		//}

		///// <summary>
		///// Removes a list of hexagons from the grid.
		///// </summary>
		///// <param name="hexagons">List of hexagons to remove.</param>
		//public void Remove(List<HexagonalCell> hexagons)
		//{
		//	foreach(HexagonalCell hexagon in hexagons)
		//		Remove(hexagon);
		//}
		#endregion
	}
}
