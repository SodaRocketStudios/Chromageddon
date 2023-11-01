using UnityEngine;
using UnityEngine.Events;
using SRS.Utils;

namespace SRS.Combat
{
	public class Shield : MonoBehaviour
	{
		public UnityEvent OnBreak;
		public UnityEvent OnRechargeStart;
		public UnityEvent OnRechargeEnd;

		public Fraction Value;

		private float rechargeDelay; // -- Might be better suited as a stat.

		private float rechargeSpeed; // -- Might be better suited as a stat.

		public void Damage(float amount, DamageType damageType)
		{

		}

		public void Recharge(float amount)
		{
			Value.Current += amount;
		}

		private void Regenerate()
        {
            // Regenerate over time. Might be easier with a coroutine.
        }
	}
}
