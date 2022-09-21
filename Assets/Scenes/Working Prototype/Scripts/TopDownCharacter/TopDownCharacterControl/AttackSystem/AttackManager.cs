using UnityEngine;
using SRS.Stats;

namespace SRS.TopDownCharacterController.AttackSystem
{
	[RequireComponent(typeof(TopDownInputInterface))]
	public class AttackManager : MonoBehaviour
	{
		public bool AttackBlocked{get; set;}

		private float attackDelay = 1;

		private float attackAngle;

		[SerializeField] private LayerMask attackMask;

		[Tooltip("If left empty, the character will use melee attacks instead.")]
		[SerializeField] private GameObject projectile;

		private AttackType attack;
		private TopDownInputInterface input;

		private CharacterData characterData;

		private float nextAttackTime = 0;

		private void Start()
		{
			input = GetComponent<TopDownInputInterface>();

			characterData = GetComponent<CharacterData>();
			
			if(projectile == null)
			{
				attack = new MeleeAttack(characterData.AttackStats);
			}
			else
			{
				attack = new RangedAttack(characterData.AttackStats, projectile);
			}

			characterData.OnAttackStatChanged += UpdateAttackStats;
			UpdateAttackStats();

			Stat attackSpeed = characterData.CharacterStats["AttackSpeed"];

			attackSpeed.OnValueChanged += UpdateAttackSpeed;
			UpdateAttackSpeed(attackSpeed.Value);
			
			Stat attackArc = characterData.CharacterStats["AttackArc"];
			attackAngle = attackArc.Value;
			attackArc.OnValueChanged += value => attackAngle = value;

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
				attack.Attack(transform, attackAngle, attackMask);
				nextAttackTime += attackDelay;
			}
		}

		private void UpdateAttackStats()
		{
			attack.UpdateStats(characterData.AttackStats);
		}

		private void UpdateAttackSpeed(float attackSpeed)
		{
			if(attackSpeed > 0)
			{
				attackDelay = 1/attackSpeed;
			}
		}
	}
}