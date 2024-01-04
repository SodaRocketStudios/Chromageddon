using UnityEngine;

namespace SRS.Progression
{
	public class DifficultyManager : MonoBehaviour
	{
		[SerializeField] private ProgressionFunction difficultyFuction;

		private float challengeRating = 0;
		public float ChallengeRating{ get => challengeRating; }
	}
}