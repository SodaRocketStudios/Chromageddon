using UnityEngine;
using SRS.Utils.VFX;
using UnityEditor.Animations;

namespace SRS.Combat
{
	[System.Serializable]
	public class AttackData
	{
		public AttackBehavior Behavior;

		public AudioClip Sound;

		public ParticleManager AttackParticleManager;
		public ParticleManager HitParticleManager;

		public DamageType DamageType;

		public AnimatorController AnimatorController;

		public Sprite DefaultSprite;

		public Color Color;
	}
}