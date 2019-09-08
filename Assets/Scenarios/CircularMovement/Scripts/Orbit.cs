using System;
using Scenarios.CircularMovement.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Orbit : MonoBehaviour
{
    [SerializeField] private float _stopAngle;

    private float _currentAngle;

    private OrbitView[] _views;

    private void Update()
    {
        if (_currentAngle >= _stopAngle)
        {
            return;
        }

        _currentAngle = UpdateAngle(_currentAngle);
        foreach (OrbitView view in _views)
        {
            view.UpdateView(_currentAngle);
        }
    }

    protected abstract float UpdateAngle(float currentAngle);

    private void Awake()
    {
        _views = GetComponents<OrbitView>();
    }
}
