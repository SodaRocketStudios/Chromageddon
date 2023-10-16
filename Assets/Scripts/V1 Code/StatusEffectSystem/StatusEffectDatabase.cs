using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatusEffects
{
	public class StatusEffectDatabase : MonoBehaviour
	{
		public static StatusEffectDatabase Instance;

		[SerializeField] private List<StatusEffect> effects = new List<StatusEffect>();
		public List<StatusEffect> Effects
		{
			get {return effects;}
		}

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
	}
}