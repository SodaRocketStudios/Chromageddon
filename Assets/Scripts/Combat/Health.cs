using System;
using SRS.Utils;

namespace SRS.Combat
{
    [Serializable]
    public class Health
    {
        public Action OnDeath;

        public Fraction Value = new();

        public void Damage(float amount, DamageType damageType)
        {
            Value.Current -= amount;

            if(Value.Current <= 0)
            {
                OnDeath?.Invoke();
            }
        }

        public void Heal(float amount)
        {
            Value.Current += amount;
        }

        public void SetToMax()
        {
            Value.SetCurrentToMax();
        }

        private void Regenerate()
        {
            // Regenerate health over time.
        }
    }
}
