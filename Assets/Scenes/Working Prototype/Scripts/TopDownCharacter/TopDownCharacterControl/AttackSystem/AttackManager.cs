using UnityEngine;
using SRS.Stats;

namespace SRS.TopDownCharacterController.AttackSystem
{
	[RequireComponent(typeof(TopDownInputInterface))]
	public class AttackManager : MonoBehaviour
	{
		public bool AttackBlocked{get; set;}

		public float AttackSpeed
		{
			set
			{
				if(value != 0)
				{
					attackDelay = 1/value;
				}
			}
		}

		private float attackDelay = 1;

		private float attackArc;

		[SerializeField] private LayerMask attackMask;

		[Tooltip("If left empty, the character will use melee attacks instead.")]
		[SerializeField] private GameObject projectile;

		private AttackType attack;
		private TopDownInputInterface input;

		private CharacterData characterData;

		private float nextAttackTime = 0;

		private void Start()
		{
			characterData = GetComponent<CharacterData>();
			// AttackSpeed = characterData.CharacterStats["AttackSpeed"].Value;
			// attackArc = characterData.CharacterStats["AttackArc"].Value;

			input = GetComponent<TopDownInputInterface>();

			if(projectile == null)
			{
				attack = new MeleeAttack(20, attackArc);
			}
			else
			{
				attack = new RangedAttack(projectile, attackArc);
			}
		}

		private void Update()
		{
			if(input.IsAttacking)
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

			while(Time.time - numOfAttacks*attackDelay > nextAttackTime)
			{
				numOfAttacks++;
			}
			
			for(int i = 0; i < numOfAttacks; i++)
			{
				attack.Attack(transform, attackMask);
				nextAttackTime += attackDelay;
			}
			
		}
	}
}