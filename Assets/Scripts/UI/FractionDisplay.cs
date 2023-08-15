using UnityEngine;
using TMPro;

namespace SRS.UI
{
    public class FractionDisplay : MonoBehaviour
    {
        [SerializeField] private int decimalPlaces = 1;

        private TMP_Text textElement;

        private float currentValue;
        private float maxValue;

        private void Init()
        {
            textElement = GetComponent<TMP_Text>();
        }

        public void UpdateValue(float value)
        {
            if(textElement == null)
            {
                Init();
            }

            currentValue = value;
            
            textElement.text = $"{currentValue.ToString("N" + decimalPlaces)}/{maxValue.ToString("N" + decimalPlaces)}";
        }

        public void UpdateMax(float value)
        {
            if(textElement == null)
            {
                Init();
            }

            maxValue = value;
            
            textElement.text = $"{currentValue.ToString("N" + decimalPlaces)}/{maxValue.ToString("N" + decimalPlaces)}";
        }
    }
}
