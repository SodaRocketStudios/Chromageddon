using System;
using UnityEngine;

namespace SRS.Utils.ObjectPooling
{
	public class PooledObject : MonoBehaviour
	{
		private Action<PooledObject> returnAction;

		private void OnDisable()
		{
			ReturnToPool();
		}

        public void Initialize(Action<PooledObject> returnAction)
		{
			this.returnAction = returnAction;
		}

        public void ReturnToPool()
        {
            returnAction?.Invoke(this);
        }
    }
}