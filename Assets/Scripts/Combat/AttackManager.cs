using SRS.Input;
using SRS.Stats;
using UnityEngine;

namespace SRS.Combat
{
	public class AttackManager : MonoBehaviour
	{
		private StatContainer stats;

		private IInputSource input;

		private Weapon weapon;

		private bool isAttacking;

		private void Awake()
		{
			input = GetComponent<IInputSource>();
			weapon = GetComponent<Weapon>();
		}

		private void Attack()
		{
			if(weapon != null)
			{
				weapon.Attack(stats);
			}
			else
			{
				Debug.LogWarning("No weapon available in attack manager", gameObject);
			}
		}

		private void Update()
		{
			// TO DO -- Control attacking state based on stats
			isAttacking = input.AttackInput;

			if(isAttacking)
			{
				Attack();
			}
		}
	}
}
