using SRS.PawnController;
using UnityEngine;

namespace SRS.Combat
{
	public abstract class AttackBehavior : ScriptableObject
	{
		public abstract float GetLifetime(Attack attack);

		public abstract void OnStart(Attack attack);

		public abstract void OnUpdate(Attack attack);

		public abstract void OnFixedUpdate(Attack attack);

		public abstract void OnEnd(Attack attack);

		protected abstract void CollisionTest(Attack attack);

		protected abstract void OnHit(Attack attack, RaycastHit2D hit);

		protected void Hit(Attack attack, RaycastHit2D hit)
		{
			HitHandler hitHandler;

			attack.LastHitObject = hit.transform;

			if(hit.transform.TryGetComponent(out hitHandler))
			{
				hitHandler.Hit(attack.Stats, attack.DamageType);
				hitHandler.GetComponent<PawnMover>()?.AddForce(-hit.normal*attack.Stats["Knockback"].Value);
				attack.HitParticleManager?.PlayParticles(hit.transform.position, hit.transform.rotation, hit.transform.GetComponent<SpriteRenderer>().color);
			}


			OnHit(attack, hit);
		}
    }
}