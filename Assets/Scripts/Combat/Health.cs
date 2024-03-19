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

        public bool IsFull
        {
            get
            {
                return Value.Current >= Value.Max;
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

        public void FilledChange(float newMax)
		{
            float previousMax = Value.Max;
			UnfilledChange(newMax);
            Value.Current += Value.Max - previousMax;
		}

		public void UnfilledChange(float newMax)
		{
			Value.Max = newMax;
		}
    }
}
