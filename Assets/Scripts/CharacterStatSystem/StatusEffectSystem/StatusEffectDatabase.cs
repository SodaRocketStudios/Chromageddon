using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatusEffects
{
	public class StatusEffectDatabase : MonoBehaviour
	{
		public static StatusEffectDatabase Instance;
		
		public Dictionary<string, StatusEffectObject> statusEffects = new Dictionary<string, StatusEffectObject>();

		[SerializeField]
		private List<StatusEffectObject> effectsList;

		private void Awake()
		{
			if(Instance == null)
			{
				Instance = this;
			}
			else if(Instance != this)
			{
				Destroy(this);
			}

			foreach(StatusEffectObject effect in effectsList)
			{
				statusEffects[effect.Name] = effect;
			}
		}
	}
}