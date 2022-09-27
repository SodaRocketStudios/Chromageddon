using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatusEffects
{
	public abstract class StatusEffectBehavior : MonoBehaviour
	{
		protected float endTime;

		protected StatusEffectObject effect;

		private Coroutine coroutine;

		protected StatusEffectBehavior()
		{
			coroutine = Apply();
		}

		private Coroutine Apply()
		{
			endTime = Time.time + effect.Duration;
			return StartCoroutine(EffectCoroutine());
		}

		public void Remove()
		{
			endTime = Time.time;
			// StopCoroutine(coroutine);
		}

		protected abstract IEnumerator EffectCoroutine();
	}
}