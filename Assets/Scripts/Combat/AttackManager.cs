using UnityEngine;
using Cinemachine;
using SRS.Input;
using SRS.Stats;

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
				if(weapon != null)
				{
					weapon.Unequip(stats);
				}
				weapon = value;
				weapon.Equip(stats);
			}
		}

		private StatContainer stats;

		private IInputSource input;

		private bool isAttacking;
		
		private float nextAttackTime;

		private CinemachineImpulseSource impulseSource;

		private void Awake()
		{
            stats = GetComponent<StatContainer>();
			input = GetComponent<IInputSource>();
			impulseSource = GetComponent<CinemachineImpulseSource>();
		}

		private void Start()
		{
			if(weapon != null)
			{
				weapon.Equip(stats);
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

			while(Time.time - numOfAttacks*attackDelay >= nextAttackTime)
			{
				numOfAttacks++;
			}

			for(int i = 0; i < numOfAttacks; i++)
			{
				weapon.Attack(gameObject);
				impulseSource.GenerateImpulse(transform.right*weapon.RecoilStrength);
				nextAttackTime += attackDelay;
			}
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
	}
}