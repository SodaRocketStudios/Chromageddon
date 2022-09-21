using UnityEngine;
using SRS.Stats;

namespace SRS.Health
{
	public class HealthManager : MonoBehaviour
	{
		public int MaxHealth{get; private set;}
		
		public int CurrentHealth {get; private set;}

		public delegate void EventHandler(GameObject character);
		public event EventHandler OnDeath;

		private void Start()
		{
			MaxHealth = (int)GetComponent<CharacterData>().CharacterStats["Health"].Value;
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