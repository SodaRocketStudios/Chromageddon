using System.Collections.Generic;
using UnityEngine;

namespace SRS.Combat
{
	[CreateAssetMenu(fileName = "New Hit Effect Database", menuName = "Combat/Hit Effects/Hit Effect Database")]
	public class HitEffectDatabase : ScriptableObject
	{
		[SerializeField] private List<IOnHitEffect> effects = new();
		public static List<IOnHitEffect> Effects = new();

		private void Awake()
		{
			Effects = effects;
		}
	}
}
