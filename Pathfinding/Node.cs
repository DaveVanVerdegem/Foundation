using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Pathfinding
{
	public abstract class Node : MonoBehaviour
	{
		#region Properties
		public abstract Vector3 Position { get; }
		public abstract float Cost { get; }
		public abstract bool Enabled { get; }

		public List<Node> Neighbours => _neighbours;
		public float F { get { return (G + H) * Cost; }}
		public float G;
		public float H;

		public Node Parent;
		#endregion

		#region Fields
		protected List<Node> _neighbours = new List<Node>();
		#endregion

		#region Methods
		public void Reset()
		{
			Parent = null;
			G = 0f;
			H = 0f;
		}
		#endregion
	}
}