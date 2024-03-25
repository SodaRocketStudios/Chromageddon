using UnityEngine;
using Cinemachine;
using SRS.Input;
using SRS.Stats;
using SRS.Statistics;

namespace SRS.Combat
{
	public class AttackManager : MonoBehaviour
	{
		[SerializeField] private Weapon weapon;
		public Weapon Weapon
		{
			get => weapon;

			set
			{
				weapon?.Unequip(stats);
				weapon = value;
				weapon?.Equip(stats);
				nextAttackTime = Time.time + stats["Attack Delay"].Value;
			}
		}

		[SerializeField] private CinemachineImpulseDefinition recoilImpulse;

		private StatContainer stats;

		private IInputSource input;

		private bool isAttacking;
		
		private float nextAttackTime;

		private CinemachineImpulseSource impulseSource;

		private AudioSource audioSource;

		private void Awake()
		{
            stats = GetComponent<StatContainer>();
			input = GetComponent<IInputSource>();
			impulseSource = GetComponent<CinemachineImpulseSource>();
			audioSource = GetComponent<AudioSource>();
		}

		private void Start()
		{
			if(weapon != null)
			{
				weapon.Equip(stats);
			}

			if(CompareTag("Player"))
			{
				StatisticManager.Instance["Total Shots Fired"].SetPersistence(true);
			}
		}

		private void OnEnable()
		{
			nextAttackTime = Time.time + stats["Attack Delay"].Value;
		}

		private void Update()
		{
			isAttacking = input.AttackInput;

			if(isAttacking)
			{
				Attack();
			}
			else
			{
				nextAttackTime = Mathf.Max(Time.time, nextAttackTime);
			}
		}

		private void Attack()
		{
			if(weapon == null)
			{
				Debug.LogWarning("No Weapon set.");
				return;
			}

			int numOfAttacks = 0;

			float attackDelay = stats["Attack Delay"].Value;

			if(attackDelay < 0)
			{
				nextAttackTime = Mathf.Max(Time.time, nextAttackTime);
				return;
			}

			while(Time.time - numOfAttacks*attackDelay >= nextAttackTime)
			{
				numOfAttacks++;
			}

			if(numOfAttacks > 0)
			{
				if(weapon.Sound != null)
				{
					audioSource?.PlayOneShot(weapon.Sound);
				}
				GenerateRecoil();
			}

			for(int i = 0; i < numOfAttacks; i++)
			{
				weapon.Attack(gameObject);
				nextAttackTime += attackDelay;
			}
		}

		private void GenerateRecoil()
		{
			if(impulseSource == null)
			{
				return;
			}
			impulseSource.m_ImpulseDefinition = recoilImpulse;
			impulseSource.GenerateImpulse(transform.right*weapon.RecoilStrength);
		}
	}
}