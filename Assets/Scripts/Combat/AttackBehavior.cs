using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using SRS.Stats;

namespace SRS.Combat
{
	public abstract class AttackBehavior : ScriptableObject
	{
		public abstract void Start();

		public abstract void Update(Transform transform);

		public abstract void HitCast(Transform transform);

		protected abstract void OnHitBehavior(GameObject other);

		public abstract void OnDestroy();
    }
}