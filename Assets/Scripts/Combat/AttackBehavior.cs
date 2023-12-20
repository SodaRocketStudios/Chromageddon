using UnityEngine;

namespace SRS.Combat
{
	public abstract class AttackBehavior : ScriptableObject
	{
		public abstract void OnStart(Attack attack);

		public abstract void OnUpdate(Attack attack);

		public abstract void OnFixedUpdate(Attack attack);

		public abstract void OnEnd(Attack attack);

		protected abstract void CollisionTest(LayerMask mask);

		protected abstract void OnHit(GameObject other);
    }
}