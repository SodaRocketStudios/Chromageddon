using System.Collections.Generic;
using UnityEngine;

namespace SRS.Utils.ObjectPooling
{
	[CreateAssetMenu(fileName = "Object Pool", menuName = "Utils/Object Pool")]
	public class ObjectPool<T> : ScriptableObject, IPool<T> where T : MonoBehaviour, IPoolable<T>
	{
		[SerializeField] private GameObject basePrefab;

		private Queue<T> pool = new();

		private GameObject parentObject;

		public T Get()
		{
			T pooledObject;

			if(pool.Count <= 0)
			{
				pool.Enqueue(CreateObject());
			}

			pooledObject = pool.Dequeue();
			pooledObject.gameObject.SetActive(true);
			pooledObject.Initialize(Return);

			return pooledObject;
		}

		public void Return(T pooledObject)
		{
			pool.Enqueue(pooledObject);
			pooledObject.gameObject.SetActive(false);
		}

		private T CreateObject()
		{
			if(parentObject == null)
			{
				parentObject = new($"{basePrefab.name} container");
			}

			GameObject newObject = Instantiate(basePrefab);
			newObject.SetActive(false);
			newObject.transform.SetParent(parentObject.transform);

			return newObject.GetComponent<T>();
		}

	}

	public interface IPool<T>
	{
		T Get();
		void Return(T pooledObject);
	}
}