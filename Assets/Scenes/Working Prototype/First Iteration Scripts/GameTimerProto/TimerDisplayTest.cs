using UnityEngine;
using TMPro;

namespace SRS.GameTimeProto;
{
	public class TimerDisplayTest : MonoBehaviour
	{
		private TMP_Text text;
		void Update()
		{
			text.text = GameTimerProto.instance.currentTime.ToString();
		}
	}
}