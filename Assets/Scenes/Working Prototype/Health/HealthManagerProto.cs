using UnityEngine;

namespace SodaRocket.HealthProto
{
	public class HealthManagerProto : MonoBehaviour
	{
		public int MaxHealth{get; private set;}
		
		public int CurrentHealth {get; private set;}


		public delegate void EventHandler();
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
			Debug.Log($"Health altered by {amount}. Current health is {CurrentHealth}.");

			if(CurrentHealth <= 0)
			{
				OnDeath?.Invoke();
			}
		}
	}
}