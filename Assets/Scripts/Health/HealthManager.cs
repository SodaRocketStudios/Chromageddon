using UnityEngine;
using UnityEngine.Events;
using SRS.StatSystem;
using SRS.Extensions;

namespace SRS.Health
{
	public class HealthManager : MonoBehaviour
	{
		public float MaxHealth{get {return characterStats["Health"];}}
		
		public float CurrentHealth {get; private set;}

		public GameObjectEvent OnDeath;

		private CharacterStats characterStats;

		private float healthPercentage = 1;

		public UnityEvent<float> OnCurrentHealthChange;
		public UnityEvent<float> OnMaxHealthChange;

		private void Start()
		{
			characterStats = GetComponent<CharacterStats>();

			characterStats.Stats["Health"].OnValueChange += UpdateMaxHealth;

			SetHealthToMax();
		}

		private void OnEnable()
		{
			SetHealthToMax();
		}

		public void Damage(float amount)
		{
			AlterHealth(-amount);
		}

		public void Heal(float amount)
		{
			AlterHealth(amount);
		}

		private void AlterHealth(float amount)
		{
			CurrentHealth += amount;

			if(CurrentHealth <= 0)
			{
				OnDeath.Invoke(gameObject);
			}

			CalculateHealthPercentage();

			OnCurrentHealthChange?.Invoke(CurrentHealth);
		}

		private void SetHealthToMax()
		{
			if(characterStats != null)
			{
				CurrentHealth = MaxHealth;
				OnMaxHealthChange?.Invoke(MaxHealth);
				OnCurrentHealthChange?.Invoke(CurrentHealth);

				CalculateHealthPercentage();
			}
		}

		private void UpdateMaxHealth(float value)
		{
			OnMaxHealthChange?.Invoke(value);
			CurrentHealth = healthPercentage*value;
			OnCurrentHealthChange?.Invoke(CurrentHealth);
		}

		private void CalculateHealthPercentage()
		{
			healthPercentage = CurrentHealth*1.0f/MaxHealth;
		}
	}
}