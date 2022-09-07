using UnityEngine;

namespace SodaRocket.HealthProto
{
	public class HealthManagerProto : MonoBehaviour
	{
		public int MaxHealth{get; private set;}
		
		public int CurrentHealth {get; private set;}


		public delegate void EventHandler();
		public event EventHandler OnDeath;

		public void Damage(int amount)
		{
			AlterHealth(-amount);
		}

		public void Heal(int amount)
		{
			AlterHealth(amount);
		}

		private void AlterHealth(int amount)
		{
			CurrentHealth += amount;

			if(CurrentHealth <= 0)
			{
				OnDeath.Invoke();
			}
		}
	}
}