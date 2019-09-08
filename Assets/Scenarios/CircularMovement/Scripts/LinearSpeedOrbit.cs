using UnityEngine;

namespace Scenarios.CircularMovement.Scripts
{
    public class LinearSpeedOrbit : Orbit
    {
        [SerializeField] private float _linearSpeed;
        [SerializeField] private float _radius;
        
        protected override float UpdateAngle(float currentAngle)
        {
            return currentAngle + _linearSpeed / _radius * Time.deltaTime;
        }
    }
}