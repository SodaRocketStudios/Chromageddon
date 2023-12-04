using System.Collections.Generic;
using UnityEngine;

namespace SRS.Combat
{
	public class HitEffectDatabase : MonoBehaviour
	{
		[SerializeField] private static List<IOnHitEffect> effects;
		public List<IOnHitEffect> Effects
		{
			get => effects;
		}
	}
}
