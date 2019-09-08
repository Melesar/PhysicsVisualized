using System;
using UnityEngine;

namespace Scenarios.CircularMovement.Scripts
{
    public class OrbitCircle : OrbitView
    {
        [SerializeField] private RectTransform _circle;

        private float _circleRadius;
        
        public override void UpdateView(float currentAngle)
        {
            float currentCircleAngle = currentAngle * Mathf.Deg2Rad + INITIAL_CIRCLE_ANGLE;
            float circleXPos = _circleRadius * Mathf.Cos(currentCircleAngle);
            float circleYPos = _circleRadius * Mathf.Sin(currentCircleAngle);
            _circle.anchoredPosition = new Vector2(circleXPos, circleYPos);
        }

        private void Awake()
        {
            _circleRadius = _circle.anchoredPosition.y;
        }
    }
}