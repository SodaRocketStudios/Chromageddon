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
			Debug.Log("hit");
			HitHandler hitHandler;

			attack.LastHitObject = hit.transform.gameObject;

			if(hit.transform.TryGetComponent(out hitHandler))
			{
				hitHandler.Hit(attack.Stats, attack.DamageType);
			}

			OnHit(attack, hit);
		}
    }
}