using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SRS.StatSystem;
using SRS.Health;
using SRS.StatusEffects;
using SRS.Extensions.Random;
using SRS.Curves;

namespace SRS.TopDownCharacterControl.AttackSystem
{

	public class HitHandler : MonoBehaviour
	{
		public delegate void OnHitHandler(Dictionary<string, Stat> attackStats);
		public UnityEvent OnHitEvent;

		private HealthManager healthManager;
		private StatusEffectTracker effectTracker;
		private System.Random random = new System.Random(Guid.NewGuid().GetHashCode());

		private CharacterStats characterStats;

		private SigmoidCurve armorCurve = new SigmoidCurve(2, 1, 1, .05f);

		private void Awake()
		{
			healthManager = GetComponent<HealthManager>();
			effectTracker = GetComponent<StatusEffectTracker>();
			characterStats = GetComponent<CharacterStats>();
		}

		public void HandleHit(CharacterStats attackerStats)
        {
			healthManager.Damage(CalculateDamage(attackerStats));

            if (healthManager.CurrentHealth <= 0) return;

            OnHitEvent?.Invoke();

            // foreach(StatusEffect effect in StatusEffectDatabase.Instance.StatusEffects())
            // {
            // 	if(random.NextFloat() <= attackStats[effect.ProcStat].Value)
            // 	{
            // 		effect.Apply(gameObject);
            // 	}
            // }

        }

        private float CalculateDamage(CharacterStats attackerStats)
        {
            float Damage = attackerStats["Damage"];
            float damageModifier = 1 - armorCurve.Sample(characterStats["Armor"]);

            Damage *= random.NextFloat() <= attackerStats["Critical Chance"] ? attackerStats["Critical Damage"] : 1;
            Damage *= damageModifier;

            return Mathf.Min(Damage, 1);
        }
	}
}