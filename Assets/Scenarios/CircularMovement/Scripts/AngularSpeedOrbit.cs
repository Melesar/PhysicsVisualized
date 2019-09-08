using UnityEngine;

namespace Scenarios.CircularMovement.Scripts
{
    public class AngularSpeedOrbit : Orbit
    {
        [SerializeField] private float _angularSpeed;
        
        public float AngularSpeed => _angularSpeed;

        protected override float UpdateAngle(float currentAngle)
        {
            return currentAngle + AngularSpeed * Time.deltaTime;
        }
    }
}