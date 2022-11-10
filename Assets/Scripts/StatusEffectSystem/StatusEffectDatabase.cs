using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatusEffects
{
	public class StatusEffectDatabase : MonoBehaviour
	{
		public static StatusEffectDatabase Instance;

		[SerializeField] private List<StatusEffect> effects = new List<StatusEffect>();

		private void Awake()
		{
			if(Instance == null)
			{
				Instance = this;
			}
			else if(Instance != this)
			{
				Destroy(gameObject);
			}
		}

		public List<StatusEffect> StatusEffects()
		{
			return effects;
		}
	}
}