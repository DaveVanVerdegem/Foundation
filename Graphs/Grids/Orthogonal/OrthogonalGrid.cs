using Foundation.Graphs.Grids.Hexagonal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Graphs.Grids.Orthogonal
{
	public class OrthogonalGrid : Grid<OrthogonalCell, OrthogonalCoordinates>
	{
		#region Properties
		public override Dictionary<OrthogonalCoordinates, OrthogonalCell> Cells => _cells;
		#endregion

		#region Fields
		private Dictionary<OrthogonalCoordinates, OrthogonalCell> _cells = new();
		#endregion

		#region Constructors
		public OrthogonalGrid(int columns, int rows)
		{
			for(int x = 0; x < columns; x++)
			{
				for(int y = 0; y < rows; y++)
				{
					Cells.Add(new OrthogonalCoordinates(x, y), null);
				}
			}
		}

		public OrthogonalGrid(Vector2Int size): this(size.x, size.y)
		{
		}
		#endregion

		#region Static Methods
		public static OrthogonalGrid Instantiate(Vector2Int size, Transform parent, OrthogonalCell cellPrefab)
		{
			OrthogonalGrid grid = new OrthogonalGrid(size);

			PlaceCells(grid, cellPrefab, parent);

			return grid;
		}

		private static void PlaceCells(OrthogonalGrid grid, OrthogonalCell cellPrefab, Transform parent)
		{
			List<OrthogonalCell> cells = new List<OrthogonalCell>();

			foreach (KeyValuePair<OrthogonalCoordinates, OrthogonalCell> pair in grid.Cells)
			{
				OrthogonalCell cell = Object.Instantiate(cellPrefab, parent.position + pair.Key.ToWorldPosition(cellPrefab.Size), Quaternion.identity, parent);
				cell.SetCoordinates(pair.Key);

				cells.Add(cell);
			}

			foreach (OrthogonalCell cell in cells)
			{
				grid.Add(cell);
			}
		}
		#endregion
	}
}
