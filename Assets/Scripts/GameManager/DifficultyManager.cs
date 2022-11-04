using UnityEngine;

namespace SRS.GameManager
{
	public class DifficultyManager : MonoBehaviour
	{
		// To Do -- need a reference to the game timer to get difficulty based on game time.
		[SerializeField] AnimationCurve difficultyCurve;

		[SerializeField] private float secondsToMaxDifficulty = 600;

		public static DifficultyManager Instance;

		public float ChallengeRating
		{
			get
			{
				return difficultyCurve.Evaluate(progress);
			}
		}

		private float progress = 0;

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
		
		private void Update()
		{
			progress = Mathf.Clamp01(secondsToMaxDifficulty/GameTimer.Instance.Time);
		}
	}
}