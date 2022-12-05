using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace SRS.ItemSystem
{
	public class ItemDropper : MonoBehaviour
	{
		public static ItemDropper Instance;

		[SerializeField] private GameObject itemPickupPrefab;

		private ObjectPool<ItemPickup> itemPickupPool;

		private void Awake()
		{
			if(Instance == null)
			{
				Instance = this;
			}
			else if(Instance != this)
			{
				Destroy(this);
			}

			itemPickupPool = new ObjectPool<ItemPickup>(CreatePickup, OnRetrievePickup, OnReleasePickup);
		}

		public void DropItem(Vector2 position)
		{
			ItemPickup pickup = itemPickupPool.Get();
			pickup.transform.position = position;
		}

		private ItemPickup CreatePickup()
		{
			return Instantiate(itemPickupPrefab, Vector3.zero, Quaternion.identity).GetComponent<ItemPickup>();
		}

		private void OnRetrievePickup(ItemPickup pickup)
		{
			pickup.gameObject.SetActive(true);

			pickup.OnPickup += ReturnPickup;
		}

		private void OnReleasePickup(ItemPickup pickup)
		{
			pickup.gameObject.SetActive(false);
		}

		private void ReturnPickup(ItemPickup pickup)
		{
			pickup.OnPickup -= ReturnPickup;

			itemPickupPool.Release(pickup);
		}

		private void Update()
		{
			if(itemPickupPool.CountActive < 5)
			{
				ItemPickup pickup = itemPickupPool.Get();
				pickup.transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
			}
		}
	}
}