using UnityEngine;
using SRS.Stats;

namespace SRS.TopDownCharacterController.AttackSystem
{
	[RequireComponent(typeof(TopDownInputInterface))]
	public class AttackManager : MonoBehaviour
	{
		public bool AttackBlocked{get; set;}

		private float attackSpeed
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
			characterData.CharacterStats["AttackSpeed"].OnValueChanged += UpdateStats;
			
			UpdateStats();

			input = GetComponent<TopDownInputInterface>();

			if(projectile == null)
			{
				attack = new MeleeAttack(characterData.AttackStats);
			}
			else
			{
				attack = new RangedAttack(characterData.AttackStats);
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

		private void UpdateStats()
		{
			attack.UpdateStats(characterData.AttackStats);

			attackSpeed = characterData.CharacterStats["AttackSpeed"].Value;
		}
	}
}