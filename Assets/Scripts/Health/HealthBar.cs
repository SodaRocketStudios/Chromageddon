using UnityEngine;
using SRS.UI;

namespace SRS.Health
{
    public class HealthBar : StatusBar
    {
        [SerializeField] private HealthManager health;

        private void Start()
        {
            health.OnCurrentHealthChange += UpdateValue;
            health.OnMaxHealthChange += UpdateMax;
        }
    }
}
