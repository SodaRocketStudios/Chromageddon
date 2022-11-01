using UnityEngine;

namespace SRS.ItemSystem
{
	public class ItemDropper : MonoBehaviour
	{
		public static ItemDropper Instance;

		[SerializeField]
		private GameObject itemPickupPrefab;

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
		}

		public void DropItem(Vector2 position)
		{
			// To Do -- repalce this with object pooling
			Instantiate(itemPickupPrefab, position, Quaternion.identity);
		}
	}
}