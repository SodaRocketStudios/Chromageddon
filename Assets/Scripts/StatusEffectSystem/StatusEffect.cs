using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SRS.Stats;
using SRS.Health;

namespace SRS.StatusEffects
{
	public abstract class StatusEffect
	{
		protected abstract float duration{get; set;}
		protected float endTime;

		public abstract string procStat{get; protected set;}

		protected StatusEffectTracker targetEffectTracker;
		protected CharacterData targetData;
		protected HealthManager targetHealth;

		private bool isAffectable = true;

		public StatusEffect(){}

		public Coroutine Apply(GameObject target)
		{
			isAffectable &= target.TryGetComponent<StatusEffectTracker>(out targetEffectTracker);
			isAffectable &= target.TryGetComponent<CharacterData>(out targetData);
			isAffectable &= target.TryGetComponent<HealthManager>(out targetHealth);

			Debug.Log(isAffectable);

			if(isAffectable)
			{
				endTime = Time.time + duration;
				return targetEffectTracker.StartCoroutine(EffectCoroutine());
			}

			targetEffectTracker.RemoveEffect(this);
			return null;
		}

		public void Remove()
		{
			endTime = Time.time;
		}

		protected virtual IEnumerator EffectCoroutine()
		{
			yield return null;
		}
	}
}