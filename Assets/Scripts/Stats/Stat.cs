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
            get => name;
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

        public float ValueUnclamped
        {
            get
            {
                return CalculateUnclamped();
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
        public bool HasMaximum
        {
            get => hasMaximum;
        }
        [SerializeField] private float maximumValue = 1;
        public float MaximumValue
        {
            get => maximumValue;
        }

        [SerializeField] private bool hasMinimum;
        public bool HasMinimum
        {
            get => hasMinimum;
        }
        [SerializeField] private float minimumValue;
        public float MinimumValue
        {
            get => minimumValue;
        }

        [SerializeField] private StatFormat format;
        public StatFormat Format
        {
            get => format;
        }

        private int zeroCount = 0;
        private bool isDirty = true;

        public Stat(Stat stat)
        {
            name = stat.name;
            baseValue = stat.baseValue;
            percentageModifier = stat.percentageModifier;
            hasMaximum = stat.hasMaximum;
            maximumValue = stat.maximumValue;
            hasMinimum = stat.hasMinimum;
            minimumValue = stat.minimumValue;
            format = stat.format;
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

        private float CalculateUnclamped()
        {
            switch(format)
            {
                case StatFormat.Flat:
                    return baseValue;
                case StatFormat.Percentage:
                    return percentageModifier/100.0f;
                case StatFormat.Full:
                    return baseValue * percentageModifier/100.0f;
                default:
                    return -1;
            }
        }

        private void calculateValue()
        {
            value = CalculateUnclamped();

            if (hasMinimum)
            {
                value = Mathf.Max(value, minimumValue);
            }
            if (hasMaximum)
            {
                value = Mathf.Min(value, maximumValue);
            }

            isDirty = false;
        }
    }

    public enum StatFormat
    {
        Flat,
        Percentage,
        Full
    }
}
