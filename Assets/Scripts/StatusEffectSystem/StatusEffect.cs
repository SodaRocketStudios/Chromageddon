using System.Collections;
using UnityEngine;
using SRS.StatSystem;
using SRS.Health;

namespace SRS.StatusEffects
{
	public abstract class StatusEffect : ScriptableObject
	{
		[SerializeField] private string procStat;
		public string ProcStat
		{
			get
			{
				return procStat;
			}
		}

		[SerializeField] protected float duration;
		protected float endTime;

		protected StatusEffectTracker targetEffectTracker;
		protected CharacterData targetData;
		protected HealthManager targetHealth;

		private bool isAffectable = true;

		public void Apply(GameObject target)
		{
			isAffectable &= target.TryGetComponent<StatusEffectTracker>(out targetEffectTracker);
			isAffectable &= target.TryGetComponent<CharacterData>(out targetData);
			isAffectable &= target.TryGetComponent<HealthManager>(out targetHealth);

			if(isAffectable)
			{
				endTime = Time.time + duration;
				targetEffectTracker.StartCoroutine(EffectCoroutine());
				return;
			}

			if(targetEffectTracker != null) Remove();
		}

		public void End()
		{
			endTime = Time.time;
		}

		private void Remove()
		{
			targetEffectTracker.RemoveEffect(this);
		}


		protected abstract IEnumerator EffectCoroutine();
	}
}