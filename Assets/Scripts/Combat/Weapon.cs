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
			AttackHandler attackInstance = attackObjectPool.Get().GetComponent<AttackHandler>();
			attackInstance.Stats = attackStats;
		}

		private GameObject CreateAttackObject()
		{
			GameObject instance = Instantiate(weaponData.AttackObject);
			instance.transform.SetParent(transform);
			instance.SetActive(false);
			instance.GetComponent<AttackHandler>().OnEnd.AddListener(attackObjectPool.Release);
			// Set something to stop the attack from hitting the attacker. (Could also prevent attacks from hitting the parent object)
			// This may already work since the attacks will be the same layer as the parent object.
			// Attacks may be able to collide with each other.
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