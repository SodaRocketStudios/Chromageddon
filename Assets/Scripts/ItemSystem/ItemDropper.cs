using System;
using UnityEngine;
using UnityEngine.Pool;
using SRS.Extensions;

namespace SRS.ItemSystem
{
	public class ItemDropper : MonoBehaviour
	{
		public static ItemDropper Instance;

		[SerializeField] private GameObject itemDropPrefab;

		[SerializeField] private float dropChance;

		private ObjectPool<ItemDrop> itemDropPool;

		private System.Random random = new System.Random(Guid.NewGuid().GetHashCode());

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

			itemDropPool = new ObjectPool<ItemDrop>(CreatePickup, OnRetrievePickup, OnReleasePickup);
		}

		public void TryDropItem(GameObject target)
		{
			if(random.NextFloat()*100 < dropChance)
			{
				DropItem(target.transform.position);
			}

		}

		public void DropItem(Vector2 position)
		{
			ItemDrop itemDrop = itemDropPool.Get();
			itemDrop.transform.position = position;
		}

		private ItemDrop CreatePickup()
		{
			return Instantiate(itemDropPrefab, Vector3.zero, Quaternion.identity).GetComponent<ItemDrop>();
		}

		private void OnRetrievePickup(ItemDrop itemDrop)
		{
			itemDrop.gameObject.SetActive(true);

			itemDrop.OnPickup += ReturnPickup;
		}

		private void OnReleasePickup(ItemDrop itemDrop)
		{
			itemDrop.gameObject.SetActive(false);
		}

		private void ReturnPickup(ItemDrop itemDrop)
		{
			itemDrop.OnPickup -= ReturnPickup;

			itemDropPool.Release(itemDrop);
		}
	}
}