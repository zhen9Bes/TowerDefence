using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TowerDefence.Scripts.Fields
{
	internal class GridHolder : MonoBehaviour
	{
		[SerializeField]
		private int _gridWidth;

		[SerializeField]
		private int _gridHeight;

		[SerializeField]
		private float _nodeSize;

		private Grid _grid;
		private Camera _camera;
		private Vector3 _offset;

		private void Awake()
		{
			_grid = new Grid(_gridWidth, _gridHeight);
			_camera = Camera.main;

			float width = _gridWidth * _nodeSize;
			float height = _gridHeight * _nodeSize;
			// Default polane size is 10 by 10
			transform.localScale = new Vector3(width * 0.1f, 1f, height * 0.1f);
			_offset = transform.position - (new Vector3(width, 0, height) * 0.5f);
		}

		private void Update()
		{
			if (_grid == null || _camera == null)
			{
				return;
			}

			var mousePosition = Input.mousePosition;
			var ray = _camera.ScreenPointToRay(mousePosition);

			if (Physics.Raycast(ray, out RaycastHit hit))
			{
				if (hit.transform != transform)
				{
					return;
				}

				Vector3 hitPosition = hit.point;
				Vector3 difference = hitPosition - _offset;

				var x = (int)(difference.x / _nodeSize);
				var y = (int)(difference.z / _nodeSize);

				Debug.Log(x + " " + y);
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere(_offset, 0.1f);
		}
	}
}
