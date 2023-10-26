using UnityEngine;
using UnityEngine.Events;

namespace SRS.Combat
{
    public class Health : MonoBehaviour
    {
        public UnityEvent OnDeath;

        public UnityEvent<float> OnCurrentChange;
        public UnityEvent<float> OnMaxChange;

        private float currentHealth;
        public float CurrentHealth
        {
            get
            {
                return currentHealth;
            }
            private set
            {
                currentHealth = Mathf.Max(value, 0);
                currentHealth = Mathf.Min(currentHealth, MaxHealth);

                if(currentHealth <= 0)
                {
                    OnDeath?.Invoke();
                }

                OnCurrentChange?.Invoke(CurrentHealth);
            }
        }

        private float maxHealth;
        public float MaxHealth
        {
            get
            {
                return maxHealth;
            }

            set
            {
                maxHealth = value;
                OnMaxChange?.Invoke(MaxHealth);
            }
        }


        public void Damage(float amount, DamageType damageType)
        {
            CurrentHealth -= amount;
        }

        public void Heal(float amount)
        {
            CurrentHealth += amount;
        }

        private void Regenerate()
        {
            // Regenerate health over time. Might be easier with a coroutine.
        }
    }
}
