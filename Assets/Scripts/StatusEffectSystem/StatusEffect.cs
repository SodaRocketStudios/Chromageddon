using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using SRS.StatSystem;

namespace SRS.StatusEffects
{
	[CreateAssetMenu(fileName = "New Status Effect", menuName = "StatusEffect/Status Effect")]
	public class StatusEffect : ScriptableObject
	{
		[SerializeField] private string procStat;
		public string ProcStat
		{
			get
			{
				return procStat;
			}
		}

		[SerializeField] private float duration;
		private float endTime;

		[SerializeField] private List<Effect> effects = new List<Effect>();

		private List<Effect> activeEffects = new List<Effect>();

		private CharacterStats targetStats;
		private StatusEffectTracker targetEffectTracker;

		public void Apply(GameObject target)
		{
			if(target.TryGetComponent<StatusEffectTracker>(out targetEffectTracker))
			{
				endTime = Time.time + duration;

				foreach(StatEffect effect in effects)
				{
					Effect effectInstance = Instantiate(effect);
					effectInstance.Apply(target);
					activeEffects.Add(effectInstance);
				}

				targetEffectTracker.AddEffect(this);
				
				Run();
			}

		}

		public  void Cancel()
		{
			endTime = Time.time;
		}

		public void Remove()
		{
			foreach(StatEffect effect in activeEffects)
			{
				effect.Remove();
			}
		}

		private async void Run()
		{
			while(Time.time < endTime)
			{
				await Task.Yield();
			}

			End();
		}


		private void End()
		{
			Remove();

			targetEffectTracker.RemoveEffect(this);
			activeEffects.Clear();
		}
	}
}