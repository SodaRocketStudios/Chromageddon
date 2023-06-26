using UnityEngine;
using UnityEngine.Pool;

namespace SRS.AttackSystem
{
	public class ProjectileSpawner : MonoBehaviour
	{
		public static ProjectileSpawner Instance;

		private ObjectPool<GameObject> pool;

		[SerializeField] private GameObject projectilePrefab;

		private void Awake()
		{
			Instance = this;
			
			pool = new ObjectPool<GameObject>(Create, OnGet, OnReturn, defaultCapacity: 50);
		}

		public GameObject Spawn(Vector3 position, Quaternion direction)
		{
			GameObject projectile = pool.Get();

			projectile.transform.rotation = direction;
			projectile.transform.position = position;

			return projectile;
		}

		public void Despawn(GameObject projectile)
		{
			pool.Release(projectile);
		}

		private GameObject Create()
		{
			GameObject projectile = Instantiate(projectilePrefab);
			projectile.SetActive(false);

			return projectile;
		}

		private void OnGet(GameObject projectile)
		{
			projectile.SetActive(true);
		}

		private void OnReturn(GameObject projectile)
		{
			projectile.SetActive(false);
		}
	}
}