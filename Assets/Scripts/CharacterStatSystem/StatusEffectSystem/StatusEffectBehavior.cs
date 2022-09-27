using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatusEffects
{
	public abstract class StatusEffectBehavior : MonoBehaviour
	{
		protected float endTime;

		private Coroutine coroutine;
		
		protected StatusEffectBehavior(float duration)
		{
			coroutine = Apply(duration);
		}

		private Coroutine Apply(float duration)
		{
			endTime = Time.time + duration;
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