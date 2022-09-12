using UnityEngine;
using SodaRocket.AttackProto;

namespace SodaRocket.CharacterControllerSystemProto
{
	[RequireComponent(typeof(InputInterfaceProto))]
	public class AttackManagerProto : MonoBehaviour
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

		[SerializeField] private AttackType attackType;

		[SerializeField] private LayerMask attackMask;

		[SerializeField] private GameObject projectile;

		private AttackTypeProto attack;
		private InputInterfaceProto input;

		private float nextAttackTime = 0;

		private void Start()
		{
			AttackSpeed = 100;

			input = GetComponent<InputInterfaceProto>();

			if(attackType == AttackType.melee)
			{
				attack = new MeleeAttackProto();
			}
			else if(attackType == AttackType.ranged)
			{
				attack = new RangedAttackProto(projectile);
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

		private enum AttackType
		{
			melee,
			ranged
		}
	}
}