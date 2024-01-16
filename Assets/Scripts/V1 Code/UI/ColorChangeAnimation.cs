using UnityEngine;
using UnityEngine.UI;

namespace SRS.UI
{
    public class ColorChangeAnimation : MonoBehaviour
    {
        [SerializeField] private Color startColor;
        public Color StartColor
        {
            get
            {
                return startColor;
            }
            set
            {
                startColor = value;
                UpdateColor();
            }
        }
        public Color EndColor;

        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
            image.color = startColor;
        }

        public void UpdateColor(float t)
        {
            image.color = Color.Lerp(startColor, EndColor, t);
        }

        private void UpdateColor()
        {
            image.color = StartColor;
        }
    }
}