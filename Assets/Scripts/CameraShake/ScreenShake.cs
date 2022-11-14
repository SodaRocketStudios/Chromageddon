using UnityEngine;
using Cinemachine;

namespace SRS.CameraShake
{
	public class ScreenShake : MonoBehaviour
	{
		private CinemachineVirtualCamera vCamera;
		private CinemachineBasicMultiChannelPerlin noise;
		[SerializeField] float decayValue;

		private float trauma = 0;

		private void Start()
		{
			vCamera = GetComponent<CinemachineVirtualCamera>();
			noise = vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		}

		private void Update()
		{
			if(trauma >= 0)
			{
				trauma -= decayValue;
				trauma = Mathf.Clamp(trauma, 0, float.MaxValue);
			}

			noise.m_AmplitudeGain -= trauma;
		}

		public void AddTrauma(float amount)
		{
			trauma += amount;
		}
	}
}