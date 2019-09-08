using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Orbit : MonoBehaviour
{
    [SerializeField] private float _angularSpeed;
    [SerializeField] private float _stopAngle;
    [SerializeField] private float _textAppearAngle;
    [SerializeField] private float _textFullOpacityAngle;
    
    [SerializeField] private Image _mask;
    [SerializeField] private RectTransform _circle;
    [SerializeField] private TMP_Text _text;

    private RectTransform _textTransform;
    
    private float _circleRadius;
    private float _textRadius;
    private float _currentAngle;

    private const float INITIAL_CIRCLE_ANGLE = Mathf.PI / 2f; 
    
    private void Update()
    {
        if (_currentAngle >= _stopAngle)
        {
            return;
        }
        
        _currentAngle += _angularSpeed * Time.deltaTime;

        MoveCircle();
        UpdateText();

        _mask.fillAmount = 1f - Mathf.Repeat(_currentAngle / 360f, 1f);
    }

    private void UpdateText()
    {
        float currentTextAngle = _currentAngle * 0.5f;
        float currentTextAngleRad = currentTextAngle * Mathf.Deg2Rad + INITIAL_CIRCLE_ANGLE;
        float circleXPos = _textRadius * Mathf.Cos(currentTextAngleRad);
        float circleYPos = _textRadius * Mathf.Sin(currentTextAngleRad);
        _textTransform.anchoredPosition = new Vector2(circleXPos, circleYPos);
        _textTransform.localRotation = Quaternion.Euler(0f, 0f, currentTextAngle);

        Color textColor = _text.color;
        textColor.a = Mathf.InverseLerp(_textAppearAngle, _textFullOpacityAngle, _currentAngle);
        _text.color = textColor;

        _text.text = $"\u03B1 = {Mathf.RoundToInt(_currentAngle)}";
    }

    private void MoveCircle()
    {
        float currentCircleAngle = _currentAngle * Mathf.Deg2Rad + INITIAL_CIRCLE_ANGLE;
        float circleXPos = _circleRadius * Mathf.Cos(currentCircleAngle);
        float circleYPos = _circleRadius * Mathf.Sin(currentCircleAngle);
        _circle.anchoredPosition = new Vector2(circleXPos, circleYPos);
    }

    private void Awake()
    {
        _circleRadius = _circle.anchoredPosition.y;
        _textTransform = _text.rectTransform;
        _textRadius = _textTransform.anchoredPosition.y;
    }
}
