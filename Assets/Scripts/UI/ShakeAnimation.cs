using UnityEngine;

namespace SRS.UI
{
    public class ShakeAnimation : MonoBehaviour
    {
        [SerializeField] private float amplitude;

        public void UpdatePosition(float t)
        {
            transform.position += (Vector3)Random.insideUnitCircle*amplitude;
        }
    }
}
