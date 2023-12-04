using System.Collections.Generic;
using UnityEngine;

namespace SRS.Combat.StatusEffects
{
	[System.Serializable]
    public class StatusEffect : ScriptableObject, IOnHitEffect
    {
		[SerializeField] private string procStat;

		[SerializeField] private float duration;

		[SerializeField] private List<Effect> effects;

		public string ProcStat
		{
			get => procStat;
		}

        public void Trigger(GameObject target)
        {
            EffectTracker tracker = target.GetComponent<EffectTracker>();

			foreach(Effect effect in effects)
			{
				tracker.Apply(effect);
			}
        }

		private void Remove(EffectTracker tracker)
		{
			foreach(Effect effect in effects)
			{
				tracker.Cancel(effect);
			}
		}

		public void Cancel()
		{
			foreach(Effect effect in effects)
			{
				effect.Cancel();
			}
		}
    }
}