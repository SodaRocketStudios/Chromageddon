using System.Collections.Generic;
using UnityEngine;

namespace SRS.Utils.ObjectPooling
{
	[CreateAssetMenu(fileName = "Object Pool", menuName = "Utils/Object Pool")]
	public class ObjectPool<T> : ScriptableObject where T : MonoBehaviour, IPoolable
	{
		[SerializeField] private GameObject prefab;

		private Queue<GameObject> pool = new();

		private GameObject parentObject;

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
				parentObject = new($"{prefab.name} container");
			}

			GameObject newObject = Instantiate(prefab);
			newObject.SetActive(false);
			newObject.transform.SetParent(parentObject.transform);

			return newObject;
		}
	}
}