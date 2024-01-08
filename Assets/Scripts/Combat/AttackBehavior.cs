using SRS.Stats;
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

		protected abstract void OnHit(Attack attack, GameObject other);
    }
}