using UnityEngine;

namespace SRS.GameManager
{
	public class DifficultyManager : MonoBehaviour
	{
		[SerializeField] AnimationCurve difficultyCurve;

		[SerializeField] private float secondsToMaxDifficulty = 600;

		public static DifficultyManager Instance;

		public float ChallengeRating
		{
			get
			{
				float progress = GameTimer.Instance.Time/secondsToMaxDifficulty;
				
				if(progress <= 0)
				{
					return 0.01f;
				}

				return difficultyCurve.Evaluate(Mathf.Clamp01(progress));
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