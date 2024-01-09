using System.Collections.Generic;
using UnityEngine;

namespace SRS.Combat.HitEffects
{
	[CreateAssetMenu(fileName = "New Hit Effect Database", menuName = "Combat/Hit Effects/Hit Effect Database")]
	public class HitEffectDatabase : ScriptableObject
	{
		[SerializeField] private List<HitEffect> effects = new();
		public List<HitEffect> Effects
		{
			get
			{
				return effects;
			}
		}
	}
}
