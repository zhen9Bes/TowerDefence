using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Fields
{
	internal class GridHolder : MonoBehaviour
	{
		[SerializeField]
		private int _gridWidth;
		[SerializeField]
		private int _gridHeight;
		private Grid _grid;
		private Camera _camera;

		private void Awake()
		{
			_grid = new Grid(_gridWidth, _gridHeight);
			_camera = Camera.main;
		}

		private void Update()
		{
			if(_grid == null || _camera == null)
			{
				return;
			}

			var mousePosition = Input.mousePosition;
			var ray = _camera.ScreenPointToRay(mousePosition);

			if(Physics.Raycast(ray, out RaycastHit hit))
			{
				if(hit.transform != transform)
				{
					return;
				}

				Debug.Log("hit!");
			}
		}
	}
}
