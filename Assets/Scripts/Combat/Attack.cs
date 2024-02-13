using UnityEngine;
using SRS.Utils.ObjectPooling;
using SRS.Stats;
using System.Threading;
using SRS.Utils.VFX;

namespace SRS.Combat
{
	public class Attack : PooledObject
	{
		public AttackBehavior Behavior {get; private set;}
		
		public StatContainer Stats {get; private set;}

		public DamageType DamageType {get; private set;}

		public LayerMask CollisionMask {get; private set;}

		public ParticleManager HitParticleManager{get; private set;}
		public ParticleManager AttackParticleManager{get; private set;}

		public Vector2 spriteSize 
		{
			get
			{
				return spriteRenderer.sprite.bounds.extents;
			}
		}


		[HideInInspector] public Transform LastHitObject;

		[SerializeField] private LayerMask ignoredLayers;


		private SpriteRenderer spriteRenderer;
		public SpriteRenderer SpriteRenderer
		{
			get => spriteRenderer;
		}

		private Animator animator;

		private float lifetime;

		private float timer;

		private CancellationTokenSource cancellationTokenSource = new();

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
			animator = GetComponent<Animator>();
		}

		public void Initialize(AttackData data, GameObject attacker)
		{
			Behavior = data.Behavior;

			HitParticleManager = data.HitParticleManager;
			AttackParticleManager = data.AttackParticleManager;
			
			animator.runtimeAnimatorController = data.animatorController;
			spriteRenderer.color = data.Color;

			CollisionMask = ~ignoredLayers;
			CollisionMask &= ~(1 << attacker.layer);

			DamageType = data.DamageType;
			
			Stats = attacker.GetComponent<StatContainer>();

			lifetime = Behavior.GetLifetime(this);

			LastHitObject = null;

			spriteRenderer.drawMode = SpriteDrawMode.Simple;
			transform.localScale = Vector3.one;

			Behavior.OnStart(this);

			cancellationTokenSource.Dispose();
			cancellationTokenSource = new();

			AttackParticleManager?.PlayParticles(transform.position, transform.rotation, spriteRenderer.color);

			LifetimeTask(cancellationTokenSource.Token);

		}

		public void PlayAnimation(string name)
		{
			GetComponent<Animator>().Play(name);
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