using UnityEngine;

namespace Scenarios.CircularMovement.Scripts
{
    public abstract class OrbitView : MonoBehaviour
    {
        protected const float INITIAL_CIRCLE_ANGLE = Mathf.PI / 2f;

        protected Orbit Orbit => _orbit ? _orbit : (_orbit = GetComponent<Orbit>());
        
        private Orbit _orbit;
        
        public abstract void UpdateView(float currentAngle);
    }
}