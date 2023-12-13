using System;
using UnityEngine;

namespace SRS.Utils.ObjectPooling
{
	public class PooledObject : MonoBehaviour
	{
		private Action<GameObject> returnAction;

		private void OnDisable()
		{
			ReturnToPool();
		}


        public void Initialize(Action<GameObject> returnAction)
		{
			this.returnAction = returnAction;
		}

        public void ReturnToPool()
        {
            returnAction?.Invoke(gameObject);
        }
	}
}