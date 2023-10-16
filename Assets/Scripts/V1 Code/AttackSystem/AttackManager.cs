using UnityEngine;
using SRS.StatSystem;
using UnityEngine.Events;
using SRS.Input;

namespace SRS.AttackSystem
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

		private IInputProcessor inputProcessor;

		private CharacterStats characterStats;

		private float nextAttackTime = 0;

		private void Start()
		{
			characterStats = GetComponent<CharacterStats>();
			inputProcessor = GetComponent<IInputProcessor>();

			attack = Instantiate(attack);
			attack.Initialize(characterStats);

			nextAttackTime = Time.time;
		}

		private void Update()
		{
			IsAttacking = inputProcessor.IsAttacking;
			
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

			float attackDelay = characterStats["Attack Delay"];

			while(Time.time - numOfAttacks*attackDelay > nextAttackTime)
			{
				numOfAttacks++;
				OnAttack.Invoke();
			}

			for(int i = 0; i < numOfAttacks; i++)
			{
				attack.Attack(transform, characterStats["Attack Arc"], attackMask);
				nextAttackTime += attackDelay;
			}
		}
	}
}