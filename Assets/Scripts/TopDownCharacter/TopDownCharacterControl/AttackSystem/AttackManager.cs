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

		private float attackDelay = 1;

		private float attackAngle;

		[SerializeField] private LayerMask attackMask;

		[SerializeField] private AttackType attack;

		private CharacterData characterData;

		private float nextAttackTime = 0;

		private void Start()
		{
			characterData = GetComponent<CharacterData>();

			attack = Instantiate(attack);

			Stat attackSpeed = characterData.Stats["AttackSpeed"];
			UpdateAttackSpeed(attackSpeed.Value);
			
			Stat attackArc = characterData.Stats["AttackArc"];
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
				OnAttack.Invoke();
			}

			for(int i = 0; i < numOfAttacks; i++)
			{
				attack.Attack(transform, attackAngle, attackMask);
				nextAttackTime += attackDelay;
			}
		}

		private void UpdateAttackStats()
		{
			attack.UpdateStats(characterData.Stats);
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