using UnityEngine;

namespace SodaRocket.Health
{
	public class HealthManager : MonoBehaviour
	{
		private HealthPool healthPool = new HealthPool(100);

		private void Damage(int amount)
		{
			healthPool.alterHealth(-amount);
		}

		private void Heal(int amount)
		{
			healthPool.alterHealth(amount);
		}
	}
}