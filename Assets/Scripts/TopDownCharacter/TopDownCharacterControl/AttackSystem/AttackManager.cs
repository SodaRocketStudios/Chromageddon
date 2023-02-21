using UnityEngine;
using SRS.StatSystem;
using UnityEngine.Events;

namespace SRS.TopDownCharacterControl.AttackSystem
{
	public class AttackManager : MonoBehaviour
	{
		public UnityEvent OnAttack;

		public bool AttackBlocked{get; set;}

		public bool IsAttacking{get; set;}

		public bool attackActive
		{
			get
			{
				return attack.attackActive;
			}
		}

		[SerializeField] private LayerMask attackMask;

		[SerializeField] private AttackType attack;

		private CharacterStats characterStats;

		private float nextAttackTime = 0;

		private void Start()
		{
			characterStats = GetComponent<CharacterStats>();

			attack = Instantiate(attack);
		}

		private void Update()
		{
			if(IsAttacking)
			{
				Attack();
			}
			else if(Time.time > nextAttackTime)
			{
				nextAttackTime = Time.time;
			}
		}

		private void Attack()
		{
			if(AttackBlocked)
			{
				return;
			}

			int numOfAttacks = 0;

			float attackDelay = 1.0f/characterStats["AttackSpeed"];

			while(Time.time - numOfAttacks*attackDelay > nextAttackTime)
			{
				numOfAttacks++;
				OnAttack.Invoke();
			}

			for(int i = 0; i < numOfAttacks; i++)
			{
				attack.Attack(transform, characterStats["AttackArc"], attackMask);
				nextAttackTime += attackDelay;
			}
		}
	}
}