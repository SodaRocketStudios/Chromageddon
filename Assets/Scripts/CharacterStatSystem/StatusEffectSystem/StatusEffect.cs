using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatusEffects
{
	public abstract class StatusEffect : MonoBehaviour
	{
		private StatusEffectObject statusEffect;

		private Coroutine coroutine;

		private float endTime;

		public StatusEffect()
		{
			Apply();
		}

		protected virtual void Apply()
		{
			endTime = Time.time + statusEffect.Duration;
			coroutine = StartCoroutine(EffectCoroutine());
		}

		public virtual void Remove()
		{
			StopCoroutine(coroutine);
		}

		protected abstract IEnumerator EffectCoroutine();
	}
}