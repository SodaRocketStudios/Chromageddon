using UnityEngine;
using SRS.StatSystem;

namespace SRS.Health
{
	public class HealthManager : MonoBehaviour
	{
		public int MaxHealth{get; private set;}
		
		public int CurrentHealth {get; private set;}

		public delegate void EventHandler(GameObject character);
		public event EventHandler OnDeath;

		private CharacterStats characterStats;

		private void Start()
		{
			characterStats = GetComponent<CharacterStats>();
			
			UpdateMaxHealth(characterStats.Character["Health"].Value);

			SetHealthToMax();
		}

		private void OnEnable()
		{
			SetHealthToMax();
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

			if(CurrentHealth <= 0)
			{
				OnDeath?.Invoke(gameObject);
			}
		}

		private void UpdateMaxHealth(float value)
		{
			MaxHealth = (int)value;
		}

		private void SetHealthToMax()
		{
			CurrentHealth = MaxHealth;
		}
	}
}