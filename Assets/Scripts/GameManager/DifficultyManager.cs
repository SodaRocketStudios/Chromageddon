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
				float progress = ChallengeRatingUnclamped;

				return difficultyCurve.Evaluate(Mathf.Clamp01(progress));
			}
		}

		public float ChallengeRatingUnclamped
		{
			get
			{
				float progress = GameTimer.Instance.Time/secondsToMaxDifficulty;
				
				if(progress <= 0)
				{
					return 0.01f;
				}

				return progress;
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