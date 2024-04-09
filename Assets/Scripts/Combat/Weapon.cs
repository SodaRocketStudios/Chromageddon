using UnityEngine;
using SRS.Stats;
using SRS.Utils.ObjectPooling;
using SRS.Statistics;
using SRS.Audio;

namespace SRS.Combat
{
	[CreateAssetMenu(fileName = "New Weapon", menuName = "Combat/Weapon")]
    public class Weapon : EquipableObject
	{
        [SerializeField] private AttackData attackData;

		[SerializeField] private ObjectPool attackPool;

        public Sound Sound
        {
            get => attackData.Sound;
        }

        [SerializeField, Range(0, 1)] private float recoilStrength = 1;
        public float RecoilStrength
        {
            get => recoilStrength;
        }

		public void Attack(GameObject attacker)
		{
            for(int i = 0; i < attacker.GetComponent<StatContainer>()["Projectiles"].Value; i++)
            {
                Attack attack = attackPool.Get(attacker.transform.position, attacker.transform.rotation) as Attack;
                attack.Initialize(attackData, attacker);
            }

            if(attacker.CompareTag("Player"))
            {
                StatisticManager.Instance["Shots Fired"].Value++;
                StatisticManager.Instance["Total Shots Fired"].Value++;
            }
		}

        protected override void OnEquip(StatContainer container)
        {
            // TODO Weapon on equip
            // Debug.Log($"{name} equipped");
        }

        protected override void OnUnequip(StatContainer container)
        {
            // TODO Weapon on unequip
            // Debug.Log($"{name} unequipped");
        }
    }
}