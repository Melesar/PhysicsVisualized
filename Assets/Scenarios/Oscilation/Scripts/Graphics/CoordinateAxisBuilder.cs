using System;
using System.Security.Cryptography;
using Graphics;
using UnityEngine;

public class CoordinateAxisBuilder : MonoBehaviour
{
	[SerializeField] private float _axisLength = 6;
	[SerializeField] private float _threshold = 0.4f;
	[SerializeField] private float _markWidth = 0.2f;

	private CoordinateAxis _axis;
	
	[ContextMenu("Rebuild")]
	public void Rebuild()
	{
		if (_axis != null)
		{
			Destroy(_axis.gameObject);
		}

		_axis = CoordinateAxis.Build(_axisLength, _threshold, _markWidth);
	}
}
