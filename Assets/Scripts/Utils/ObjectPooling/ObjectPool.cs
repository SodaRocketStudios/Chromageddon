using System.Collections.Generic;
using UnityEngine;

namespace SRS.Utils.ObjectPooling
{
	[CreateAssetMenu(fileName = "Object Pool", menuName = "Utils/Object Pool")]
	public class ObjectPool : ScriptableObject
	{
		[SerializeField] private GameObject basePrefab;

		private Queue<PooledObject> pool = new();

		private GameObject parentObject;

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
			pooledObject.gameObject.SetActive(false);
		}

		private PooledObject CreateObject()
		{
			if(parentObject == null)
			{
				parentObject = new($"{basePrefab.name} Pool");
			}

			GameObject newObject = Instantiate(basePrefab);
			newObject.SetActive(false);
			newObject.transform.SetParent(parentObject.transform);

			return newObject.GetComponent<PooledObject>();
		}
	}
}