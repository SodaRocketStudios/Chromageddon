using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatusEffects
{
	[CreateAssetMenu(fileName = "New Status Effect", menuName = "Status Effects/Status Effect")]
	public class StatusEffectObject : ScriptableObject
	{
		public string Name;

		[SerializeField]
		private float duration;

		[SerializeField]
		private EffectBehavior effectBehavior;

		[SerializeField]
		private List<EffectDataObject> data;

		[SerializeField]
		private string ProcStat;

		private Coroutine coroutine;

		public void Apply()
		{
		}

		public void Remove()
		{
			effectBehavior.Remove();
		}
	}
}