using UnityEngine;
using TMPro;

namespace SRS.GameTimeProto
{
	public class TimerDisplayTest : MonoBehaviour
	{
		private TMP_Text text;

		private void Start()
		{
			text = GetComponent<TMP_Text>();	
		}

		void Update()
		{
			text.text = GameTimerProto.instance.currentTime.ToString();
		}
	}
}