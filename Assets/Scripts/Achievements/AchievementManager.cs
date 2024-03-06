using UnityEngine;

namespace SRS.Achievements
{
	public class AchievementManager : MonoBehaviour
	{
		[SerializeField] private Achievement[] achievements;

		private void Start()
		{
			foreach(Achievement achievement in achievements)
			{
				achievement.Initialize();
			}
		}
	}
}