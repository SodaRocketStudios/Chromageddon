using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SRS.Stats;

namespace SRS.StatusEffects
{
	public abstract class StatusEffect : ScriptableObject
	{
		protected float endTime;

		protected StatusEffectObject effect;

		private Coroutine coroutine;

		private StatusEffectTracker targetEffectTracker;
		private CharacterData targetData;

		public StatusEffect(GameObject target)
		{
			targetEffectTracker = target.GetComponent<StatusEffectTracker>();
			targetData = target.GetComponent<CharacterData>();
			Apply();
		}

		private Coroutine Apply()
		{
			if(targetEffectTracker == null || targetData == null)
			{
				return null;
			}

			endTime = Time.time + effect.Duration;
			return targetEffectTracker.StartCoroutine(EffectCoroutine());
		}

		public void Remove()
		{
			endTime = Time.time;
		}

		protected abstract IEnumerator EffectCoroutine();
	}
}