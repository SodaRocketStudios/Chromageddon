using UnityEngine;
using SRS.Extensions.Random;

namespace SRS.Noise
{
    public class SmoothShake
    {
        private System.Random random = new System.Random();

        private Vector3 center;
        private Vector3 start;
        private Vector3 end;

        private float amplitude;
        public float Amplitude
        {
            set
            {
                amplitude = value;
            }
        }
        
        private float frequency;
        private float Frequency
        {
            set
            {
                frequency = value;
            }
        }

        private float t = 0;

        public SmoothShake(Vector3 origin, float amplitude, float frequency)
        {
            Amplitude = amplitude;
            Frequency = frequency;
            center = origin;
            start = origin;
            end = GetNewPosition();
        }

        public Vector3 Step()
        {
            t += frequency*Time.unscaledDeltaTime;

            if(t >= 1)
            {
                t = 0;
                start = end;
                end = GetNewPosition();
            }

            return Vector3.Lerp(start, end, t);
        }

        private Vector3 GetNewPosition()
        {
            return center + random.WithinUnitSphere()*amplitude;
        }
    }
}