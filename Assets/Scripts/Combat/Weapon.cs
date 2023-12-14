using UnityEngine;
using SRS.Utils.ObjectPooling;
using SRS.Stats;

namespace SRS.Combat
{
	[CreateAssetMenu(fileName = "New Weapon", menuName = "Combat/Weapon")]
    public class Weapon : ScriptableObject
	{
		[SerializeField] private WeaponData weaponData;
		public WeaponData WeaponData
		{
			set
			{
				weaponData = value;
			}
		}

		// [SerializeField] private ObjectPool<AttackBehavior> attackObjectPool;

		public void Attack(StatContainer attackStats)
		{
			// AttackBehavior attackInstance =  attackObjectPool.Get().GetComponent<AttackBehavior>();
			// attackInstance.Stats = attackStats;
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