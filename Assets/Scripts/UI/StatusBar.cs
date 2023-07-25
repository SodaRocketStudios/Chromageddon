using UnityEngine;
using UnityEngine.UI;

namespace SRS.UI
{
    public abstract class StatusBar : MonoBehaviour
    {
        private Slider slider;

        protected void Init()
        {
            slider = GetComponent<Slider>();
        }

        protected void UpdateValue(float value)
        {
            if(slider == null)
            {
                Init();
            }
            
            slider.value = value;
        }

        protected void UpdateMax(float value)
        {
            if(slider == null)
            {
                Init();
            }
            
            slider.maxValue = value;
        }
    }
}