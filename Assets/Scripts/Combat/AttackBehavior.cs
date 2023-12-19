using UnityEngine;

namespace SRS.Combat
{
	public abstract class AttackBehavior : ScriptableObject
	{
		public abstract void Start();

		public abstract void Update(Transform transform);

		public abstract void FixedUpdate(Transform transform);

		protected abstract void HitCast(Transform transform);

		protected abstract void OnHitBehavior(GameObject other);

		public abstract void OnDestroy();
    }
}