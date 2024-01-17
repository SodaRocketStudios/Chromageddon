using UnityEngine;
using UnityEngine.UI;

namespace SRS.UI
{
    public class ColorChangeAnimation : MonoBehaviour
    {
        [SerializeField] private Gradient gradient;
        public Gradient Gradient
        {
            get => gradient;
            set
            {
                gradient = value;
                UpdateColor(0);
            }
                
        }

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