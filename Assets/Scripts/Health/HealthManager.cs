using UnityEngine;
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

		private Rigidbody2D body;

		private void Start()
		{
			characterStats = GetComponent<CharacterStats>();
			body = GetComponent<Rigidbody2D>();

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

				body.simulated = false;
			}
		}

		private void SetHealthToMax()
		{
			if(characterStats != null)
			{
				CurrentHealth = characterStats["Health"];
			}
		}
	}
}