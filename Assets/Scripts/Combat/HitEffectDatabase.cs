using System.Collections.Generic;
using UnityEngine;

namespace SRS.Combat
{
	[CreateAssetMenu(fileName = "New Hit Effect Database", menuName = "Combat/Hit Effects/Hit Effect Database")]
	public class HitEffectDatabase : ScriptableObject
	{
		[SerializeField] private static List<IOnHitEffect> effects;
		public List<IOnHitEffect> Effects
		{
			get => effects;
		}
	}
}
