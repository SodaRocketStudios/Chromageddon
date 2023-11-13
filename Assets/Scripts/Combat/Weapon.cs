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

			// TO DO -- treat Melee and Ranged weapons differently for lifetime.
			attackInstance.Lifetime = attackStats["Range"].Value;
		}

		private GameObject CreateAttackObject()
		{
			GameObject instance = Instantiate(weaponData.AttackObject);
			instance.SetActive(false);
			instance.layer = LayerMask.NameToLayer("Attack");
			AttackHandler attackInstance = instance.GetComponent<AttackHandler>();
			attackInstance.OnEnd.AddListener(attackObjectPool.Release);
			attackInstance.Source = gameObject;
			return instance;
		}

		private void OnGetAttackObject(GameObject attackObject)
		{
			attackObject.SetActive(true);
			attackObject.transform.position = transform.position;
			attackObject.transform.right = transform.right;
		}

		private void OnReleaseAttackObject(GameObject attackObject)
		{
			attackObject.SetActive(false);
		}
	}
}