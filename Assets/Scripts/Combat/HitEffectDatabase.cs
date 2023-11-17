using System.Collections.Generic;
using UnityEngine;

namespace SRS.Combat
{
	public class HitEffectDatabase : MonoBehaviour
	{
		private static List<IOnHitEffect> effects;
		public List<IOnHitEffect> Effects
		{
			get => effects;
		}
	}
}
