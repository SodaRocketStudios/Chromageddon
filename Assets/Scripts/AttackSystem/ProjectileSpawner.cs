using UnityEngine;
using UnityEngine.Pool;

namespace SRS.AttackSystem
{
	public class ProjectileSpawner : MonoBehaviour
	{
		public static ProjectileSpawner Instance;

		public ObjectPool<GameObject> Pool;

		[SerializeField] private GameObject projectilePrefab;

		private void Awake()
		{
			Instance = this;
			
			Pool = new ObjectPool<GameObject>(Create, OnGet, OnReturn, defaultCapacity: 50);
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