using System.Collections.Generic;
using UnityEngine;

namespace SRS.Utils.ObjectPooling
{
	[CreateAssetMenu(fileName = "Object Pool", menuName = "Utils/Object Pool")]
	public class ObjectPool : ScriptableObject
	{
		[SerializeField] private GameObject prefab;

		private Queue<GameObject> pool = new();

		private GameObject parentObject;

		// TODO -- create a parent object for all pooled objects.

		public GameObject Get()
		{
			GameObject pooledObject;

			if(pool.Count <= 0)
			{
				pool.Enqueue(CreateObject());
			}

			pooledObject = pool.Dequeue();
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
			if(parentObject == null)
			{
				parentObject = new(name);
			}

			GameObject newObject = Instantiate(prefab);
			newObject.SetActive(false);
			newObject.transform.SetParent(parentObject.transform);
			return newObject;
		}
	}
}