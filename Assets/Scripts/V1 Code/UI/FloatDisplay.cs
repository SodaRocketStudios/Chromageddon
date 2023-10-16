using UnityEngine;
using TMPro;

namespace SRS.UI
{
    public class FloatDisplay : MonoBehaviour
    {
        [SerializeField] private string preText;
        [SerializeField] private string postText;
        [SerializeField] private int decimalPlaces = 1;

        private TMP_Text textComponent;

        private void Awake()
        {
            textComponent = GetComponent<TMP_Text>();
        }

        public void UpdateDisplay(float value)
        {
            textComponent.text = $"{preText}{value.ToString("N" + decimalPlaces)}{postText}";
        }
    }
}
