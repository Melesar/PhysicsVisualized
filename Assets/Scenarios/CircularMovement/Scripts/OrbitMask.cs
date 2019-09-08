using UnityEngine;
using UnityEngine.UI;

namespace Scenarios.CircularMovement.Scripts
{
    public class OrbitMask : OrbitView
    {
        [SerializeField] private Image _mask;
        
        public override void UpdateView(float currentAngle)
        {
            _mask.fillAmount = 1f - Mathf.Repeat(currentAngle / 360f, 1f);
        }
    }
}