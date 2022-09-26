using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatusEffects
{
	public abstract class StatusEffect : MonoBehaviour
	{
		protected List<EffectDataObject> effectData;
		protected float endTime;

		private Coroutine coroutine;
		
		protected StatusEffect(float duration, List<EffectDataObject> data)
		{
			effectData = new List<EffectDataObject>(data);
			coroutine = Apply(duration);
		}

		private Coroutine Apply(float duration)
		{
			return StartCoroutine(EffectCoroutine(duration));
		}

		public void Remove()
		{
			endTime = Time.time;
			// StopCoroutine(coroutine);
		}

		protected abstract IEnumerator EffectCoroutine(float duration);
	}
}