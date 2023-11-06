using UnityEngine;
using SRS.Stats;
using UnityEngine.Pool;

namespace SRS.Combat
{
    public class Weapon : MonoBehaviour
	{
		[SerializeField] private WeaponData weaponData;

		ObjectPool<GameObject> attackObjectPool;

		private void Start()
		{
			attackObjectPool = new(CreateAttackObject, OnGetAttackObject, OnReleaseAttackObject);
		}

		public void Attack(StatContainer attackStats)
		{
			Attack attackInstance = attackObjectPool.Get().GetComponent<Attack>();
		}

		private GameObject CreateAttackObject()
		{
			GameObject instance = Instantiate(weaponData.AttackObject);
			instance.transform.SetParent(transform);
			instance.SetActive(false);
			instance.GetComponent<Attack>().OnEnd.AddListener(attackObjectPool.Release);
			// Set something to stop the attack from hitting the attacker. (Could also prevent attacks from hitting tha parent object)
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