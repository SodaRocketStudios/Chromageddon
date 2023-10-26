using UnityEngine;
using UnityEngine.Events;

namespace SRS.Combat
{
	public class Shield : MonoBehaviour
	{
		public UnityEvent OnBreak;
		public UnityEvent OnRechargeStart;
		public UnityEvent OnRechargeEnd;
		public UnityEvent<float> OnCurrentChange;
		public UnityEvent<float> OnMaxChange;

		private float max;
		public float Max
		{
			get
			{
				return max;
			}
			set
			{
				max = value;
				OnMaxChange?.Invoke(max);
			}
		}

		private float current;
		public float Current
		{
			get
			{
				return current;
			}

			private set
			{
				current = Mathf.Max(value, 0);
				current = Mathf.Min(current, Max);

				if(current <= 0)
				{
					OnBreak?.Invoke();
				}

				OnCurrentChange?.Invoke(current);
			}
		}

		private float rechargeDelay; // -- Might be better suited as a stat.

		private float rechargeSpeed; // -- Might be better suited as a stat.

		public void Damage(float amount, DamageType damageType)
		{

		}

		public void Recharge(float amount)
		{
			Current += amount;
		}

		private void Regenerate()
        {
            // Regenerate over time. Might be easier with a coroutine.
        }
	}
}
