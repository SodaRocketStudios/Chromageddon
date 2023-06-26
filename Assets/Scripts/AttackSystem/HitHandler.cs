using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SRS.StatSystem;
using SRS.Health;
using SRS.StatusEffects;
using SRS.Extensions.Random;
using SRS.Curves;

namespace SRS.AttackSystem
{

	public class HitHandler : MonoBehaviour
	{
		public delegate void OnHitHandler(Dictionary<string, Stat> attackStats);
		public UnityEvent OnHitEvent;

        [SerializeField] private float invincibilityTime;
        private bool isInvincible = false;

		private static LayerMask enemyLayer;

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

			enemyLayer = LayerMask.NameToLayer("Enemy");
		}

		public void HandleHit(CharacterStats attackerStats)
        {
            if(isInvincible) return;

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

            if(invincibilityTime > 0)
			{
				StartCoroutine(InvincibilityTimer());
			}

        }

        private float CalculateDamage(CharacterStats attackerStats)
        {
            float Damage = attackerStats["Damage"];
            float damageModifier = 1 - armorCurve.Evaluate(characterStats["Armor"]);

            Damage *= random.NextFloat() <= attackerStats["Critical Chance"] ? attackerStats["Critical Damage"] : 1;
            Damage *= damageModifier;

            return Mathf.Min(Damage, 1);
        }

        private IEnumerator InvincibilityTimer()
		{
			isInvincible = true; 

			yield return new WaitForSeconds(invincibilityTime);

			isInvincible = false;
		}

		// This should probably be moved somewhere into the enemy code.
		private void OnCollisionStay2D(Collision2D other)
		{
			if(enemyLayer.value == other.gameObject.layer)
			{
				HandleHit(other.gameObject.GetComponent<CharacterStats>());
			}	
		}
	}
}