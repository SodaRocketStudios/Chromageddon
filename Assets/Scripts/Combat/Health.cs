using UnityEngine;
using UnityEngine.Events;
using SRS.Utils;

namespace SRS.Combat
{
    public class Health : MonoBehaviour
    {
        public UnityEvent OnDeath;

        public Fraction Value;

        public UnityEvent<float> OnCurrentChange;
        public UnityEvent<float> OnMaxChange;


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
