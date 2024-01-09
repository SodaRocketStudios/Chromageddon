using UnityEngine;
using UnityEngine.Events;
using SRS.Utils;

namespace SRS.Combat
{
    [System.Serializable]
    public class Health
    {
        public UnityEvent OnDeath;

        public Fraction Value;

        public Health(float max)
        {
            Value = new(max, max);
        }

        public void Damage(float amount, DamageType damageType)
        {
            Value.Current -= amount;
        }

        public void Heal(float amount)
        {
            Value.Current += amount;
        }

        private void Regenerate()
        {
            // Regenerate health over time. Might be easier with a coroutine.
        }
    }
}
