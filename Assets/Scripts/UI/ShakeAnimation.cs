using UnityEngine;
using SRS.Noise;

namespace SRS.UI
{
    public class ShakeAnimation : MonoBehaviour
    {
        [SerializeField] private float amplitude;
        [SerializeField] private float frequency;

        private SmoothShake shake;

        private RectTransform rect;

        private void Start()
        {
            rect = GetComponent<RectTransform>();
        }

        public void UpdatePosition(float t)
        {
            if(shake == null)
            {
                shake = new SmoothShake(rect.anchoredPosition, 0, frequency);
            }

            shake.Amplitude = t*amplitude;
            rect.anchoredPosition = shake.Step();
        }
    }
}