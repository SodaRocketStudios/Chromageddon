using UnityEngine;

namespace SRS.HealthProto
{
	public class HealthManagerProto : MonoBehaviour
	{
		public int MaxHealth{get; private set;}
		
		public int CurrentHealth {get; private set;}


		public delegate void EventHandler(GameObject character);
		public event EventHandler OnDeath;

		private void Start()
		{
			MaxHealth = 100;
			CurrentHealth = MaxHealth;
		}

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

			Debug.Log($"Health is now {CurrentHealth}.");

			if(CurrentHealth <= 0)
			{
				OnDeath?.Invoke(gameObject);
			}
		}
	}
}