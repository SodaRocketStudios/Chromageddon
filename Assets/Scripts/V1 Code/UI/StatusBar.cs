using UnityEngine;
using UnityEngine.UI;

namespace SRS.UI
{
    public class StatusBar : MonoBehaviour
    {
        private Slider slider;

        protected void Init()
        {
            slider = GetComponent<Slider>();
        }

        public void UpdateValue(float value)
        {
            if(slider == null)
            {
                Init();
            }
            
            slider.value = value;
        }

        public void UpdateMax(float value)
        {
            if(slider == null)
            {
                Init();
            }
            
            slider.maxValue = value;
        }
    }
}