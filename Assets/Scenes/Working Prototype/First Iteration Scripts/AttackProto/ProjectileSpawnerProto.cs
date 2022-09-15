using UnityEngine;

namespace SRS.AttackProto
{
	public class ProjectileSpawnerProto
	{
		private GameObject projectile;

		public ProjectileSpawnerProto()
		{
		}

		public void SpawnProjectile(Transform origin)
		{
			GameObject.Instantiate(projectile, origin.position, origin.rotation);
		}

		public void SetProjectile(GameObject projectilePrefab)
		{
			projectile = projectilePrefab;
		}
	}
}