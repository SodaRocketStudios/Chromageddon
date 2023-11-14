using UnityEngine;
using SRS.Stats;
using UnityEngine.Pool;

namespace SRS.Combat
{
    public class Weapon : MonoBehaviour
	{
		[SerializeField] private WeaponData weaponData;
		public WeaponData WeaponData
		{
			set
			{
				weaponData = value;
			}
		}

		ObjectPool<GameObject> attackObjectPool;

		private void Start()
		{
			attackObjectPool = new(CreateAttackObject, OnGetAttackObject, OnReleaseAttackObject);
		}

		public void Attack(StatContainer attackStats)
		{
			AttackBehavior attackInstance =  attackObjectPool.Get().GetComponent<AttackBehavior>();
			attackInstance.Stats = attackStats;
		}

		private GameObject CreateAttackObject()
		{
			GameObject instance = Instantiate(weaponData.AttackObject);
			instance.SetActive(false);
			instance.layer = LayerMask.NameToLayer("Attack");
			AttackBehavior attackInstance = instance.GetComponent<AttackBehavior>();
			attackInstance.OnEnd.AddListener(attackObjectPool.Release);
			attackInstance.Source = gameObject;
			return instance;
		}

		private void OnGetAttackObject(GameObject attackObject)
		{
			attackObject.transform.position = transform.position;
			attackObject.transform.right = transform.right;
			attackObject.SetActive(true);
		}

		private void OnReleaseAttackObject(GameObject attackObject)
		{
			attackObject.SetActive(false);
		}
	}
}