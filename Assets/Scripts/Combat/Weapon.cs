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
            Debug.Log("Attack");
            Attack attack = attackPool.Get(attacker.transform.position, attacker.transform.rotation) as Attack;
            attack.Initialize(attackData, attacker);
		}

        protected override void OnEquip(StatContainer container)
        {
            // TODO Weapon on equip
            throw new System.NotImplementedException();
        }

        protected override void OnUnequip(StatContainer container)
        {
            // TODO Weapon on unequip
            throw new System.NotImplementedException();
        }
    }
}