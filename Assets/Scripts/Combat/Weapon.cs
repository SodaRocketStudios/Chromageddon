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
			AttackHandler attackInstance = attackObjectPool.Get().GetComponent<AttackHandler>();
			attackInstance.Stats = attackStats;
		}

		private GameObject CreateAttackObject()
		{
			GameObject instance = Instantiate(weaponData.AttackObject);
			instance.SetActive(false);
			instance.layer = LayerMask.NameToLayer("Attack");
			AttackHandler attackInstance = instance.GetComponent<AttackHandler>();
			attackInstance.Source = gameObject;
			attackInstance.OnEnd.AddListener(attackObjectPool.Release);
			return instance;
		}

		private void OnGetAttackObject(GameObject attackObject)
		{
			attackObject.SetActive(true);
			attackObject.transform.position = transform.position;
			attackObject.transform.right = transform.right;

			// Set the attacker stats on the attackObject.
		}

		private void OnReleaseAttackObject(GameObject attackObject)
		{
			attackObject.SetActive(false);
		}
	}
}