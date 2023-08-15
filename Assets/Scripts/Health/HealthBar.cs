using UnityEngine;
using SRS.UI;

namespace SRS.Health
{
    public class HealthBar : StatusBar
    {
        [SerializeField] private HealthManager health;

        private void Awake()
        {
            health.OnCurrentHealthChange.AddListener(UpdateValue);
            health.OnMaxHealthChange.AddListener(UpdateMax);
        }
    }
}
