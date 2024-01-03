using UnityEngine;

namespace SRS.Utils.ObjectPooling
{
	[CreateAssetMenu(fileName = "New Object Pool", menuName = "Utils/Object Pool")]
	public class ObjectPool : ScriptableObject
	{
		[SerializeField] private GameObject basePrefab;

		private GameObject parentObject;

		private Pool pool;

		public PooledObject Get()
		{
			PooledObject pooledObject;

			if(pool.Count <= 0)
			{
				pool.Enqueue(CreateObject());
			}

			pooledObject = pool.Dequeue();
			pooledObject.gameObject.SetActive(true);
			pooledObject.Initialize(Return);

			return pooledObject;
		}


        public PooledObject Get(Vector3 position)
		{
			PooledObject pooledObject = Get();
			pooledObject.transform.position = position;
			return pooledObject;
		}

		public PooledObject Get(Vector3 position, Quaternion rotation)
		{
			PooledObject pooledObject = Get(position);
			pooledObject.transform.rotation = rotation;
			return pooledObject;
		}

		public void Return(PooledObject pooledObject)
		{
			pool.Enqueue(pooledObject);

			if(pooledObject.gameObject.activeSelf)
			{
				pooledObject.gameObject.SetActive(false);
			}
		}

		private PooledObject CreateObject()
		{
			if(parentObject == null)
			{
				parentObject = new GameObject($"{basePrefab.name} Pool");
				pool = parentObject.AddComponent<Pool>();
			}

			GameObject newObject = Instantiate(basePrefab);
			newObject.SetActive(false);
			newObject.transform.SetParent(parentObject.transform);

			return newObject.GetComponent<PooledObject>();
		}
	}
}