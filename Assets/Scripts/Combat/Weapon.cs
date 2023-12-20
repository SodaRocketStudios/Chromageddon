using UnityEngine;
using SRS.Stats;
using SRS.Utils.ObjectPooling;

namespace SRS.Combat
{
	[CreateAssetMenu(fileName = "New Weapon", menuName = "Combat/Weapon")]
    public class Weapon : EquipableObject
	{
        [SerializeField] private AttackBehavior behavior;

		[SerializeField] private ObjectPool attackPool;

		public void Attack(StatContainer attackStats)
		{
            // get an instance of the attack from the attack pool
            // initialize the attack.


			// AttackBehavior attackInstance =  attackObjectPool.Get().GetComponent<AttackBehavior>();
			// attackInstance.Stats = attackStats;
		}

        protected override void OnEquip(StatContainer container)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnUnequip(StatContainer container)
        {
            throw new System.NotImplementedException();
        }

        // --------------------------- Unity Object Pool methods -------------------

        // private GameObject CreateAttackObject()
        // {
        //     GameObject instance = Instantiate(weaponData.AttackObject);
        // 	instance.SetActive(false);
        // 	instance.layer = LayerMask.NameToLayer("Attack");
        // 	AttackBehavior attackInstance = instance.GetComponent<AttackBehavior>();
        // 	attackInstance.OnEnd.AddListener(attackObjectPool.Release);
        // 	attackInstance.Source = gameObject;
        // 	return instance;
        // }

        // private void OnGetAttackObject(GameObject attackObject)
        // {
        // 	attackObject.transform.position = transform.position;
        // 	attackObject.transform.rotation = transform.rotation;
        // 	attackObject.SetActive(true);
        // }

        // private void OnReleaseAttackObject(GameObject attackObject)
        // {
        // 	attackObject.SetActive(false);
        // }
    }
}