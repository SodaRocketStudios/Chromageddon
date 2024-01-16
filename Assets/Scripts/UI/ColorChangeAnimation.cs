using UnityEngine;
using UnityEngine.UI;

namespace SRS.UI
{
    public class ColorChangeAnimation : MonoBehaviour
    {
        [SerializeField] private Gradient gradient;

        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void UpdateColor(float t)
        {
            image.color = gradient.Evaluate(t);
        }
    }
}