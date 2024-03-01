using System.Threading;
using UnityEngine;
using SRS.Stats;

namespace SRS.Combat
{
	public class HealthRegen : MonoBehaviour
	{
		[SerializeField] private float regenMultiplier;

		[SerializeField] private float regenInterval;

		private HitHandler hitHandler;

		private StatContainer stats;

		private CancellationTokenSource tokenSource = new();
		
		private float timer = 0;

		private void Awake()
		{
			hitHandler = GetComponent<HitHandler>();
			stats = GetComponent<StatContainer>();
		}

		private void OnEnable()
		{
			tokenSource.Dispose();
			tokenSource = new();

			Regen(tokenSource.Token);
		}

		private void OnDisable()
		{
			tokenSource.Cancel();
		}

		private async void Regen(CancellationToken token)
		{
			while(hitHandler.Health.Value.Current > 0)
			{
				if(token.IsCancellationRequested)
				{
					break;
				}

				if(timer >= regenInterval)
				{
					hitHandler.Health.Heal(stats["Health Regen"].Value*regenMultiplier);
					timer = 0;
				}

				timer += Time.deltaTime;

				await Awaitable.NextFrameAsync();
			}
		}
	}
}