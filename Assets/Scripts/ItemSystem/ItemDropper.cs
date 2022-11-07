using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace SRS.ItemSystem
{
	public class ItemDropper : MonoBehaviour
	{
		public static ItemDropper Instance;

		[SerializeField] private GameObject itemPickupPrefab;

		[SerializeField] private List<Sprite> pickupSprites = new List<Sprite>(5);

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

			itemPickupPool = new ObjectPool<ItemPickup>(CreatePickup, OnRetrievePickup, OnReturnPickup);
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

			// To Do -- Pick the item rarity at random.
			pickup.rarity = ItemRarity.Common;
			
			pickup.GetComponent<SpriteRenderer>().sprite = pickupSprites[(int)pickup.rarity];

			pickup.OnPickup += ReturnPickup;
		}

		private void OnReturnPickup(ItemPickup pickup)
		{
			pickup.gameObject.SetActive(false);
		}

		private void ReturnPickup(ItemPickup pickup)
		{
			itemPickupPool.Release(pickup);
		}
	}
}