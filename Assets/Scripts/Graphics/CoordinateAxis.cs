using System;
using UnityEngine;

namespace Graphics
{
	public class CoordinateAxis : MonoBehaviour
	{
		public float AxisLength { get; private set; }
		public float Threshold { get; private set; }
		public float MarkLength { get; private set; }
		
		
		private LineRenderer _lineRenderer;
		private LineRenderer _checkMarker;

		private const float LINE_WIDTH = 0.1f;
		private const float MARK_WIDTH = 0.05f;

		public static CoordinateAxis Build(float axisLength, float threshold, float markWidth)
		{
			var axisObject = new GameObject("Axis");
			var axis = axisObject.AddComponent<CoordinateAxis>();
			axis.AxisLength = axisLength;
			axis.Threshold = threshold;
			axis.MarkLength = markWidth;

			return axis;
		}

		private void Build()
		{
			CreateAxisLine();
			CreateMarks();
		}

		private void CreateAxisLine()
		{
			_lineRenderer = gameObject.AddComponent<LineRenderer>();
			_lineRenderer.useWorldSpace = false;
			_lineRenderer.startWidth = _lineRenderer.endWidth = LINE_WIDTH;
			_lineRenderer.positionCount = 2;
			
			var positions = new []
			{
				new Vector3(0f, -AxisLength - Threshold, 0f),
				new Vector3(0f, AxisLength +Threshold, 0f)
			};
			_lineRenderer.SetPositions(positions);
		}

		private void CreateMarks()
		{
			float length = Mathf.Floor(AxisLength);
			for (float pos = -length; pos <= length; pos++)
			{
				var mark = new GameObject("Mark");
				mark.transform.SetParent(gameObject.transform);
				mark.transform.localPosition = Vector3.up * pos;
				
				var markRenderer = mark.AddComponent<LineRenderer>();
				markRenderer.useWorldSpace = false;
				markRenderer.startWidth = markRenderer.endWidth = MARK_WIDTH;
				markRenderer.positionCount = 2;
				markRenderer.SetPositions(new []{new Vector3(-MarkLength / 2f, 0f, 0f), new Vector3(MarkLength / 2f, 0f, 0f)});
			}
		}

		private void Start()
		{
			Build();
		}
	}
}
