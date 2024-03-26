using UnityEngine;
using SRS.Utils.VFX;
using SRS.Audio;

namespace SRS.Combat
{
	[System.Serializable]
	public class AttackData
	{
		public AttackBehavior Behavior;

		public Sound Sound;

		public ParticleManager AttackParticleManager;
		public ParticleManager HitParticleManager;

		public DamageType DamageType;

		public RuntimeAnimatorController AnimatorController;

		public Sprite DefaultSprite;

		public Color Color;
	}
}