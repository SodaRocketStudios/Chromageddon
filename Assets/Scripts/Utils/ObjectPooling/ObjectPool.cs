using System.Collections.Generic;
using UnityEngine;

namespace SRS.Utils.ObjectPooling
{
	[CreateAssetMenu(fileName = "Object Pool", menuName = "Utils/Object Pool")]
	public class ObjectPool : ScriptableObject
	{
		[SerializeField] private GameObject prefab;

		private Queue<GameObject> pool = new();

		public GameObject Get()
		{
			if(pool.Count <= 0)
			{
				return CreateObject();
			}

			GameObject pooledObject = pool.Dequeue();
			pooledObject.SetActive(true);
			pooledObject.GetComponent<PooledObject>().Initialize(Return);
			return pooledObject;
		}

		public void Return(GameObject pooledObject)
		{
			pool.Enqueue(pooledObject);
			pooledObject.SetActive(false);
		}

		private GameObject CreateObject()
		{
			GameObject newObject = Instantiate(prefab);
			newObject.SetActive(false);
			return newObject;
		}
	}
}