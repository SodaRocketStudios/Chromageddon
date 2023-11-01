using System;
using UnityEngine;

namespace SRS.Stats
{
    [Serializable]
    public class Stat
    {
        public event Action<float> OnChanged;

        [SerializeField] private string name;
        public string Name
        {
            get {return name;}
        }

        private float value;
        public float Value
        {
            get
            {
                if(zeroCount > 0)
                {
                    return 0;
                }

                if(isDirty)
                {
                    calculateValue();
                }

                return value;
            }
        }

        [SerializeField] private float baseValue = 0;
        public float BaseValue
        {
            get
            {
                return baseValue;
            }
            set
            {
                baseValue = value;
                isDirty = true;
                OnChanged?.Invoke(Value);
            }
        }

        [SerializeField] private float percentageModifier = 100;
        public float PercentageModifier
        {
            get
            {
                return percentageModifier;
            }
            set
            {
                percentageModifier = value;
                isDirty = true;
                OnChanged?.Invoke(Value);
            }
        }
        
        [SerializeField] private bool hasMaximum = false;
        [SerializeField] private float maximumValue = 1;
        [SerializeField] private bool hasMinimum;
        [SerializeField] private float minimumValue;
        
        private int zeroCount = 0;
        private bool isDirty = true;

        public Stat(Stat stat)
        {
            baseValue = stat.baseValue;
            percentageModifier = stat.percentageModifier;
            hasMaximum = stat.hasMaximum;
            maximumValue = stat.maximumValue;
            hasMinimum = stat.hasMinimum;
            minimumValue = stat.minimumValue;
        }

        public void SetMaximum(float max)
        {
            hasMaximum = true;
            maximumValue = max;
        }

        public void RemoveMaxiumum()
        {
            hasMaximum = false;
            maximumValue = 0;
        }

        public void SetMinimum(float min)
        {
            hasMinimum = true;
            minimumValue = min;
        }

        public void RemoveMinimum()
        {
            hasMinimum = false;
            minimumValue = 0;
        }

        public void SetZero()
        {
            zeroCount++;
        }

        public void RemoveZero()
        {
            zeroCount--;
        }

        public Stat DeepCopy()
        {
            Stat copy = new Stat(this);
            return copy;
        }

        private void calculateValue()
        {
            value = baseValue * percentageModifier / 100.0f;

            if (hasMinimum)
                value = Mathf.Max(value, minimumValue);
            if (hasMaximum)
                value = Mathf.Min(value, maximumValue);

            isDirty = false;
        }
    }
}
