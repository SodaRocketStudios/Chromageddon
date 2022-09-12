using UnityEngine;

namespace SodaRocket.TopDownCharacterController.AttackSystem
{
	[RequireComponent(typeof(TopDownInputInterface))]
	public class AttackManager : MonoBehaviour
	{
		public bool AttackBlocked{get; set;}

		public float AttackSpeed
		{
			set
			{
				attackSpeed = value;
				attackDelay = 1/attackSpeed;
			}
		}
		private float attackSpeed;

		private float attackDelay;

		[SerializeField] private LayerMask attackMask;

		[Tooltip("If left empty, the character will use melee attacks instead.")]
		[SerializeField] private GameObject projectile;

		private AttackType attack;
		private TopDownInputInterface input;

		private float nextAttackTime = 0;

		private void Start()
		{
			AttackSpeed = 1;

			input = GetComponent<TopDownInputInterface>();

			if(projectile == null)
			{
				attack = new MeleeAttack(20, 60);
			}
			else
			{
				attack = new RangedAttack(projectile, 30);
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
			
			if(Time.time >= nextAttackTime)
			{
				attack.Attack(transform, attackMask);
				nextAttackTime += attackDelay;
			}
			
		}
	}
}