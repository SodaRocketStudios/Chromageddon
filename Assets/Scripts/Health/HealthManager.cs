using System.Threading.Tasks;
using UnityEngine;
using SRS.StatSystem;
using SRS.Extensions;

namespace SRS.Health
{
	public class HealthManager : MonoBehaviour
	{
		public float MaxHealth{get {return characterStats["Health"];}}
		
		public float CurrentHealth {get; private set;}

		[SerializeField] private float damagePauseTime;

		public GameObjectEvent OnDeath;

		private CharacterStats characterStats;

		private bool isInvincible;

		private void Start()
		{
			characterStats = GetComponent<CharacterStats>();

			SetHealthToMax();
		}

		private void OnEnable()
		{
			SetHealthToMax();
		}

		public void Damage(float amount)
		{
			if(isInvincible) return;

			AlterHealth(-amount);

			if(damagePauseTime > 0)
			{
				InvincibilityTime();
			}
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
		}

		private void SetHealthToMax()
		{
			if(characterStats != null)
			{
				CurrentHealth = characterStats["Health"];
			}
		}

		private async void InvincibilityTime()
		{
			isInvincible = true; 

			await Task.Delay((int)(damagePauseTime*1000));

			isInvincible = false;
		}
	}
}