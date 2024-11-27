using System.Collections.Generic;

namespace Foundation.Graphs.Grids
{
	public abstract class Grid<T, U> where T : Cell<U> where U: Coordinates
	{
		#region Properties
		public abstract Dictionary<U, T> Cells { get; }
		#endregion

		#region Methods
		public T GetCell(U coordinates) => Cells[coordinates];

		public bool Add(T cell, U coordinates)
		{
			if (Cells.ContainsKey(coordinates))
			{
				Cells[coordinates] = cell;
				return true;
			}

			return false;
		}

		public bool Add(T cell) => Add(cell, cell.Coordinates);

		/// <summary>
		/// Removes a cell from the grid.
		/// </summary>
		/// <param name="cell">Cell to remove.</param>
		/// <returns>Returns true if the cell was found and succesfully removed.</returns>
		public bool Remove(T cell)
		{
			if (cell is null) return false;
			if (!Cells.ContainsValue(cell)) return false;

			Cells[cell.Coordinates] = null;

			return true;
		}

		/// <summary>
		/// Removes a list of cells from the grid.
		/// </summary>
		/// <param name="cells">List of cells to remove.</param>
		public void Remove(List<T> cells)
		{
			foreach (T cell in cells)
				Remove(cell);
		}
		#endregion
	}
}