using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Fields
{
	internal class Grid
	{
		private Node[,] _nodes;
		private int _width;
		private int _height;

		public Grid(int width, int height)
		{
			_width = width;
			_height = height;

			_nodes = new Node[width, height];

			for (int i = 0; i < _nodes.GetLength(0); i++)
			{
				for (int j = 0; j < _nodes.GetLength(1); j++)
				{
					_nodes[i, j] = new Node();
				}
			}
		}

		public Node GetNode(Vector3Int vector)
		{
			return GetNode(vector.x, vector.y);
		}

		public Node GetNode(int i, int j)
		{
			if (i < 0 || i >= _nodes.GetLength(0))
			{
				return null;
			}
			if (j < 0 || j >= _nodes.GetLength(1))
			{
				return null;
			}
			return _nodes[i, j];
		}
	}
}
