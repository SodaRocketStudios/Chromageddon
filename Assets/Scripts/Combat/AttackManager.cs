using SRS.Input;
using SRS.Stats;
using UnityEngine;

namespace SRS.Combat
{
	public class AttackManager : MonoBehaviour
	{
		private StatContainer stats;

		private IInputSource input;

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

		private bool isAttacking;
		
		private float nextAttackTime;

		private void Awake()
		{
            stats = GetComponent<StatContainer>();
			input = GetComponent<IInputSource>();
			weapon = GetComponent<Weapon>();
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