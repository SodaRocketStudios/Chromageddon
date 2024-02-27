using UnityEngine;
using UnityEngine.UI;

namespace SRS.EnemyManagement
{
	public class EliteIndicator : MonoBehaviour
	{
		private Image image;

		private void Awake()
		{
			image = GetComponent<Image>();
		}

		public void Draw(int Elitifications)
		{
			if(Elitifications <= 0)
			{
				return;
			}

			image.enabled = true;
		}

		public void Reset()
		{
			image.enabled = false;
		}
	}
}