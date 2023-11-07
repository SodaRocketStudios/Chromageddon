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
		private float rechargeDelayTimer;

		private float rechargeSpeed; // -- Might be better suited as a stat.

		private void Update()
		{
			rechargeDelayTimer += Time.deltaTime;

			if(rechargeDelayTimer >= rechargeDelay)
			{
				StartRecharge();
			}
		}

		public float Damage(float damage, DamageType damageType)
		{
			float remainingDamage = Mathf.Max(0, damage - Value.Current);
			
			Value.Current -= damage;

			if(Value.Current <= 0)
			{
				OnBreak?.Invoke();
			}

			rechargeDelayTimer = 0;
			return remainingDamage;
		}

		public void Recharge(float amount)
		{
			Value.Current += amount;
		}

		private void StartRecharge()
        {
			OnRechargeStart?.Invoke();
            // Regenerate over time. Might be easier with a coroutine.
        }
	}
}
