using UnityEngine;
using SRS.Stats;
using SRS.Utils.ObjectPooling;

namespace SRS.Combat
{
	[CreateAssetMenu(fileName = "New Weapon", menuName = "Combat/Weapon")]
    public class Weapon : EquipableObject
	{
        [SerializeField] private AttackData attackData;

		[SerializeField] private ObjectPool attackPool;

		public void Attack(GameObject attacker)
		{
            Attack attack = attackPool.Get(attacker.transform.position, attacker.transform.rotation) as Attack;
            attack.Initialize(attackData, attacker);
		}

        protected override void OnEquip(StatContainer container)
        {
            // TODO Weapon on equip
            Debug.Log($"{name} equipped");
        }

        protected override void OnUnequip(StatContainer container)
        {
            // TODO Weapon on unequip
            Debug.Log($"{name} unequipped");
        }
    }
}