using UnityEngine;

namespace SodaRocket.Health
{
	public class HealthPool
	{
		private int maxHealth = 100;
		private int currentHealth;

		public delegate void EventHandler();
		public event EventHandler OnDeath;

		public HealthPool(int _maxHealth)
		{
			maxHealth = _maxHealth;
			currentHealth = maxHealth;
		}

		public void alterHealth(int amount)
		{
			currentHealth += amount;

			if(currentHealth <= 0)
			{
				OnDeath.Invoke();
			}
		}
	}
}