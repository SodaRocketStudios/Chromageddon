using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatusEffects
{
	[CreateAssetMenu(fileName = "New Status Effect", menuName = "Status Effects/Status Effect")]
	public class StatusEffectObject : ScriptableObject
	{
		public string Name;

		public float Duration;

		public List<EffectDataObject> data;
	}
}