using UnityEngine;
using SRS.StatSystem;
using SRS.Extensions;
using SRS.Curves;

namespace SRS.Health
{
	public class HealthManager : MonoBehaviour
	{
		public float MaxHealth{get {return characterStats["Health"];}}
		
		public float CurrentHealth {get; private set;}

		public GameObjectEvent OnDeath;

		private CharacterStats characterStats;

		private SigmoidCurve armorCurve = new SigmoidCurve(2, 1, 1, .05f);

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
			float damageModifier = armorCurve.Sample(characterStats["Armor"]);
			amount -= amount*damageModifier;

			amount = Mathf.Min(amount, 1);

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