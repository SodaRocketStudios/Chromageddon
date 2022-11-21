using UnityEngine;
using Cinemachine;

namespace SRS.CameraShake
{
	public class ScreenShake : MonoBehaviour
	{
		[SerializeField] private AnimationCurve shakeCurve;
		[SerializeField] private float decaySpeed;

		private CinemachineVirtualCamera vCamera;
		private CinemachineBasicMultiChannelPerlin noise;

		private float maxTrauma;
		private float trauma = 0;

		private void Awake()
		{
			maxTrauma = shakeCurve.keys[shakeCurve.length-1].time;
		}

		private void Start()
		{
			vCamera = GetComponent<CinemachineVirtualCamera>();
			noise = vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		}

		private void Update()
        {
            UpdateTrauma();

            noise.m_AmplitudeGain = shakeCurve.Evaluate(trauma);
        }

        public void AddTrauma(float amount)
		{
			trauma += amount;
		}

        private void UpdateTrauma()
        {
            if (trauma >= 0)
            {
                trauma -= decaySpeed * Time.deltaTime;
                trauma = Mathf.Clamp(trauma, 0, maxTrauma);
            }
        }
	}
}