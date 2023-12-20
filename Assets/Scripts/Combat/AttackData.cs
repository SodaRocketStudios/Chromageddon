using UnityEngine;

namespace SRS.Combat
{
	[System.Serializable]
	public class AttackData
	{
		public AttackBehavior Behavior;

		public DamageType damageType;

		public float Lifetime;

		public Sprite Sprite;
	}
}