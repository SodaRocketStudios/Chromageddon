using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using SRS.Stats;

namespace SRS.Combat
{
	public abstract class AttackBehavior : MonoBehaviour, IPoolable
	{
		public UnityEvent<GameObject> OnStart;
		public UnityEvent<GameObject> OnEnd;

		protected StatContainer stats;
		public StatContainer Stats
		{
			set
			{
				stats = value;
				OnStatsSet();
			}
		}

		[SerializeField] private DamageType damageType;

		protected LayerMask layerExclusions;

		private GameObject source;
		public GameObject Source
		{
			set
			{
				source = value;
				layerExclusions = 0;
				layerExclusions |= 1 << source.layer;
			}
		}

		private float lifetimeTimer;
		protected float lifetime;

		private void OnEnable()
		{
			lifetimeTimer = 0;
			OnStart?.Invoke(gameObject);
			StartCoroutine(LifetimeCoroutine());
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}

		public void End()
		{
			lifetimeTimer = lifetime;
		}

		public void ResetLiftime()
		{
			lifetimeTimer = 0;
		}

		private IEnumerator LifetimeCoroutine()
		{
			do
			{
				yield return null;
				lifetimeTimer += Time.deltaTime;
			} 
			while(lifetimeTimer < lifetime);

			OnEnd?.Invoke(gameObject);
		}

		protected void Hit(GameObject other)
		{
			if((layerExclusions & (1 << other.layer)) > 0)
			{
				return;
			}

			HitHandler otherHitHandler;

			if(other.TryGetComponent(out otherHitHandler))
			{
				otherHitHandler.Hit(stats, damageType);
			}

			HitBehavior(other);
		}

		protected abstract void OnStatsSet();

		protected abstract void HitBehavior(GameObject other);

        public void OnGet()
        {
            throw new System.NotImplementedException();
        }

        public void OnReturn()
        {
            throw new System.NotImplementedException();
        }
    }
}