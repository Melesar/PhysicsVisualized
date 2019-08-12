using System;
using UnityEngine;

namespace Oscilation
{
	public class SphereMovement : MonoBehaviour
	{
		[SerializeField] private Transform _sphereTransform;
		[SerializeField] private LineRenderer _trajectoryRenderer;
		[SerializeField] private int _trajectoryResolution;
		[SerializeField] private float _angularSpeed = Mathf.PI / 2f;
		[SerializeField] private float _range;

		private float _currentAngle;
		
		private void Update()
		{
			float x = _range * Mathf.Cos(_currentAngle);
			float y = _range * Mathf.Sin(_currentAngle);

			_sphereTransform.localPosition = new Vector3(x, y);

			_currentAngle += _angularSpeed * Time.deltaTime;
		}

		private void Start()
		{
			var positions = new Vector3[_trajectoryResolution];
			float step = 2f * Mathf.PI / _trajectoryResolution;
			for (int i = 0; i < _trajectoryResolution; i++)
			{
				float x = _range * Mathf.Cos(i * step);
				float y = _range * Mathf.Sin(i * step);

				positions[i] = new Vector3(x, y);
			}
			
			_trajectoryRenderer.positionCount = _trajectoryResolution;
			_trajectoryRenderer.SetPositions(positions);
		}
	}
}
