using UnityEngine;

namespace SRS.Extensions.Scalar
{
    public class TrackedFloat
    {
        private float value;
        public float Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                OnValueChange?.Invoke(value);
            }
        }

            public delegate void valueChangeEvent(float value);
            public event valueChangeEvent OnValueChange;
    }
}
