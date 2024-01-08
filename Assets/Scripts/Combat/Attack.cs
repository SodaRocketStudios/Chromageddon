using UnityEngine;
using SRS.Utils.ObjectPooling;
using SRS.Stats;
using System.Threading;

namespace SRS.Combat
{
	public class Attack : PooledObject
	{
		public AttackBehavior Behavior {get; private set;}
		
		public StatContainer Stats {get; private set;}

		public DamageType DamageType {get; private set;}

		public LayerMask collisionMask {get; private set;}

		public Vector2 spriteSize 
		{
			get
			{
				return spriteRenderer.sprite.bounds.extents;
			}
		}

		[HideInInspector] public Transform LastHitObject;

		[SerializeField] private LayerMask ignoredLayers;

		private float lifetime;

		private float timer;

		private SpriteRenderer spriteRenderer;

		private CancellationTokenSource cancellationTokenSource = new();

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		public void Initialize(AttackData data, GameObject attacker)
		{
			Behavior = data.Behavior;
			
			spriteRenderer.sprite = data.Sprite;

			collisionMask = ~ignoredLayers;
			collisionMask &= ~(1 << attacker.layer);
			
			Stats = attacker.GetComponent<StatContainer>();

			lifetime = Behavior.GetLifetime(this);

			LastHitObject = null;

			Behavior.OnStart(this);

			cancellationTokenSource.Dispose();
			cancellationTokenSource = new();

			LifetimeTask(cancellationTokenSource.Token);
		}

		public void Despawn()
		{
			cancellationTokenSource.Cancel();
		}

		public void ResetLifetime()
		{
			timer = 0;
		}

		private void Update()
		{
			Behavior.OnUpdate(this);
		}

		private void FixedUpdate()
		{
			Behavior.OnFixedUpdate(this);
		}

		private async void LifetimeTask(CancellationToken token)
		{
			timer = 0;

			while(timer < lifetime)
			{
				if(token.IsCancellationRequested)
				{
					break;
				}
				timer += Time.deltaTime;
				await Awaitable.NextFrameAsync();
			}

			Behavior.OnEnd(this);

			ReturnToPool();
		}
	}
}