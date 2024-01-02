using System.Collections.Generic;
using UnityEngine;

namespace SRS.Utils.ObjectPooling
{
	[CreateAssetMenu(fileName = "Object Pool", menuName = "Utils/Object Pool")]
	public class ObjectPool : ScriptableObject
	{
		[SerializeField] private GameObject basePrefab;

		[SerializeField] private bool RecycleOldestOnOverflow;
		[SerializeField, Min(1)] private int maxObjects;
		private int objectCount => pool.Count + activeObjects.Count;

		private Queue<PooledObject> pool = new();
		private List<PooledObject> activeObjects = new();

		private GameObject parentObject;

		public PooledObject Get()
		{
			PooledObject pooledObject;

			if(pool.Count <= 0)
			{
				if(RecycleOldestOnOverflow && objectCount >= maxObjects)
				{
					for(int i = 0; i < maxObjects; i++)
					{
						if(activeObjects[i].IgnoreRecycleRequest == false)
						{
							Return(activeObjects[i]);
						}
					}
				}
				else
				{
					pool.Enqueue(CreateObject());
				}
			}

			if(pool.Count <= 0)
			{
				return null;
			}

			pooledObject = pool.Dequeue();
			pooledObject.gameObject.SetActive(true);
			pooledObject.Initialize(Return);

			return pooledObject;
		}

		public PooledObject Get(Vector3 position)
		{
			PooledObject newObject = Get();
			newObject.transform.position = position;
			activeObjects.Add(newObject);
			return newObject;
		}

		public PooledObject Get(Vector3 position, Quaternion rotation)
		{
			PooledObject newObject = Get(position);
			newObject.transform.rotation = rotation;
			return newObject;
		}

		public void Return(PooledObject pooledObject)
		{
			pool.Enqueue(pooledObject);
			pooledObject.gameObject.SetActive(false);
			activeObjects.Remove(pooledObject);
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