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
                    if(TryRecycle() == false)
					{
						return null;
					}
                }
                else
				{
					pool.Enqueue(CreateObject());
				}
			}

			pooledObject = pool.Dequeue();
			pooledObject.gameObject.SetActive(true);
			pooledObject.Initialize(Return);
			activeObjects.Add(pooledObject);

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
			activeObjects.Remove(pooledObject);
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

        private bool TryRecycle()
        {
            for (int i = 0; i < activeObjects.Count; i++)
            {
                if (activeObjects[i].IgnoreRecycleRequest == false)
                {
					Debug.Log("Recycled", activeObjects[i].gameObject);
                    Return(activeObjects[i]);
					return true;
                }
            }

			return false;
        }
	}
}