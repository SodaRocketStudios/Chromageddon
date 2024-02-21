using Cinemachine;
using UnityEngine;

namespace SRS.Utils
{
	public class ScreenShakeGain : MonoBehaviour
	{
		private CinemachineImpulseListener impulseListener;

		private void Awake()
		{
			impulseListener = GetComponent<CinemachineImpulseListener>();
		}

		public void SetGain(float gain)
		{
			impulseListener.m_Gain = gain;
		}
	}
}