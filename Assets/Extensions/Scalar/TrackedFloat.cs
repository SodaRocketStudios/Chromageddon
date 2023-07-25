namespace SRS.Extensions.Scalar
{
    public class TrackedFloat
    {
        public TrackedFloat()
        {
            this.value = 0;
        }

        public TrackedFloat(float value)
        {
            this.value = value;
        }

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
