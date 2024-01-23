using UnityEngine;

namespace SRS.Combat
{
	[System.Serializable]
	public class AttackData
	{
		public AttackBehavior Behavior;

		public DamageType damageType;

		public Sprite Sprite;

		public Color Color;
	}
}