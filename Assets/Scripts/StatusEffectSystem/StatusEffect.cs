using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using SRS.StatSystem;
using SRS.Health;

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

		[SerializeField] private List<StatEffect> statEffects = new List<StatEffect>();
		[SerializeField] private List<TickEffect> tickEffects = new List<TickEffect>();

		public bool HasEnded {get; private set;} = false;

		private StatusEffectTracker targetEffectTracker;
		private CharacterStats targetStats;
		private HealthManager targetHealth;

		private bool isAffectable = true;

		public bool Apply(GameObject target)
		{
			isAffectable &= target.TryGetComponent<StatusEffectTracker>(out targetEffectTracker);
			isAffectable &= target.TryGetComponent<CharacterStats>(out targetStats);
			isAffectable &= target.TryGetComponent<HealthManager>(out targetHealth);

			if(isAffectable)
			{
				endTime = Time.time + duration;
				RunEffect();
				return true;
			}

			return false;
		}

		public void Cancel()
		{
			endTime = Time.time;
		}

		private async void RunEffect()
		{
			Start();

			while(Time.time < endTime)
			{
				Tick();
				await Task.Yield();
			}

			End();
		}

		private void Start()
		{
			HasEnded = false;

			foreach(StatEffect effect in statEffects)
			{
				targetStats.AddModifier(effect.Stat, effect.Modifier);
			}

			foreach(TickEffect effect in tickEffects)
			{
				effect.Initialize();
			}
		}

		private void Tick()
		{
			foreach(TickEffect effect in tickEffects)
			{
				effect.Tick();
			}
		}

		private void End()
		{
			foreach(StatEffect effect in statEffects)
			{
				targetStats.RemoveModifier(effect.Stat, effect.Modifier);
			}

			HasEnded = true;
		}
	}
}