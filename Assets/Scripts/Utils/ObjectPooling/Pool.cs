using System.Collections.Generic;
using UnityEngine;

namespace SRS.Utils.ObjectPooling
{
	public class Pool : MonoBehaviour
	{
		private Queue<PooledObject> queue = new();

		public int Count => queue.Count;

		public void Enqueue(PooledObject pooledObject)
		{
			queue.Enqueue(pooledObject);
		}

		public PooledObject Dequeue()
		{
			return queue.Dequeue();
		}
	}
}