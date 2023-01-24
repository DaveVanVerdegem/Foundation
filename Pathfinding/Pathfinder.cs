using System.Collections.Generic;

namespace Foundation.Pathfinding
{
	public class Pathfinder
	{
		#region Properties
		public bool PathFound { get; private set; }
		public List<Node> Path { get; private set; }
		#endregion

		#region Fields
		private List<Node> _openList;
		private List<Node> _closedList;

		private Node _start;
		private Node _goal;
		#endregion

		#region Constructors
		public Pathfinder(Node start, Node goal)
		{
			_start = start;
			_goal = goal;

			_openList = new List<Node>();
			_closedList = new List<Node>();
		}
		#endregion

		#region Methods
		public bool TryToFindPath()
		{
			_openList.Clear();
			_closedList.Clear();

			_start.H = (_goal.transform.position - _start.transform.position).magnitude;
			_openList.Add(_start);

			while (_openList.Count > 0)
			{
				Node bestNode = GetBestNode();
				_openList.Remove(bestNode);

				List<Node> neighbours = new List<Node>(bestNode.Neighbours);
				for (int i = 0; i < neighbours.Count; i++)
				{
					Node currentNode = neighbours[i];

					if (currentNode == null)
						continue;

					if (!currentNode.Enabled)
						continue;

					if (currentNode == _goal)
					{
						currentNode.Parent = bestNode;
						PathFound = true;
						Path = ConstructPath(currentNode);
						return true;
					}

					float g = bestNode.F + (currentNode.transform.position - bestNode.transform.position).magnitude;
					float h = (_goal.transform.position - currentNode.transform.position).magnitude;

					if (_openList.Contains(currentNode) && currentNode.F < (g + h))
						continue;
					if (_closedList.Contains(currentNode) && currentNode.F < (g + h))
						continue;

					currentNode.G = g;
					currentNode.H = h;
					currentNode.Parent = bestNode;

					if (!_openList.Contains(currentNode))
						_openList.Add(currentNode);
				}

				if (!_closedList.Contains(bestNode))
					_closedList.Add(bestNode);
			}

			Path = null;
			PathFound = false;
			return false;
		}

		// We could shorten this with a nice linq statement. However, linq has a considerable overhead compared to classic iteration.
		private Node GetBestNode()
		{
			Node result = null;
			float currentF = float.PositiveInfinity;

			for (int i = 0; i < _openList.Count; i++)
			{
				var cell = _openList[i];

				if (cell.F < currentF)
				{
					currentF = cell.F;
					result = cell;
				}
			}

			return result;
		}

		private List<Node> ConstructPath(Node destination)
		{
			List<Node> path = new List<Node>() { destination };

			Node current = destination;
			while (current.Parent != null)
			{
				current = current.Parent;
				path.Add(current);
			}

			path.Reverse();

			// Clean up references from calculation.
			foreach (Node node in path)
				node.Parent = null;

			return path;
		}
		#endregion
	} 
}