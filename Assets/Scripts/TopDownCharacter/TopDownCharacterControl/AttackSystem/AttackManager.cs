using UnityEngine;
using SRS.StatSystem;

namespace SRS.TopDownCharacterControl.AttackSystem
{
	public class AttackManager : MonoBehaviour
	{
		public bool AttackBlocked{get; set;}

		public bool IsAttacking{get; set;}

		public bool attackActive
		{
			get
			{
				return attack.attackActive;
			}
		}

		private float attackDelay = 1;

		private float attackAngle;

		[SerializeField] private LayerMask attackMask;

		[SerializeField] private AttackType attack;

		private CharacterStats characterData;

		private float nextAttackTime = 0;

		private void Start()
		{
			characterData = GetComponent<CharacterStats>();

			attack = Instantiate(attack);

			Stat attackSpeed = characterData.Character["AttackSpeed"];
			UpdateAttackSpeed(attackSpeed.Value);
			
			Stat attackArc = characterData.Character["AttackArc"];
			attackAngle = attackArc.Value;

			UpdateAttackStats();
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
			attack.UpdateStats(characterData.Attack);
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