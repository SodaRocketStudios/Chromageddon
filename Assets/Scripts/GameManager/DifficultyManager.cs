using UnityEngine;
using SRS.Curves;

namespace SRS.GameManager
{
	public class DifficultyManager : MonoBehaviour
	{
		[SerializeField] private float secondsToMaxDifficulty = 600;

		public static DifficultyManager Instance;

		private ExponentialCurve difficultyCurve = new ExponentialCurve(2);

		public float ChallengeRating
		{
			get
			{
				float difficulty = ChallengeRatingUnclamped;

				return Mathf.Clamp01(difficulty);
			}
		}

		public float ChallengeRatingUnclamped
		{
			get
			{
				float progress = GameTimer.Instance.Time/secondsToMaxDifficulty;

				float difficulty = difficultyCurve.Evaluate(progress);

				return Mathf.Max(0.01f, difficulty);
			}
		}

		private void Awake()
		{
			if(Instance == null)
			{
				Instance = this;
			}
			else if(Instance != this)
			{
				Destroy(gameObject);
			}
		}
	}
}