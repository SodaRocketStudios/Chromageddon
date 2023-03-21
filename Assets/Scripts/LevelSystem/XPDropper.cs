using UnityEngine;
using UnityEngine.Pool;

namespace SRS.LevelSystem
{
	public class XPDropper : MonoBehaviour
	{
		public ObjectPool<GameObject> pool;

		[SerializeField] private GameObject XPPrefab;

		private void Awake()
		{
			pool = new ObjectPool<GameObject>(Create, OnGet, OnRelease);
		}

		private GameObject Create()
		{
			return Instantiate(XPPrefab);
		}
		
		public void SpawnXP(Vector2 position)
		{
			GameObject pickup = pool.Get();
			pickup.transform.position = position;
		}

		public void RemoveXP(GameObject pickup)
		{
			pool.Release(pickup);
		}

		private void OnGet(GameObject pickup)
		{
			pickup.SetActive(true);
		}

		private void OnRelease(GameObject pickup)
		{
			pickup.SetActive(false);
		}
	}
}