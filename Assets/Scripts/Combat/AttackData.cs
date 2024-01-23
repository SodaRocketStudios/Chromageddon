using UnityEngine;

namespace SRS.Combat
{
	[System.Serializable]
	public class AttackData
	{
		public AttackBehavior Behavior;

		public AudioClip Sound;

		public DamageType DamageType;

		public Sprite Sprite;

		public Color Color;
	}
}