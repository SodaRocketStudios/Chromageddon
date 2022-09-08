using UnityEngine;
using SodaRocket.HealthProto;

namespace SodaRocket.AttackProto
{
	public class ProjectileProto : MonoBehaviour
	{
		void Update()
		{
			transform.Translate(transform.right*Time.deltaTime*10, Space.World);
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if(other.gameObject.layer != LayerMask.NameToLayer("Player"))
			{
				Destroy(gameObject);
			}

			if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
			{
				other.gameObject.GetComponent<HealthManagerProto>().Damage(10);
			}
		}
	}
}