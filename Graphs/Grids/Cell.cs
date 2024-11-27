using UnityEngine;

namespace Foundation.Graphs.Grids
{
	public abstract class Cell<T> : MonoBehaviour where T : Coordinates
	{
		#region Properties
		public abstract T Coordinates { get; }

		public abstract float Width { get; }
		public abstract float Height { get; }
		#endregion

		#region Life Cycle
		public abstract void Initialize(T coordinates);
		#endregion

		#region Methods
		public abstract void SetCoordinates(T coordinates);

		public abstract int GetDirectionFromCell(Cell<T> cell);
		#endregion

		#region Position Conversion
		public abstract Vector3 ToWorldPosition();
		#endregion
	}
}