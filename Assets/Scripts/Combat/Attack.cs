using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using SRS.Stats;

namespace SRS.Combat
{
	public class Attack : MonoBehaviour
	{
		public UnityEvent<GameObject> OnEnd;

		private StatContainer stats;
		public StatContainer Stats
		{
			set
			{
				stats = value;
			}
		}

		[SerializeField] private DamageType damageType;

		private float lifetime;
		private float maxLifetime = 5;

		private void OnEnable()
		{
			lifetime = 0;
			StartCoroutine(LifetimeCoroutine());
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}

		public void EndAttack()
		{
			lifetime = maxLifetime;
		}

		IEnumerator LifetimeCoroutine()
		{
			do
			{
				yield return null;
				lifetime += Time.deltaTime;
			} while(lifetime < maxLifetime);

			OnEnd?.Invoke(gameObject);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			// deal damage to other
		}
	}
}
