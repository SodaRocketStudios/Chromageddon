using UnityEngine;
using SRS.HealthProto;

namespace SRS.AttackProto
{
	public class ProjectileProto : MonoBehaviour
	{
		void Update()
		{
			transform.Translate(transform.right*Time.deltaTime*10, Space.World);
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
			{
				other.gameObject.GetComponent<HealthManagerProto>().Damage(10);
				Destroy(gameObject);
			}
		}
	}
}