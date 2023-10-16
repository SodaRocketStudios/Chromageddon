using UnityEngine;
using UnityEngine.Pool;

namespace SRS.EnemySpawner
{
    public class ReturnToPool : MonoBehaviour
    {
        public ObjectPool<GameObject> Pool;

        public void Release()
        {
            Pool.Release(gameObject);
        }
    }
}
