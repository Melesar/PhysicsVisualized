using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenarios.CircularMovement.Scripts
{
    public class OrbitText : OrbitView
    {
        [SerializeField] private float _textAppearAngle;
        [SerializeField] private float _textFullOpacityAngle;
        [SerializeField] private TMP_Text _text;

        private RectTransform _textTransform;
        private float _textRadius;
        
        public override void UpdateView(float currentAngle)
        {
            float currentTextAngle = currentAngle * 0.5f;
            float currentTextAngleRad = currentTextAngle * Mathf.Deg2Rad + INITIAL_CIRCLE_ANGLE;
            float circleXPos = _textRadius * Mathf.Cos(currentTextAngleRad);
            float circleYPos = _textRadius * Mathf.Sin(currentTextAngleRad);
            _textTransform.anchoredPosition = new Vector2(circleXPos, circleYPos);
            _textTransform.localRotation = Quaternion.Euler(0f, 0f, currentTextAngle);

            Color textColor = _text.color;
            textColor.a = Mathf.InverseLerp(_textAppearAngle, _textFullOpacityAngle, currentAngle);
            _text.color = textColor;

            _text.text = $"\u03B1 = {Mathf.RoundToInt(currentAngle)}";
        }

        private void Awake()
        {
            _textTransform = _text.rectTransform;
            _textRadius = _textTransform.anchoredPosition.y;
        }
    }
}